using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class VisacardCRUD
    {
        public VisacardCRUD()
        {

        }


        public virtual bool DeleteVisacard(long idVisacard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {


                    PaymentCard deleted = db.PaymentCards.Find(idVisacard);
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

        public virtual List<Visacard> GetVisacardList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Set<Visacard>().ToList();
            }


        }

        public virtual bool InsertVisacard(Visacard f)
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

        public virtual bool UpdateVisacard(Visacard f, long idVisacard)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    PaymentCard ff = db.PaymentCards.Find(idVisacard);
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

        public virtual PaymentCard GetVisacardyById(int idVisacard)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.PaymentCards.Find(idVisacard);

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
