using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace be
{
    public class user_delete : IdentityUser
    {
        public string? name { get; set; }
        public string? pass { get; set; }
        public string? family { get; set; }
        public string? mobile { get; set; }
        public string? address { get; set; }
        public string? post { get; set; }

        public bool seller { get; set; }

        public string? seller_name { get; set; }
        public string? code_melli { get; set; }
        public int sells { get; set; }
        public string? shomare_cart { get; set; }

        public List<Cart> cart { get; set; }
        public List<Likes> likes { get; set; }

        public List<Votes> votes { get; set; }
        public index? Index { get; set; }
        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }
        //public List<Items> item { get; set; }

        public user_delete()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}