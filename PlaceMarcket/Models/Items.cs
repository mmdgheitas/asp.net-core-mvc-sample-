using Microsoft.AspNetCore.Http;

namespace store.core.Models
{
    public class Items
    {
        public int id { get; set; }
        public int pris { get; set; }
        public string code_mahsoul { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public IFormFile img_src { get; set; }
        public bool exist { get; set; }
        public string seller_ID { get; set; }
    }
}
