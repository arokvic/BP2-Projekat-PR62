using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class OnlineCartCRUD
    {

        public OnlineCartCRUD()
        {

        }

        public virtual bool DeleteOnlineCart(int idOnlineCart)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {

                    OrderCRUD oc = new OrderCRUD();
                    ProductCRUD prodc = new ProductCRUD();
                    List<Product> l = prodc.GetProductList();
                    List<Order> loc = oc.GetOrderList();
                    foreach (var item in l)
                    {
                        if (item.OnlineCartId == idOnlineCart)
                        {
                            prodc.DeleteProduct(item.Id);
                        }
                    }
                    foreach (var item in loc)
                    {
                        if(item.OnlineCartId == idOnlineCart)
                        {
                            oc.DeleteOrder(item.Id);
                        }
                    }
                    OnlineCart deleted = db.OnlineCarts.Find(idOnlineCart);
                    db.OnlineCarts.Remove(deleted);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }




            }

        }

        public virtual List<OnlineCart> GetOnlineCartList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.OnlineCarts.ToList<OnlineCart>();
            }


        }

        public virtual bool InsertOnlineCart(OnlineCart f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.OnlineCarts.Add(f);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }


            }



        }

        public virtual bool UpdateOnlineCart(OnlineCart f, int idOnlineCart)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    OnlineCart ff = db.OnlineCarts.Find(idOnlineCart);
                    ff.NumberOfArticles = f.NumberOfArticles;
                    
                   
                    ff.Price = f.Price;
                    
                    db.SaveChanges();
                    return true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;

                }


            }



        }

        public virtual OnlineCart GetOnlineCartById(int idOnlineCart)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.OnlineCarts.Find(idOnlineCart);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    return null;
                }


            }


        }


    }
}
