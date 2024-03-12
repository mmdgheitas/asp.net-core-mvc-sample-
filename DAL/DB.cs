using be;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DB : IdentityDbContext<user>
    {
        public DB(DbContextOptions<DB> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CKS6PG0;Initial Catalog=Store;multipleactiveresultsets=True;Integrated Security=true;Encrypt=False;Trust Server Certificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Items> items { get; set; }
        public DbSet<Sold> solds { get; set; }
        public DbSet<Votes> votes { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Likes> likes { get; set; }
        public DbSet<codeTakhfif> codeTakhfif { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<index> index { get; set; }

        //delete
        public DbSet<Items_delete> itemsDelete { get; set; }

        public DbSet<Sold_delete> soldsDelete { get; set; }
        public DbSet<Votes_delete> votesDelete { get; set; }
        public DbSet<Cart_delete> CartDelete { get; set; }
        public DbSet<Likes_delete> likesDelete { get; set; }
        public DbSet<codeTakhfif_delete> codeTakhfifDelete { get; set; }
        public DbSet<Notification_delete> NotificationDelete { get; set; }
    }
}