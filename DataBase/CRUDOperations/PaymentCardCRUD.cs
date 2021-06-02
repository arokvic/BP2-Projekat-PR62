using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class PaymentCardCRUD
    {
        public PaymentCardCRUD()
        {

        }


        public virtual bool DeletePaymentCard(long idPaymentCard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {
                    OrderCRUD oc = new OrderCRUD();
                    List<Order> loc = oc.GetOrderList();
                    foreach (var item in loc)
                    {
                        if (item.PaymentCardAccountNumber == idPaymentCard)
                        {
                            oc.DeleteOrder(item.Id);
                        }
                    }

                    PaymentCard deleted = db.PaymentCards.Find(idPaymentCard);
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

        public virtual List<PaymentCard> GetPaymentCardList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.PaymentCards.ToList<PaymentCard>();
            }


        }

        public virtual bool InsertPaymentCard(PaymentCard f)
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

        public virtual bool UpdatePaymentCard(PaymentCard f, int idPaymentCard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    PaymentCard ff = db.PaymentCards.Find(idPaymentCard);
                    ff.AccountNumber = f.AccountNumber;
                  
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

        public virtual PaymentCard GetPaymentCardById(int idPaymentCard)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.PaymentCards.Find(idPaymentCard);

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
