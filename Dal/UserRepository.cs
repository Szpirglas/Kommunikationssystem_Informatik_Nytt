using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal
{
    public class UserRepository : GenericRepository<User>
    {
        public void addUser(User user)
        {

            using (var db = new Entities())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public bool checkUserLogin(string email, string password)
        {
            using (var db = new Entities())
            {
                if (db.User.Any(x => x.Email == email && x.Password == password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<User> getAllUsers()
        {
            using (var db = new Entities())
            {
                return db.User.OrderBy(y => y.Lastname).ToList();

               // db.User.ToList();

            }
        }
    }

}