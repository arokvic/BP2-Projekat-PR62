using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.CRUDOperations
{
    public class FactoryCRUD
    {

        public FactoryCRUD()
        {

        }

        public virtual bool DeleteFactory(int idFactory)
        {
            using (var db = new InternetSaleDBContext()) {

                try
                {

                    ProductCRUD pc = new ProductCRUD();
                    Factory deleted = db.Factories.Find(idFactory);
                    List<Product> l = pc.GetProductList();
                    foreach (var item in l)
                    {
                        if (item.FactoryId == idFactory)
                        {
                            pc.DeleteProduct(item.Id);

                        }
                    }
                    db.Factories.Remove(deleted);
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

        public virtual List<Factory> GetFactoryList()
        {
            using (var db = new InternetSaleDBContext())
            {
                return db.Factories.ToList<Factory>();
            }


        }

        public virtual bool InsertFactory(Factory f)
        {

            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    db.Factories.Add(f);
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

        public virtual bool UpdateFactory(Factory f, int idFactory)
        {
            using (var db = new InternetSaleDBContext())
            {

                try
                {



                    Factory ff = db.Factories.Find(idFactory);
                    ff.City = f.City;
                    ff.Name = f.Name;
                    
                    db.SaveChanges();
                    return true;

                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return false;

                }


            }



        }

        public virtual Factory GetFactoryById(int idFactory)
        {
            using (var db = new InternetSaleDBContext())
            {
                try
                {
                    return db.Factories.Find(idFactory);

                }
                catch(Exception e)
                {

                    Console.WriteLine(e);
                    return null;
                }


            }


        }


    }
}
