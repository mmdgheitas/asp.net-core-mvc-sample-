using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace be
{
    public class Items
    {
        [Key]
        public int Id { get; set; }

        public int pris { get; set; }
        public string? code_mahsoul { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string detail { get; set; }
        public string detail_2 { get; set; }
        public string? category { get; set; }
        public int fieInBox { get; set; }
        public bool warranty { get; set; }
        public int warrantyTime { get; set; }
        public string img_src { get; set; }
        public string sellerName { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public bool exist { get; set; }
        public string userId { get; set; }

        public int percent { get; set; }

        //public user seller_ID { get; set; }
        //public List<user>  { get; set; }
        public List<Cart> cart { get; set; }

        public List<Likes> likes { get; set; }

        public List<Votes> votes { get; set; }

        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }

        //public List<user> user { get; set; }
        //public List<Solds_Items> solds_items { get; set; }

        public Items()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}