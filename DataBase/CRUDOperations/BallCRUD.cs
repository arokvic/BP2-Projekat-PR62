using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class BallCRUD
    {
        public BallCRUD()
        {

        }

        public virtual bool DeleteBall(int idBall)
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

        public virtual List<Ball> GetBallList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Set<Ball>().ToList();
            }


        }

        public virtual bool InsertBall(Ball f)
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

        public virtual bool UpdateBall(Ball f, int idBall)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Product ff = db.Products.Find(idBall);
                    ff.Name = f.Name;
                    ff.Price = f.Price;
                   
                    ff.CustomerJMBG = ff.CustomerJMBG;
                  
                    ff.FactoryId = ff.FactoryId;
                 
                    ff.OnlineCartId = ff.OnlineCartId;
                    ((Ball)ff).BallType = f.BallType;

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

        public virtual Ball GetBallyById(int idBall)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Set<Ball>().Find(idBall);

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
