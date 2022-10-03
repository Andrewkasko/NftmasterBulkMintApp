using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMaster.Desktop.Model.BulkMint.BulkMintBatch
{
    public class BulkMintBatchNFT
    {
        public string uri { get; set; }
        public int flags { get; set; }
        public int taxon { get; set; }
        public int transferFee { get; set; }
    }
}
