using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XHB.Card.Entity;

namespace CardSaleSystem.Models
{
    public class CardQueryExt
    {
        public List<VPack> VPack { get; set; }

        public IList<ActTypeEntity> ActType { get; set; }
    }
}