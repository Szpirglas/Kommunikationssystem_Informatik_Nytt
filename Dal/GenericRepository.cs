
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal
{
    public class GenericRepository<T> where T : class
    {

        //läger till en entitet i datbasen 
        //t är entiteten som den ärvande Repositoryklassen använder sig utav .
        //gör att man genom samma metod kan lägga till olika entiteter 
        public void Add(T item)
        {
            try
            {
                using (var db = new Entities())
                {

                    db.Set<T>().Add(item);
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);



            }
        }


        //kollar att användaren har ett login
        //retunerar olika värden för validering 
        //om två retuneras så ska användaren loggas in
       //public int idenityKoll(string epost, string losen)
       // {
       //     try
       //     {

       //         using (var db = new Entities())
       //         {
       //             var passwordCheck = from r in db.Person
       //                                 where r.EPost.Equals(epost)
       //                                 select r.Losenord;
       //             var test = lösenordskoll.SingleOrDefault();
       //             if (String.IsNullOrEmpty(test))
       //             {
       //                 return 0;
       //             }

       //             if (!(test).Equals(losen))
       //             {
       //                 return 1;
       //             }
       //         }
       //         return 2;
       //     }
       //     catch (Exception e)
       //     {

       //         Console.WriteLine(e);
       //         return 0;


       //     }
       // }



    }
}
