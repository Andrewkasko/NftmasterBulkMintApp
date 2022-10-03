using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMaster.Desktop.Model.BulkMint.BulkMintBatch
{
    public class BulkMintBatchNFTReturn
    {
        public List<BulkMintBatchNFT> nfts { get; set; }
        public string message { get; set; }
    }
}
