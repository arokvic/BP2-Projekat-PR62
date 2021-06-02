using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class JerseyCRUD
    {
        public JerseyCRUD()
        {

        }

        public virtual bool DeleteJersey(int idJersey)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {


                    Product deleted = db.Products.Find(idJersey);
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

        public virtual List<Jersey> GetJerseyList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Set<Jersey>().ToList();
            }


        }

        public virtual bool InsertJersey(Jersey f)
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

        public virtual bool UpdateJersey(Jersey f, int idJersey)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Product ff = db.Products.Find(idJersey);
                    ff.Name = f.Name;
                    ff.Price = f.Price;
                   
                    ff.CustomerJMBG = ff.CustomerJMBG;
                  
                    ff.FactoryId = ff.FactoryId;
                   
                    ff.OnlineCartId = ff.OnlineCartId;
                    ((Jersey)ff).Size = f.Size;
                    ((Jersey)ff).Club = f.Club;

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

        public virtual Jersey GetJerseyById(int idJersey)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Set<Jersey>().Find(idJersey);

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
