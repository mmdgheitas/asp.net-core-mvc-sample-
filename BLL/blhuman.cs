using be;
using DAL;

namespace BLL
{
    public class blhuman
    {
        private readonly dahuman dah = new dahuman();

        public string create(user h)
        {
            string r = dah.create(h).ToString();
            return r;
        }

        public string update(user h)
        {
            string r = dah.update(h);
            return r;
        }

        public user login(string username, string password)
        {
            user h = dah.login(username, password);
            return h;
        }

        public user find_by_id(string id)
        {
            user h = dah.find_by_id(id);
            return h;
        }
    }
}