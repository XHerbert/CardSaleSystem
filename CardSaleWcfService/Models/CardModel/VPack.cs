using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHB.Card.Entity
{
    public class VPack
    {
        public string vCabName { get; set; }
        public string vSerial { get; set; }
        public string vAuthState { get; set; }
        public string vActKind { get; set; }
        public int iActCount { get; set; }
        public string dStartDate { get; set; }
        public string dEndDate { get; set; }
        public string dCreateDate { get; set; }
        public string vChannelNo { get; set; }
        public string vChannelNoPre { get; set; }
        public string vClient { get; set; }
        public string vMemo { get; set; }
    }

    public class VResult
    {
        public string Error { get; set; }
        public string Msg { get; set; }
        public string Tag { get; set; }
        public List<VPack> Result { get; set; }

        public int Code { get; set; }
    }
}
