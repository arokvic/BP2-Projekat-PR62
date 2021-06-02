using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class CustomerCRUD
    {

        public CustomerCRUD()
        {

        }


        public virtual bool DeleteCustomer(double idCustomer)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {

                    PaymentCardCRUD pc = new PaymentCardCRUD();
                    OrderCRUD oc = new OrderCRUD();
                    ProductCRUD prodc = new ProductCRUD();
                    List<Product> l = prodc.GetProductList();
                    List<Order> loc = oc.GetOrderList();
                    List<PaymentCard> lpc = pc.GetPaymentCardList();
                    foreach (var item in l)
                    {

                        if (item.CustomerJMBG == idCustomer)
                        {
                            prodc.DeleteProduct(item.Id);

                        }
                    }
                    foreach (var item in loc)
                    {
                        if (item.CustomerJMBG == idCustomer)
                        {
                            oc.DeleteOrder(item.Id);
                        }
                    }
                    foreach (var item in lpc)
                    {
                        if (item.CustomerJMBG == idCustomer)
                        {
                            pc.DeletePaymentCard(item.AccountNumber);
                        }
                    }


                    Customer deleted = db.Customers.Find(idCustomer);
                    db.Customers.Remove(deleted);
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

        public virtual List<Customer> GetCustomerList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Customers.ToList<Customer>();
            }


        }

        public virtual bool InsertCustomer(Customer f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.Customers.Add(f);
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

        public virtual bool UpdateCustomer(Customer f, long idCustomer)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Customer ff = db.Customers.Find(idCustomer);
                    ff.FirstName = f.FirstName;
                    ff.LastName = f.LastName;
                  
                   
                  
                    ff.Sex = f.Sex;
                    
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

        public virtual Customer GetCustomerById(int idCustomer)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Customers.Find(idCustomer);

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
