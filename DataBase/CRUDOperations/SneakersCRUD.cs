using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class SneakersCRUD
    {
        public SneakersCRUD()
        {

        }

        public virtual bool DeleteSneakers(int idBall)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {


                    Product deleted = db.Products.Find(idBall);
                    db.Products.Remove(deleted);
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

        public virtual List<Sneakers> GetSneakersList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Set<Sneakers>().ToList();
            }


        }

        public virtual bool InsertSneakers(Sneakers f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.Products.Add(f);
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

        public virtual bool UpdateSneakers(Sneakers f, int idSneakers)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Product ff = db.Products.Find(idSneakers);
                    ff.Name = f.Name;
                    ff.Price = f.Price;
                  
                    ff.CustomerJMBG = ff.CustomerJMBG;
                  
                    ff.FactoryId = ff.FactoryId;
                 
                    ff.OnlineCartId = ff.OnlineCartId;
                    ((Sneakers)ff).Size = f.Size;

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

        public virtual Sneakers GetSneakersById(int idSneakers)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Set<Sneakers>().Find(idSneakers);

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
