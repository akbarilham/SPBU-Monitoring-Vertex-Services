using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SPBUMonitoringServices.Models {

    public class EdcHeartBeat {

        public int Id { get; set; }
        public string site_id { get; set; }
        public DateTime app_datetime { get; set; }
        public DateTime server_datetime { get; set; }

    }
}
