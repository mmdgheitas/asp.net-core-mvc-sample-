using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be
{
    public class Votes
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool ok { get; set; }
        public bool admin { get; set; }
        public bool seen { get; set; }

        public int? votesId { get; set; }

        [ForeignKey("Items")]
        public int ItemsId { get; set; }

        public Items Items { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }

        public user user { get; set; }

        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }

        public Votes()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}