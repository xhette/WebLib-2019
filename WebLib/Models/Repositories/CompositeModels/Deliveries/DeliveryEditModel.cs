using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class DeliveryEditModel
    {
        public AuthorModel Author { get; set; }

        public BookModel Book { get; set; }

        public DeliveryModel Delivery { get; set; }

        public SelectList Shops { get; set; }

        public int SelectedShop { get; set; }
    }
}
