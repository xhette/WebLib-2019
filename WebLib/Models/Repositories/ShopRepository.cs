using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class ShopRepository
    {
        public static ShopModel DataToModel(DataRow row)
        {
            ShopModel shop = new ShopModel
            {
                Id = row.Field<int>("shop_id"),
                Name = row.Field<string>("shop_name"),
                Adress = row.Field<string>("shop_adress"),
                PhoneNumber = row.Field<string>("shop_telephone")
            };

            return shop;
        }

        public static List<ShopModel> ShopList (string sqlQuery)
        {
            List<ShopModel> shops = new List<ShopModel>();
            DataSet data = DbContext.DbConnection(sqlQuery);

            foreach (DataRow row in data.Tables[0].Rows)
                shops.Add(DataToModel(row));
            return shops;
        }

        public static List<ShopModel> SelectAll()
        {
            string query = String.Format("select * from Shops");
            List<ShopModel> shops = ShopList(query);
            return shops;
        }

        public static List<ShopModel> SelectBySearch(string symbols)
        {
            string query = String.Format("select * from Shops where shop_name like '%{0}%'", symbols);
            List<ShopModel> shops = ShopList(query);
            return shops;
        }

        public static void Add(ShopModel model)
        {
            string query = String.Format("insert into Shops (shop_name, shop_adress, shop_telephone) values ('{0}', '{1}', '{2}')",
                model.Name, model.Adress, model.PhoneNumber);
            DataSet set = DbContext.DbConnection(query);
        }

        public static ShopModel Edit(int id)
        {
            string query = String.Format("select * from Shops where shop_id = {0}", id);
            ShopModel model = DataToModel(DbContext.DbConnection(query).Tables[0].Rows[0]);
            return model;
        }

        public static void Edit (ShopModel model)
        {
            string query = String.Format("update Shops set shop_name = '{0}', shop_adress = '{1}', shop_telephone = '{2}' where shop_id = {3}",
                model.Name, model.Adress, model.PhoneNumber, model.Id);
            DataSet data = DbContext.DbConnection(query);
        }

        public static void Delete (int id)
        {
            string query = String.Format("delete from Shops where shop_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);
        }
    }
}
