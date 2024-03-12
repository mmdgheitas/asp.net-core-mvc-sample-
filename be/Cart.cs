//using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be
{
    //[Keyless]
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("user")]
        public string usersId { get; set; }

        public user users { set; get; }

        [ForeignKey("Items")]
        public int ItemsId { get; set; }

        public Items items { set; get; }

        public int count { set; get; }

        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }

        public Cart()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}