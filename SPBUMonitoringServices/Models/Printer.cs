using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class Printer {

        public int? id { get; set; }
        [Key]
        public int site_id { get; set; }
        public int printer_id { get; set; }
        public string printer_address { get; set; }
        public int printer_number { get; set; }
        public int is_enabled { get; set; }
        public int deleted { get; set; }
        public int protocol_type { get; set; }

        [ForeignKey(nameof(site_id))]
        public Tank Tanks { get; set; }
        [ForeignKey(nameof(site_id))]
        public Pump Pumps { get; set; }
    }
}
