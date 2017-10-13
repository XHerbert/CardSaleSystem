using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSaleSystem.Models.ExtModel
{
    public class ActPriceEntityExt
    {
        public long Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double PrePrice { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsActive { get; set; }
    }
}