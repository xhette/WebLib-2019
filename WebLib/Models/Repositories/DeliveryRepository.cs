using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories.CompositeModels.Deliveries;

namespace WebLib.Models.Repositories
{
    public class DeliveryRepository
    {
        private static string primalQuery = String.Format
            ("select * from (Authors join (Books join (Deliveries join Shops on shop = shop_id) on book = book_id) on author = author_id) ");

        public static DeliveryModel DataToModel(DataRow row)
        {
            return new DeliveryModel
            {
                Id = row.Field<int>("delivery_id"),
                BookId = row.Field<int>("book"),
                Amount = row.Field<int>("amount"),
                Cost = row.Field<double>("cost"),
                Summ = row.Field<double>("summ"),
                Shop = row.Field<int>("shop")
            };
        }

        public static DeliveryViewModel DataToViewModel (DataRow row)
        {
            return new DeliveryViewModel
            {
                Author = AuthorRepository.DataToModel(row),
                Book = BookRepository.DataToDeliveryModel(row),
                Delivery = DataToModel(row),
                Shop = ShopRepository.DataToModel(row)
            };
        }

        public static List<DeliveryViewModel> DeliveryViewList (string query)
        {
            List<DeliveryViewModel> deliveries = new List<DeliveryViewModel>();
            DataSet data = DbContext.DbConnection(query);
            foreach (DataRow row in data.Tables[0].Rows)
                deliveries.Add(DataToViewModel(row));
            return deliveries;
        }

        public static List<DeliveryViewModel> ShowAll()
        {
            return DeliveryViewList(primalQuery);
        }

        public static List<DeliveryViewModel> ShowByShop(int id)
        {
            string query = String.Format(primalQuery + "where shop = {0}", id);
            return DeliveryViewList(query);
        }

        public static DeliveryEditModel Edit(int id)
        {
            DeliveryModel delivery = DataToModel(DbContext.DbConnection(
                String.Format("select * from Deliveries where delivery_id = {0}", id))
                .Tables[0].Rows[0]);

            DeliveryEditModel model = new DeliveryEditModel
            {
                Delivery = delivery,
                SelectedShop = delivery.Shop
            };

            model.Shops = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                ShopRepository.SelectAll(), "Id", "Name", model.SelectedShop);

            model.Book = BookRepository.DataToDeliveryModel(DbContext.DbConnection(String.Format
                ("select * from Books where book_id = {0}", model.Delivery.BookId)).Tables[0].Rows[0]);

            model.Author = AuthorRepository.DataToModel(DbContext.DbConnection(String.Format
                ("select * from Authors where author_id = {0}", model.Book.AuthorId)).Tables[0].Rows[0]);

            return model;
        }

        public static void Edit (DeliveryEditModel model)
        {
            if (model.Author.Patronymic == null) model.Author.Patronymic = "";
            string query = String.Format("exec UpdateDeliveries {0}, {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}",
                model.Delivery.Id, model.Delivery.BookId, model.Author.Surname, model.Author.FirstName, model.Author.Patronymic,
                model.Book.Title, model.Delivery.Amount, model.Delivery.Cost, model.SelectedShop);
            DataSet data = DbContext.DbConnection(query);
        }

        public static void Delete (int id)
        {
            string query = String.Format("delete from Deliveries where delivery_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);

        }

        public static DeliveryEditModel Add()
        {
            DeliveryEditModel model = new DeliveryEditModel
            {
                Delivery = new DeliveryModel(),
                Author = new AuthorModel(),
                Book = new BookModel(),
                Shops = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ShopRepository.SelectAll(), "Id", "Name")
            };

            return model;
        }

        public static void Add(DeliveryEditModel model)
        {
            if (model.Author.Patronymic == null) model.Author.Patronymic = "";
            string query = String.Format("exec AddDelivery '{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}",
                model.Author.Surname, model.Author.FirstName, model.Author.Patronymic, model.Book.Title, model.Delivery.Amount,
                model.Delivery.Cost, model.SelectedShop);
            DataSet data = DbContext.DbConnection(query);
        }
    }
}
