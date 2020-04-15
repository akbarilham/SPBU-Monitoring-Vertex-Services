using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class HeartBeat {

        public int Id { get; set; }
        public string site_id { get; set; }
        public DateTime app_datetime { get; set; }
        public DateTime server_datetime { get; set; }

    }
}
