using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Otaku.Models
{
    public class Status
    {
        public int ID { get; set; }

        [DisplayName("Status")]
        public string ProgressionStatus { get; set; }
    }
}
