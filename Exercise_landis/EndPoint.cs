﻿using System;

namespace Exercise_landis.Model
{
	public class EndPoint 
	{
        private string serial_number;
        private int meter_model_id;
        private int meter_number;
        private string meter_fw_version;
        private int switch_state;

        public EndPoint (string number, int model_id, int meter_number, string fw_version, int state)
        {
            this.serial_number = number;
            this.meter_model_id = model_id;
            this.meter_number = meter_number;
            this.meter_fw_version = fw_version;
            this.switch_state = state;
        }

        public EndPoint(string number)
        {
            this.serial_number = number;
            this.meter_model_id = 0;
            this.meter_number = 0;
            this.meter_fw_version = "";
            this.switch_state = 0;
        }

        public string Serial_number
        {
            set
            {
                this.serial_number = value;
            }
            get
            {
                return serial_number;
            }
        }
        public int Meter_model_id
        {
            set
            {
                this.meter_model_id = value;
            }
            get
            {
                return meter_model_id;
            }
        }
        public int Meter_number
        {
            set
            {
                this.meter_number = value;
            }
            get
            {
                return meter_number;
            }
        }
        public string Meter_fw_version
        {
            set
            {
                this.meter_fw_version = value;
            }
            get
            {
                return meter_fw_version;
            }
        }
        public string Switch_state
        {
            set
            {
                this.switch_state = value;
            }
            get
            {
                return switch_state;
            }
        }
    }
}
