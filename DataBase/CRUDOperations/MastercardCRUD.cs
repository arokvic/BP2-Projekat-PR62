using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class MastercardCRUD
    {
        public MastercardCRUD()
        {

        }
        public virtual bool DeleteMastercard(long idMastercard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {
                    OrderCRUD oc = new OrderCRUD();
                    List<Order> loc = oc.GetOrderList();
                    foreach (var item in loc)
                    {
                        if (item.PaymentCardAccountNumber == idMastercard)
                        {
                            oc.DeleteOrder(item.Id);
                        }
                    }

                    PaymentCard deleted = db.PaymentCards.Find(idMastercard);
                    db.PaymentCards.Remove(deleted);
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

        public virtual List<Mastercard> GetMastercardList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Set<Mastercard>().ToList();
            }


        }

        public virtual bool InsertMastercard(Mastercard f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.PaymentCards.Add(f);
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

        public virtual bool UpdateMastercard(Mastercard f, long idMastercard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    PaymentCard ff = db.PaymentCards.Find(idMastercard);
                    ff.CustomerJMBG = f.CustomerJMBG;


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

        public virtual PaymentCard GetMastercardyById(int idMastercard)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.PaymentCards.Find(idMastercard);

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
