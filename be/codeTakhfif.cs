using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class codeTakhfif
    {
        public int id { get; set; }
        public string code { get; set; }
        public user? users { get; set; }
        public Items? items { get; set; }

        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }

        public codeTakhfif()
        {
            code = string.Empty;
            create_time = DateTime.Now;
            update_time = DateTime.Now;
        }
    }
}