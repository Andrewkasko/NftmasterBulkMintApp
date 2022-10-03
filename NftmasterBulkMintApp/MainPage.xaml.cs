using NFTMaster.Desktop.Model.BulkMint.BulkMintBatch;
using System.Net.WebSockets;
using System.Net;
using System.Text;

namespace NftmasterBulkMintApp;

public partial class MainPage : ContentPage
{
	public BulkMintBatchNFTReturn Batch { get; set; }

	public MainPage()
	{
		InitializeComponent();
	}


    private async void OnSubmitBatchCodeClicked(object sender, EventArgs e)
    {
        Batch = await GetBatch(BulkMintCodeText.Text);

        if (Batch != null && Batch.nfts != null)
        {
            FormResultTxt.IsVisible = true;
            FormResultTxt.Text = "Batch Id: " + BulkMintCodeText.Text + "      NFT Count: " + Batch.nfts.Count().ToString();
            MintView();
        }
        else
        {
            FormResultTxt.IsVisible = true;
            FormResultTxt.Text = "No NFTS found." + Batch.message;
        }
    }

    private void RestartBtnClicked(object sender, EventArgs e)
    {
        TitleLbl.Text = "NFTMASTER - Bulk minter";
        BulkMintCodeText.Text = "";
        BatchView();
    }

    private async void OnMintBtnClicked(object sender, EventArgs e)
    {
        ProgressView();

        TitleLbl.Text = "We are signing your NFTS. Don't close the application.";
        ProgressBar.IsVisible = true;

        if (Batch != null && Batch.nfts != null)
        {

            int i = 0;

            foreach (var nft in Batch.nfts)
            {
                System.Threading.Thread.Sleep(2000);
                await MintNFT(nft, XrpAddressTxt.Text, SecretTxt.Text);

                ProgressBar.Progress = i / Batch.nfts.Count();
                i++;
            }
            ProgressBar.IsVisible = false;
            TitleLbl.Text = "Batch finished minting";
        }
    }

    public async Task<dynamic> GetBatch(string id)
    {
        using (var httpClient = new HttpClient())
        {
            string url = "https://api.nftmaster.com/Batch?id=" + id;
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string batchResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<BulkMintBatchNFTReturn>(batchResponse);
                }
                catch (Exception e) { }
            }
            return null;
        }
    }
    public async Task MintNFT(BulkMintBatchNFT nft, string address, string secret)
    {
        var client = new ClientWebSocket();
        await client.ConnectAsync(new Uri("wss://xls20-sandbox.rippletest.net:51233"), CancellationToken.None);
        var sending = Task.Run(async () =>
        {
            string jsonText = "{\"command\":\"submit\",\"secret\":\"" + secret + "\",\"tx_json\":{\"TransactionType\":\"NFTokenMint\",\"Account\":\"" + address + "\",\"NFTokenTaxon\":" + nft.taxon + ",\"Flags\":" + nft.flags + ",\"TransferFee\":" + nft.transferFee + ",\"URI\":\"" + nft.uri + "\"}}";
            var bytes = Encoding.UTF8.GetBytes(jsonText);
            await client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            await client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
        });
        var s = client;
    }

    private void MintView()
    {

        XrpAddressLbl.IsVisible = true;
        XrpAddressTxt.IsVisible = true;
        SecretLbl.IsVisible = true;
        SecretTxt.IsVisible = true;
        MintBtn.IsVisible = true;
        RestartBtn.IsVisible = true;

        SubmitBatchCodeBtn.IsVisible = false;
        BulkMintCodeText.IsVisible = false;
        BulkMintCodeLbl.IsVisible = false;
    }

    private void BatchView()
    {
        XrpAddressLbl.IsVisible = false;
        XrpAddressTxt.IsVisible = false;
        SecretLbl.IsVisible = false;
        SecretTxt.IsVisible = false;
        MintBtn.IsVisible = false;
        FormResultTxt.IsVisible = false;
        RestartBtn.IsVisible = false;

        SubmitBatchCodeBtn.IsVisible = true;
        BulkMintCodeText.IsVisible = true;
        BulkMintCodeLbl.IsVisible = true;

    }

    private void ProgressView()
    {
        XrpAddressLbl.IsVisible = false;
        XrpAddressTxt.IsVisible = false;
        SecretLbl.IsVisible = false;
        SecretTxt.IsVisible = false;
        MintBtn.IsVisible = false;
    }

}

