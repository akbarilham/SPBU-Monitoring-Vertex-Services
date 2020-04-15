using System;

namespace SPBUMonitoringServices.Models.Responses {

    public class EdcStatus {

        public string site_id { get; set; }
        public dynamic[] printer { get; set; }

    }
}
