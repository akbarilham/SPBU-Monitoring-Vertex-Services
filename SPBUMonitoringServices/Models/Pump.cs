using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class Pump {

        public int? id { get; set; }
        [Key]
        public int site_id { get; set; }
        
        public int pump_profile_id { get; set; }
        public int? pump_profile_pump_id { get; set; }
        public int auto_authorise { get; set; }
        public int allow_postpay { get; set; }
        public int allow_prepay { get; set; }
        public int allow_preauth { get; set; }
        public int allow_monitor { get; set; }
        public int pump_lights { get; set; }
        public int pump_stacking { get; set; }
        public int pump_auto_stacking { get; set; }
        public int allow_attendant { get; set; }
        public int prof_price_1_level { get; set; }
        public int prof_prive_2_level { get; set; }
        public int? site_profile_id { get; set; }
        public int fallback_allow { get; set; }
        public int fallback_automatic { get; set; }
        public int tag_reader_active { get; set; }
        public int attendant_tag_auth { get; set; }
        public int external_tag_auth { get; set; }
        public int stack_size { get; set; }

        public ICollection<Printer> Printers { get; set; }

    }
}
