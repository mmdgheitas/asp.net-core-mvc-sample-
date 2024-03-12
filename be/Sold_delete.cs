using System;

namespace be
{
    public class Sold_delete
    {
        public int id { get; set; }
        public string trans_id { get; set; }
        public string id_get { get; set; }
        public string FactorId { get; set; }
        public string code_mahsoul { get; set; }
        public int tedad { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string size { get; set; }

        //public string user_name { get; set; }
        //public string family { get; set; }
        //public string user { get; set; }
        // public string pass { get; set; }
        //public string email { get; set; }
        //public string mobile { get; set; }
        //public string adress { get; set; }
        public string code_posti { get; set; }

        public string color { get; set; }
        public int price { get; set; }
        public bool pay { get; set; }
        //public string seller_id { get; set; }

        public user customer { set; get; }
        public user seller_id { set; get; }

        public DateTime createTime { set; get; }
        public DateTime updateTime { set; get; }
        //public List<Solds_Items> solds_items { set; get; }

        public Sold_delete()
        {
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
        }
    }
}