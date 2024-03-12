using be;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class dahuman
    {
        private readonly DB db;

        public dahuman()
        {
            DbContextOptionsBuilder<DB> optionsBuilder = new DbContextOptionsBuilder<DB>();
            db = new DB(optionsBuilder.Options);
        }

        public string create(user h)
        {
            db.Users.Add(h);
            db.SaveChanges();
            return "ok";
        }

        public string update(user h)
        {
            IQueryable<user> q = db.Users.Where(i => i.Id == h.Id);
            user hh = new user();
            hh = q.Single();
            hh.name = h.name;
            hh.family = h.family;
            hh.pass = h.pass;
            hh.Email = h.Email;
            hh.address = h.address;
            hh.post = h.post;
            hh.PasswordHash = h.PasswordHash;
            hh.UserName = h.UserName;
            hh.mobile = h.mobile;
            db.SaveChanges();
            return "ok";
        }

        public user login(string username, string password)
        {
            IQueryable<user> q = db.Users.Where(i => i.UserName == username && i.PasswordHash == password);
            if (q.Count() == 1)
            {
                user h = q.Single();
                return h;
            }
            else
            {
                user h = null;
                return h;
            }
        }

        public user find_by_id(string id)
        {
            IQueryable<user> q = from i in db.Users where i.Id == id select i;
            user h = q.Single();
            return h;
        }
    }
}