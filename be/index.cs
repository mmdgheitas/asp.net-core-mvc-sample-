using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class index
    {
        public int id { get; set; }
        public string banner1 { get; set; }
        public string src_banner1 { get; set; }
        public string banner2 { get; set; }
        public string src_banner2 { get; set; }
        public string banner3 { get; set; }
        public string src_banner3 { get; set; }
        public string footer1 { get; set; }
        public string src_footer1 { get; set; }
        public string footer2 { get; set; }
        public string src_footer2 { get; set; }
        public string vec1 { get; set; }
        public string vec2 { get; set; }
        public string vec3 { get; set; }
        public string vec4 { get; set; }
        public string vec5 { get; set; }
        public string vec6 { get; set; }

        public DateTime create_date { set; get; }
        public DateTime update_date { set; get; }
        public string? userId { get; set; }
        public user? user { get; set; }

        public index()
        {
            create_date = DateTime.Now;
            update_date = DateTime.Now;
        }
    }
}