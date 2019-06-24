using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Deliveries
{
    public class DeliveryViewModel
    {
        public AuthorModel Author { get; set; }

        public BookModel Book { get; set; }

        public DeliveryModel Delivery { get; set; }

        public ShopModel Shop { get; set; }
    }
}
