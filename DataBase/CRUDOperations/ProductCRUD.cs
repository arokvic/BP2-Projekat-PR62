using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class ProductCRUD
    {

        public ProductCRUD()
        {

        }
        public virtual bool DeleteProduct(int idProduct)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {


                    Product deleted = db.Products.Find(idProduct);
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

        public virtual List<Product> GetProductList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Products.ToList<Product>();
            }


        }

        public virtual bool InsertProduct(Product f)
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

        public virtual bool UpdateProduct(Product f, int idProduct)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Product ff = db.Products.Find(idProduct);
                    ff.Name = f.Name;
                 
                    ff.CustomerJMBG = ff.CustomerJMBG;
                 
                    ff.FactoryId = ff.FactoryId;
                  
                    ff.OnlineCartId = ff.OnlineCartId;
                    
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

        public virtual Product GetProductById(int idProduct)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Products.Find(idProduct);

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
