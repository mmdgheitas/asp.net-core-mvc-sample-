using be;
using DAL;
using Microsoft.AspNetCore.Identity;

namespace BLL
{
    public class bladmin
    {
        //ABCDEFGHIJKLMNOPQRSTUWVXYZ
        private readonly daadmin daa = new daadmin();

        public user findUser(string id)
        {
            var r = daa.findUser(id);
            return r;
        }

        public async Task<bool> addNotification(string notif)
        {
            var q = await daa.addNotification(notif);
            return q;
        }

        public async Task<bool> addCodeTakhfif(string code)
        {
            var q = await daa.addCodeTakhfif(code);
            return q;
        }

        public be.index addInex(string[] obj, user user)
        {
            return daa.addIndex(obj, user);
        }

        public bool addToCart(string Id, int id)
        {
            return daa.addToCart(Id, id);
        }

        public bool addToLikes(string Id, int id)
        {
            return daa.addToLikes(Id, id);
        }

        public bool AddItems(Items item)
        {
            return daa.AddItems(item);
        }

        public bool DeleteItems(int id)
        {
            bool r = daa.DeleteItems(id);
            return r;
        }

        public bool DeleteCart(string h, int id)
        {
            bool r = daa.DeleteCart(h, id);
            return r;
        }

        public Items find(string id)
        {
            Items r = daa.find(id);
            return r;
        }

        public int GetAllItems()
        {
            return daa.GetAllItems();
        }

        public int GetAllSolds()
        {
            return daa.GetAllSolds();
        }

        public int GetAllVotes()
        {
            return daa.GetAllVotes();
        }

        public List<be.Votes> GetVotes()
        {
            List<Votes> r = daa.GetVotes();
            return r;
        }

        public string GenrateFactorID()
        {
            string r = daa.GenrateFactorID();
            return r;
        }

        public be.Sold Pay(int id)
        {
            Sold r = daa.Pay(id);
            return r;
        }

        public List<be.Items> ReadAllItems()
        {
            return daa.ReadAllItems();
        }

        public List<be.Sold> ReadAllSolds()
        {
            return daa.ReadAllSolds();
        }

        public be.Items Read_By_id(int id)
        {
            return daa.Read_By_id(id);
        }

        public List<be.Items> ReadCart(List<string> c, string Id)
        {
            return daa.ReadCart(c, Id);
        }

        public be.index readIndex()
        {
            return daa.readIndex();
        }

        public List<be.codeTakhfif> ReadcodeTakhfif()
        {
            List<codeTakhfif> r = daa.ReadcodeTakhfif();
            return r;
        }

        public List<be.Items> Readlikes(string Id)
        {
            return daa.Readlikes(Id);
        }

        public List<be.Notification> ReadNotification()
        {
            List<Notification> r = daa.ReadNotification();
            return r;
        }

        public List<be.Items> search(string item)
        {
            List<Items> q = daa.search(item);
            return q;
        }

        public async Task<List<be.Items>> SkipItems(int s, UserManager<user> userManager, string id)
        {
            return daa.SkipItems(s);
        }

        public List<be.Sold> SkipSolds(int s)
        {
            return daa.SkipSolds(s);
        }

        public List<be.Votes> SkipVotes(int s)
        {
            return daa.SkipVotes(s);
        }

        public string Sabt(string Id, int id, string v)
        {
            string r = daa.Sabt(Id, id, v);
            return r;
        }

        public bool Save_Solds(List<Sold> s, string f)
        {
            bool r = daa.Save_Solds(s, f);
            return r;
        }

        public List<Sold> Solds(string u, string p)
        {
            return daa.Solds(u, p);
        }

        public List<Sold> Success_Profile(string factorId)
        {
            List<Sold> r = daa.Success_Profile(factorId);
            return r;
        }

        public Sold success_Public(int id)
        {
            Sold r = daa.success_Public(id);
            return r;
        }

        public bool UpdateItems(Items i)
        {
            bool r = daa.UpdateItems(i);
            return r;
        }

        public bool UpdateSolds(List<Sold> s, user? user)
        {
            return daa.UpdateSolds(s, user);
        }

        public bool UpdateSolds(int id, bool status)
        {
            return daa.UpdateSolds(id, status);
        }

        public bool takhfifDelete(int id)
        {
            return daa.takhfifDelete(id);
        }

        public void updataVotes(int id, bool status)
        {
            daa.updataVotes(id, status);
        }
    }
}