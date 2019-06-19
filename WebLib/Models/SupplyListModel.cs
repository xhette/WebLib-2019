using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class SupplyListModel
    {
        public int Id { get; set; }
        public int SupplyId { get; set; }
        public int Sum { get; set; }
        public int ShopId { get; set; }
    }
}