using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class Dashboards {

        public int Id { get; set; }
        public string SPBUCode { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime LastReadingTime { get; set; }
        public string Status { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public DateTime DeletedAt { get; set; }

    }
}
