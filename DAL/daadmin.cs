using be;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DAL
{
    public class daadmin
    {
        private readonly DB db;

        public daadmin()
        {
            DbContextOptionsBuilder<DB> optionsBuilder = new DbContextOptionsBuilder<DB>();
            db = new DB(optionsBuilder.Options);
        }

        public user findUser(string id)
        {
            var r = from i in db.Users where i.Id == id select i;
            return r.Single();
        }

        public async Task<bool> addNotification(string not)
        {
            try
            {
                Notification notif = new Notification();
                notif.content = not;
                db.Notification.Add(notif);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> addCodeTakhfif(string code)
        {
            try
            {
                codeTakhfif codeTakhfif = new codeTakhfif();
                codeTakhfif.code = code;
                db.codeTakhfif.Add(codeTakhfif);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public be.index addIndex(string[] obj, user user)
        {
            be.index index = new be.index();
            index.userId = user.Id;
            foreach (var i in obj)
            {
                if (i.Contains("banner1"))
                {
                    index.banner1 = i.Split('*')[0];
                    index.src_banner1 = i.Split('*')[1];
                }
                else if (i.Contains("banner2"))
                {
                    index.banner2 = i.Split('*')[0];
                    index.src_banner2 = i.Split('*')[1];
                }
                else if (i.Contains("banner3"))
                {
                    index.banner3 = i.Split('*')[0];
                    index.src_banner3 = i.Split('*')[1];
                }
                else if (i.Contains("footer1"))
                {
                    index.footer1 = i.Split('*')[0];
                    index.src_footer1 = i.Split('*')[1];
                }
                else if (i.Contains("footer2"))
                {
                    index.footer2 = i.Split('*')[0];
                    index.src_footer2 = i.Split('*')[1];
                }
                else if (i.Contains("vec1"))
                {
                    index.vec1 = i;
                }
                else if (i.Contains("vec2"))
                {
                    index.vec2 = i;
                }
                else if (i.Contains("vec3"))
                {
                    index.vec3 = i;
                }
                else if (i.Contains("vec4"))
                {
                    index.vec4 = i;
                }
                else if (i.Contains("vec5"))
                {
                    index.vec5 = i;
                }
                else if (i.Contains("vec6"))
                {
                    index.vec6 = i;
                }
            }
            db.index.Add(index);
            db.SaveChanges();
            var q = from i in db.index select i;
            return q.ToList().Last();
        }

        public bool addToCart(string Id, int id)
        {
            Cart cart = new Cart
            {
                ItemsId = id,
                usersId = Id
            };
            db.Cart.Add(cart);
            db.SaveChanges();
            return true;
        }

        public bool addToLikes(string Id, int id)
        {
            Likes like = new Likes
            {
                user = Id,
                item = id
            };
            db.likes.Add(like);
            db.SaveChanges();
            return true;
        }

        public bool AddItems(Items item)
        {
            db.items.Add(item);
            db.SaveChanges();
            return true;
        }

        public bool DeleteItems(int id)
        {
            IQueryable<Items> q = db.items.Where(i => i.Id == id);
            Items_delete item = new Items_delete();
            item.pris = q.Single().pris;
            item.exist = q.Single().exist;
            item.fieInBox = q.Single().fieInBox;
            item.brand = q.Single().brand;
            item.code_mahsoul = q.Single().code_mahsoul;
            item.name = q.Single().name;
            item.sellerName = q.Single().sellerName;
            item.createTime = q.Single().createTime;
            item.detail = q.Single().detail;
            item.img_src = q.Single().img_src;
            item.warrantyTime = q.Single().warrantyTime;
            item.warranty = q.Single().warranty;
            item.userId = q.Single().userId;
            item.updateTime = q.Single().updateTime;
            item.percent = q.Single().percent;
            db.itemsDelete.Add(item);
            db.items.Remove(q.Single());
            db.SaveChanges();
            return true;
        }

        public bool DeleteCart(string h, int id)
        {
            try
            {
                var q = db.Cart.Where(i => i.ItemsId == id && i.usersId == h);
                Cart_delete cart_Delete = new Cart_delete();
                cart_Delete.usersId = q.Single().usersId;
                cart_Delete.users = q.Single().users;
                cart_Delete.ItemsId = q.Single().ItemsId;
                cart_Delete.items = q.Single().items;
                cart_Delete.count = q.Single().count;
                cart_Delete.createTime = q.Single().createTime;
                db.CartDelete.Add(cart_Delete);
                db.Cart.Remove(q.Single());
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Items find(string code)
        {
            IQueryable<Items> q = db.items.Where(i => i.Id.ToString() == code);
            return q.Single();
        }

        public int GetAllItems()
        {
            int q = db.items.Count();
            int c;
            if (q % 20 == 0)
            {
                c = q / 20;
            }
            else
            {
                c = q / 20 + 1;
            }
            return c;
        }

        public int GetAllSolds()
        {
            int q = db.solds.Count();
            int c;
            if (q % 10 == 0)
            {
                c = q;
            }
            else
            {
                c = q / 10 + 1;
            }
            return c;
        }

        public int GetAllVotes()
        {
            int q = db.votes.Count();
            int c;
            if (q % 10 == 0)
            {
                c = q;
            }
            else
            {
                c = q / 10 + 1;
            }
            return c;
        }

        public List<Votes> GetVotes()
        {
            return db.votes.ToList();
        }

        public string? GenrateFactorID(int a = 8)
        {
            IQueryable<string> q = from i in db.solds select i.FactorId;
            Random random = new Random();
            const string random_str = "0123456789";
            string r = new string(Enumerable.Repeat(random_str, a)
              .Select(random_str => random_str[random.Next(random_str.Length)]).ToArray());
            if (!q.Contains(r))
            {
                return r;
            }
            else
            {
                GenrateFactorID();
            }

            return null;
        }

        public Sold Pay(int id)
        {
            IQueryable<Items> q = from i in db.items where i.Id == id select i;
            Sold qq = new Sold();
            qq.pay = true;
            return qq;
        }

        public List<be.Sold> ReadAllSolds()
        {
            IQueryable<Sold> q = from i in db.solds select i;
            return q.Include(c => c.customer).ToList();
        }

        public List<be.Items> ReadAllItems()
        {
            IQueryable<Items> q = from i in db.items select i;
            return q.ToList();
        }

        public be.Items Read_By_id(int id)
        {
            IQueryable<Items> q = from i in db.items where i.Id == id select i;
            return q.Include(i => i.votes.Where(i => i.ok == true)).Single();
        }

        public List<be.Items> ReadCart(List<string> c, string Id)
        {
            List<be.Items> cart = new List<Items>();
            if (Id != null)
            {
                IQueryable<Cart> q = from i in db.Cart where i.usersId == Id select i;
                foreach (Cart? j in q.ToList())
                {
                    IQueryable<Items> qq = from i in db.items where i.Id == j.ItemsId select i;
                    Items item = new Items();
                    item = qq.Single();
                    cart.Add(item);
                }
                return cart;
            }
            else
            {
                List<int> cart2 = new List<int>();
                foreach (string j in c)
                {
                    int a;
                    if (int.TryParse(j.Split('/')[0], out a))
                    {
                        IQueryable<Items> q = from i in db.items where i.Id == a select i;
                        if (q.Count() == 1)
                        {
                            Items i = new Items();
                            i = q.Single();
                            cart.Add(i);
                        }
                    }
                }
                return cart;
            }
        }

        public List<be.codeTakhfif> ReadcodeTakhfif()
        {
            var q = from i in db.codeTakhfif select i;
            return q.ToList();
        }

        public be.index readIndex()
        {
            var q = from i in db.index select i;
            return q.ToList().Last();
        }

        public List<be.Items>? Readlikes(string Id)
        {
            List<be.Items> likes = new List<Items>();
            if (Id != null)
            {
                IQueryable<Likes> q = from i in db.likes where i.user == Id select i;
                foreach (Likes? j in q.ToList())
                {
                    IQueryable<Items> qq = from i in db.items where i.Id == j.item select i;
                    Items item = new Items();
                    item = qq.Single();
                    likes.Add(item);
                }
                return likes;
            }
            else
                return null;
        }

        public List<be.Notification> ReadNotification()
        {
            var q = from i in db.Notification select i;
            return q.ToList();
        }

        public string Sabt(string Id, int id, string vv)
        {
            Votes v = new Votes
            {
                text = vv,
                ok = false,
                admin = false,
                ItemsId = id,
                userId = Id
            };

            db.Add(v);
            db.SaveChanges();
            return "ok";
        }

        public bool Save_Solds(List<Sold> s, string f)
        {
            var q = from i in db.solds where (i.customer.Id == s.Last().customer.Id && i.pay == false) select i;

            foreach (Sold i in s)
            {
                var qq = from j in q where (j.items.Id == i.items.Id) select j;
                if (qq.Count() != 0)
                {
                    foreach (Sold j in q.ToList())
                    {
                        j.price = i.price;
                        j.tedad = i.tedad;
                        j.updateTime = DateTime.Now;
                    }
                }
                else
                {
                    i.pay = false;
                    i.FactorId = f;
                    db.solds.Add(i);
                }
            }
            db.SaveChanges();
            return true;
        }

        public List<be.Items>? search(string item)
        {
            if (item == null) { return null; }
            IQueryable<Items> q = from i in db.items where (i.name.Contains(item) || i.detail.Contains(item) || i.category.Contains(item)) select i;
            if (item == "موجود")
            {
                IQueryable<Items> qq = from i in db.items where (i.exist == true) select i;
                return qq.ToList();
            }
            return q.ToList();
        }

        public List<Sold> Solds(string u, string p)
        {
            var q = db.solds.Where(i => i.customer.UserName == u && i.customer.pass == p)
                .Include(c => c.items)
                .Include(u => u.customer)
                .ToList();
            return q;
        }

        public List<be.Items> SkipItems(int s)
        {
            IQueryable<Items> q = db.items.Skip(s).Take(20);
            return q.ToList();
        }

        public List<be.Items> SkipSellerItems(int s, string id)
        {
            IQueryable<Items> all = db.items.Where(i => i.userId == id);
            IQueryable<Items> q = all.Skip(s).Take(20);
            return q.ToList();
        }

        public List<be.Sold> SkipSolds(int s)
        {
            IQueryable<Sold> q = db.solds.Skip(s).Take(10).Include(u => u.customer).Include(i => i.items);
            return q.ToList();
        }

        public List<be.Votes> SkipVotes(int s)
        {
            IQueryable<Votes> q = db.votes.Where(i => i.ok == false && i.admin == false && i.seen == false).Skip(s).Take(20);
            return q.ToList();
        }

        public List<Sold> Success_Profile(string factorId)
        {
            IQueryable<Sold> q = from i in db.solds where i.FactorId == factorId select i;
            return q.ToList();
        }

        public Sold success_Public(int id)
        {
            IQueryable<Sold> q = from i in db.solds where i.id == id select i;
            return q.Single();
        }

        public bool UpdateItems(Items ii)
        {
            IQueryable<Items> q = from i in db.items where i.Id == ii.Id select i;
            Items item = new Items();
            item = q.Single();
            item.name = ii.name;
            item.code_mahsoul = ii.code_mahsoul;
            item.brand = ii.brand;
            item.detail = ii.detail;
            item.exist = ii.exist;
            item.img_src = ii.img_src == null ? item.img_src = item.img_src : item.img_src = ii.img_src;
            item.pris = ii.pris;
            item.fieInBox = ii.fieInBox;
            item.warranty = ii.warranty;
            item.category = ii.category;
            item.warrantyTime = ii.warrantyTime;
            item.sellerName = ii.sellerName;
            item.percent = ii.percent;
            item.updateTime = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public bool UpdateSolds(List<Sold> s, user? user)
        {
            IQueryable<int> q = from i in db.solds where i.FactorId == s.Last().FactorId select i.id;
            if (user != null)
            {
                foreach (int i in q.ToList())
                {
                    IQueryable<Sold> qq = from j in db.solds where j.id == i select j;
                    Sold ss = new Sold();
                    ss = qq.Single();
                    ss.id_get = s.Last().id_get;
                    ss.trans_id = s.Last().trans_id;
                    ss.pay = s.Last().pay;
                    ss.updateTime = DateTime.Now;
                }
            }
            else
            {
                foreach (int i in q.ToList())
                {
                    IQueryable<Sold> qq = from j in db.solds where j.id == i select j;
                    Sold ss = new Sold();
                    ss = qq.Single();
                    ss.customer = user;
                    ss.updateTime = DateTime.Now;
                }
            }
            db.SaveChanges();
            return true;
        }

        public bool UpdateSolds(int id, bool status)
        {
            IQueryable<Sold> q = from i in db.solds where i.id == id select i;
            if (status)
            {
                q.Single().status += 1;
            }
            else
            {
            }
            db.SaveChanges();
            return true;
        }

        public bool takhfifDelete(int id)
        {
            try
            {
                IQueryable<codeTakhfif> q = from i in db.codeTakhfif where i.id == id select i;
                codeTakhfif_delete ctd = new codeTakhfif_delete();
                ctd.code = q.Single().code;
                ctd.users = q.Single().users;
                ctd.update_time = DateTime.Now;
                ctd.create_time = q.Single().create_time;
                ctd.items = q.Single().items;
                db.codeTakhfifDelete.Add(ctd);
                db.codeTakhfif.Remove(q.Single());
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void updataVotes(int id, bool status)
        {
            var q = from i in db.votes where i.id == id select i;
            q.Single().seen = true;
            q.Single().ok = status;
            q.Single().updateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}