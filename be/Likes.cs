using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be
{
    public class Likes
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("user")]
        public string user { get; set; }

        public user users { get; set; }

        [ForeignKey("Items")]
        public int item { get; set; }

        public Items Items { get; set; }

        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }

        public Likes()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}