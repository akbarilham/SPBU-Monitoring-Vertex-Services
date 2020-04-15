using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class Tank {

        public int? id { get; set; }
        [Key]
        public int? site_id { get; set; }
        
        public int? tank_id { get; set; }
        public int? grade_id { get; set; }
        public string tank_name { get; set; }
        public int? tank_number { get; set; }
        public string tank_description { get; set; }
        public string physical_label { get; set; }
        public double? capacity { get; set; }
        public double? gauge_level { get; set; }
        public double? temperature { get; set; }
        public double? gauge_tc_volume { get; set; }
        public double? water_level { get; set; }
        public double? dip_level { get; set; }
        public double? gauge_volume { get; set; }
        public double? theoretical_volume { get; set; }
        public double? dip_volume { get; set; }
        public double? average_cost { get; set; }
        public int? strapped_tank_id { get; set; }
        public int? probe_number { get; set; }
        public double? ullage { get; set; }
        public double? water_volume { get; set; }
        public string gauge_alarms { get; set; }
        public double? diameter { get; set; }
        public double? low_volume_warning { get; set; }
        public double? low_volume_alarm { get; set; }
        public double? hi_volume_warning { get; set; }
        public double? hi_volume_alarm { get; set; }
        public double? hi_water_alarm { get; set; }
        public double? density { get; set; }
        public int? tank_gauge_id { get; set; }
        public int? tank_type_id { get; set; }
        public int? tank_connection_type_id { get; set; }
        public int? tank_probe_status_id { get; set; }
        public string tank_readings_dt { get; set; }
        public int? tank_delivery_state_id { get; set; }
        public int? pump_delivery_state { get; set; }
        public double? hi_temperature { get; set; }
        public double? low_temperature { get; set; }
        public double? loss_tolerance_vol { get; set; }
        public double? gain_tolerance_vol { get; set; }
        public int? deleted { get; set; }
        public int? auto_disable { get; set; }
        public int? is_enabled { get; set; }
        public int? monitoring_status { get; set; }
        public string monitoring_status_name { get; set; }
        //[NotMapped]
        //public DateTime? monitoring_updated_on { get; set; }

        public ICollection<Printer> Printers { get; set; }

    }
}
