using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class EdcConfig {

        public int site_id { get; set; }
        public dynamic[] printer { get; set; }
        public dynamic[] tank { get; set; }
        public dynamic[] pump { get; set; }

    }
}
