using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public class Notification_delete
    {
        public int id { get; set; }
        public string content { get; set; }
        public user? users { get; set; }

        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }

        public Notification_delete()
        {
            content = string.Empty;
            create_time = DateTime.Now;
            update_time = DateTime.Now;
        }
    }
}