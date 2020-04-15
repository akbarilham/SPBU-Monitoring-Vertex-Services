using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;

namespace SPBUMonitoringServices.Repository {

    public class EdcConfigRepository : IEdcConfig {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        EdcConfigContext _context;

        public EdcConfigRepository(EdcConfigContext context) {
            _context = context;
        }       

        public async Task<IEnumerable<Printer>> GetAll() {
           /*
            var sqlScript = $"SELECT DISTINCT printers.id, printers.site_id, printers.printer_id, printers.printer_address, " +
                "printers.is_enabled, printers.protocol_type, pumps.allow_postpay, pumps.allow_prepay, pumps.allow_preauth, pumps.allow_monitor, pumps.pump_lights, " +
                "pumps.pump_stacking, pumps.pump_auto_stacking, pumps.allow_attendant, pumps.prof_price_1_level, pumps.prof_prive_2_level, " +
                "pumps.site_profile_id, pumps.fallback_allow, pumps.fallback_automatic, pumps.tag_reader_active, pumps.attendant_tag_auth, " +
                "pumps.external_tag_auth, pumps.stack_size, tanks.tank_id, tanks.grade_id, tanks.tank_name, tanks.tank_number, tanks.tank_description, " +
                "tanks.physical_label, tanks.capacity, tanks.gauge_level, tanks.temperature, tanks.gauge_tc_volume, tanks.water_level, tanks.dip_level, " +
                "tanks.gauge_volume, tanks.theoretical_volume, tanks.dip_volume, tanks.average_cost, tanks.strapped_tank_id, tanks.probe_number, " +
                "tanks.ullage, tanks.water_volume, tanks.gauge_alarms, tanks.diameter, tanks.low_volume_warning, tanks.low_volume_alarm, " +
                "tanks.hi_volume_warning, tanks.hi_volume_alarm, tanks.density, tanks.tank_gauge_id, tanks.tank_type_id, tanks.tank_connection_type_id, " +
                "tanks.tank_probe_status_id, tanks.tank_readings_dt, tanks.tank_delivery_state_id, tanks.pump_delivery_state, " +
                "tanks.hi_temperature, tanks.low_temperature, tanks.loss_tolerance_vol, tanks.gain_tolerance_vol, tanks.deleted, " +
                "tanks.auto_disable, tanks.is_enabled " +
                "FROM printers INNER JOIN pumps ON printers.site_id = pumps.site_id " +
                "LEFT JOIN tanks ON printers.site_id = tanks.site_id";
            return await _context.printers.FromSql(sqlScript).ToListAsync();
            */
            return await _context.printers
                .Include(p => p.Tanks)
                .Include(p => p.Pumps)
                .ToListAsync();
        }

        public async Task InsertPrinter(int dataSite, dynamic[] dataPrinter) {
            if (dataPrinter != null) {
                try {
                    var dataToInsert = new Printer();
                    for (int number = 0; number < dataPrinter.Length; number++) {
                        dataToInsert.id = null;
                        dataToInsert.site_id = dataSite;
                        dataToInsert.printer_id = dataPrinter[number].Printer_ID;
                        dataToInsert.printer_address = dataPrinter[number].Printer_Address;
                        dataToInsert.is_enabled = dataPrinter[number].Is_Enabled;
                        dataToInsert.deleted = dataPrinter[number].Deleted;
                        dataToInsert.protocol_type = dataPrinter[number].Protocol_Type;
                        Logger.Info("Data printer mashok = " + string.Join(" ", dataToInsert.GetType()
                                    .GetProperties()
                                    .Select(prop => prop.GetValue(dataToInsert))));

                        await _context.printers.AddAsync(dataToInsert);
                        await _context.SaveChangesAsync();
                        Logger.Info("Data printer insert successfully");
                    }
                } catch (Exception ex) {
                    Debug.WriteLine("Insert Printer Data Exception: " + ex.Message);
                    throw;
                }
            }
        }

        public async Task InsertTank(int dataSite, dynamic[] dataTank) {
            if (dataTank != null) {
                try {
                    var dataToInsert = new Tank();
                    for (int number = 0; number < dataTank.Length; number++) {
                        dataToInsert.id = null;
                        dataToInsert.site_id = dataSite;
                        dataToInsert.tank_id = dataTank[number].Tank_ID;
                        dataToInsert.grade_id = dataTank[number].Grade_ID;
                        dataToInsert.tank_name = dataTank[number].Tank_Name;
                        dataToInsert.tank_number = dataTank[number].Tank_Number;
                        dataToInsert.tank_description = dataTank[number].Tank_Description;
                        dataToInsert.physical_label = dataTank[number].Physical_Label;
                        dataToInsert.capacity = dataTank[number].Capacity;
                        dataToInsert.gauge_level = dataTank[number].Gauge_Level;
                        dataToInsert.temperature = dataTank[number].Temperature;
                        dataToInsert.gauge_tc_volume = dataTank[number].Gauge_TC_Volume;
                        dataToInsert.water_level = dataTank[number].Water_Level;
                        dataToInsert.dip_level = dataTank[number].Dip_Level;
                        dataToInsert.gauge_volume = dataTank[number].Gauge_Volume;
                        dataToInsert.theoretical_volume = dataTank[number].Theoretical_Volume;
                        dataToInsert.dip_volume = dataTank[number].Dip_Volume;
                        dataToInsert.average_cost = dataTank[number].Average_Cost;
                        dataToInsert.strapped_tank_id = dataTank[number].Strapped_Tank_ID;
                        dataToInsert.probe_number = dataTank[number].Probe_Number;
                        dataToInsert.ullage = dataTank[number].Ullage;
                        dataToInsert.water_volume = dataTank[number].Water_Volume;
                        dataToInsert.gauge_alarms = dataTank[number].Gauge_alarms;
                        dataToInsert.diameter = dataTank[number].Diameter;
                        dataToInsert.low_volume_warning = dataTank[number].Low_Volume_Warning;
                        dataToInsert.low_volume_alarm = dataTank[number].Low_Volume_Alarm;
                        dataToInsert.hi_volume_warning = dataTank[number].Hi_Volume_Warning;
                        dataToInsert.hi_volume_alarm = dataTank[number].Hi_Volume_Alarm;
                        dataToInsert.hi_water_alarm = dataTank[number].Hi_Water_Alarm;
                        dataToInsert.density = dataTank[number].Density;
                        dataToInsert.tank_gauge_id = dataTank[number].Tank_Gauge_ID;
                        dataToInsert.tank_type_id = dataTank[number].Tank_Type_ID;
                        dataToInsert.tank_connection_type_id = dataTank[number].Tank_Connection_Type_ID;
                        dataToInsert.tank_probe_status_id = dataTank[number].Tank_Probe_Status_ID;
                        dataToInsert.tank_readings_dt = dataTank[number].Tank_Readings_DT;
                        dataToInsert.tank_delivery_state_id = dataTank[number].Tank_Delivery_State_ID;
                        dataToInsert.pump_delivery_state = dataTank[number].Pump_Delivery_State;
                        dataToInsert.hi_temperature = dataTank[number].Hi_Temperature;
                        dataToInsert.low_temperature = dataTank[number].Low_Temperature;
                        dataToInsert.loss_tolerance_vol = dataTank[number].Loss_Tolerance_Vol;
                        dataToInsert.gain_tolerance_vol = dataTank[number].Gain_Tolerance_Vol;
                        dataToInsert.deleted = dataTank[number].Deleted;
                        dataToInsert.auto_disable = dataTank[number].Auto_Disable;
                        dataToInsert.is_enabled = dataTank[number].Is_Enabled;
                        dataToInsert.monitoring_status = dataTank[number].monitoring_status;
                        dataToInsert.monitoring_status_name = dataTank[number].monitoring_status_name;
                        //dataToInsert.monitoring_updated_on = dataTank[number].monitoring_updated_on;
                        Logger.Info("Data tank mashok = " + string.Join(" ", dataToInsert.GetType()
                                    .GetProperties()
                                    .Select(prop => prop.GetValue(dataToInsert))));

                        await _context.tanks.AddAsync(dataToInsert);
                        await _context.SaveChangesAsync();
                        Logger.Info("Data tank insert successfully");
                    }
                } catch (Exception ex) {
                    Debug.WriteLine("Insert Tank Data Exception: " + ex.Message);
                    throw;
                }
            }
        }

        public async Task InsertPump(int dataSite, dynamic[] dataPump) {
            if (dataPump != null) {
                try {
                    var dataToInsert = new Pump();
                    for (int number = 0; number < dataPump.Length; number++) {
                        dataToInsert.id = null;
                        dataToInsert.site_id = dataSite;
                        dataToInsert.pump_profile_id = dataPump[number].Pump_Profile_ID;
                        dataToInsert.pump_profile_pump_id = dataPump[number].Pump_Profile_Pump_ID;
                        dataToInsert.auto_authorise = dataPump[number].Auto_Authorise;
                        dataToInsert.allow_postpay = dataPump[number].Allow_Postpay;
                        dataToInsert.allow_prepay = dataPump[number].Allow_Prepay;
                        dataToInsert.allow_preauth = dataPump[number].Allow_Preauth;
                        dataToInsert.allow_monitor = dataPump[number].Allow_Monitor;
                        dataToInsert.pump_lights = dataPump[number].Pump_Lights;
                        dataToInsert.pump_stacking = dataPump[number].Pump_Stacking;
                        dataToInsert.pump_auto_stacking = dataPump[number].Pump_Auto_Stacking;
                        dataToInsert.allow_attendant = dataPump[number].Allow_Attendant;
                        dataToInsert.prof_price_1_level = dataPump[number].prof_Price_1_Level;
                        dataToInsert.prof_prive_2_level = dataPump[number].prof_Price_2_Level;
                        dataToInsert.site_profile_id = dataPump[number].Site_Profile_ID;
                        dataToInsert.fallback_allow = dataPump[number].Fallback_allow;
                        dataToInsert.fallback_automatic = dataPump[number].Fallback_automatic;
                        dataToInsert.tag_reader_active = dataPump[number].Tag_Reader_Active;
                        dataToInsert.attendant_tag_auth = dataPump[number].Attendant_Tag_Auth;
                        dataToInsert.external_tag_auth = dataPump[number].External_Tag_Auth;
                        dataToInsert.stack_size = dataPump[number].Stack_Size;
                        Logger.Info("Data pump mashok = " + string.Join(" ", dataToInsert.GetType()
                                    .GetProperties()
                                    .Select(prop => prop.GetValue(dataToInsert))));

                        await _context.pumps.AddAsync(dataToInsert);
                        await _context.SaveChangesAsync();
                        Logger.Info("Data pump inserted");
                    }
                } catch (Exception ex) {
                    Debug.WriteLine("Insert Pump Data Exception: " + ex.Message);
                    throw;
                }
            }
        }

    }
}