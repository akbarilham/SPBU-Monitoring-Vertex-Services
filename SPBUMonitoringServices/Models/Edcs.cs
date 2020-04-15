using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Models {

    public class Edcs {

        public int Id { get; set; }
        public int site_id { get; set; }
        public int printer_id { get; set; }
        public string printer_address { get; set; }
        public int printer_number { get; set; }
        public int is_enabled { get; set; }
        public int deleted { get; set; }
        public int protocol_type { get; set; }
        public int pump_profile_id { get; set; }
        public int auto_authorise { get; set; }
        public int allow_postpay { get; set; }
        public int allow_preauth { get; set; }
        public int allow_monitor { get; set; }
        public int pump_lights { get; set; }
        public int pump_stacking { get; set; }
        public int pump_auto_stacking { get; set; }
        public int allow_attendant { get; set; }
        public int prof_price_1_level { get; set; }
        public int prof_prive_2_level { get; set; }
        public int site_profile_id { get; set; }
        public int fallback_allow { get; set; }
        public int fallback_automatic { get; set; }
        public int tag_reader_active { get; set; }
        public int attendant_tag_auth { get; set; }
        public int external_tag_auth { get; set; }
        public int stack_size { get; set; }
        public int tank_id { get; set; }
        public int grade_id { get; set; }
        public string tank_name { get; set; }
        public int tank_number { get; set; }
        public string tank_description { get; set; }
        public string physical_label { get; set; }
        public double capacity { get; set; }
        public double gauge_level { get; set; }
        public double temperature { get; set; }
        public double gauge_tc_volume { get; set; }
        public double water_level { get; set; }
        public double dip_level { get; set; }
        public double gauge_volume { get; set; }
        public double theoretical_volume { get; set; }
        public double dip_volume { get; set; }
        public double average_cost { get; set; }
        public int strapped_tank_id { get; set; }
        public int probe_number { get; set; }
        public double ullage { get; set; }
        public double water_volume { get; set; }
        public string gauge_alarms { get; set; }
        public double diameter { get; set; }
        public double low_volume_warning { get; set; }
        public double low_volume_alarm { get; set; }
        public double hi_volume_warning { get; set; }
        public double hi_volume_alarm { get; set; }
        public double hi_water_alarm { get; set; }
        public double density { get; set; }
        public int tank_gauge_id { get; set; }
        public int tank_type_id { get; set; }
        public int tank_connection_type_id { get; set; }
        public int tank_probe_status_id { get; set; }
        public DateTime tank_readings_dt { get; set; }
        public int tank_delivery_state_id { get; set; }
        public int pump_delivery_state { get; set; }
        public double hi_temperature { get; set; }
        public double low_temperature { get; set; }
        public double loss_tolerance_vol { get; set; }
        public double gain_tolerance_vol { get; set; }
        public int auto_disable { get; set; }

    }
}
