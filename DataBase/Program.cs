using DataBase.CRUDOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new InternetSaleDBContext())
            {
                               
                FactoryCRUD fc = new FactoryCRUD();

                Factory f = fc.GetFactoryById(1);

                var B = new Ball()
                {
                    BallType = "Kosarkaska",
                    Name = "Lopta",
                    Factory = fc.GetFactoryById(1),
                    FactoryId = f.Id,
                    




                };

                CustomerCRUD cc = new CustomerCRUD();
                BallCRUD bb = new BallCRUD();
                bb.InsertBall(B);
                //   List<Product> f = fc.GetFactoryList();
               
                

                var query = from b in db.Products
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
               

            }



            Console.ReadKey();
    
        }
    }
}
