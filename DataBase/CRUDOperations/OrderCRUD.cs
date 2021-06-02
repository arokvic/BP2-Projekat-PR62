using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class OrderCRUD
    {
        public OrderCRUD()
        {

        }

        public virtual bool DeleteOrder(int idOrder)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {


                    Order deleted = db.Orders.Find(idOrder);
                    db.Orders.Remove(deleted);
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

        public virtual List<Order> GetOrderList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Orders.ToList<Order>();
            }


        }

        public virtual bool InsertOrder(Order f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.Orders.Add(f);
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

        public virtual bool UpdateOrder(Order f, int idOrder)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Order ff = db.Orders.Find(idOrder);
                   
                    ff.OnlineCartId = f.OnlineCartId;
                    ff.OrderDate = f.OrderDate;
                  
                    ff.PaymentCardAccountNumber = f.PaymentCardAccountNumber;
                    ff.Price = f.Price;
                    ff.CustomerJMBG = f.CustomerJMBG;
                    ff.ArrivalDate = f.ArrivalDate;
                    

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

        public virtual Order GetOrderById(int idOrder)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Orders.Find(idOrder);

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
