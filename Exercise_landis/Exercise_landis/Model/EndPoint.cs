using System;

namespace Exercise_landis.Model
{
	public class EndPoint 
	{
        private string serialNumber;
        private int meterModelId;
        private int meterNumber;
        private string meterFWVersion;
        private int switchState;

        public EndPoint (string number, int modelId, int meterNumber, string fwVersion, int state)
        {
            this.serialNumber = number;
            this.meterModelId = modelId;
            this.meterNumber = meterNumber;
            this.meterFWVersion = fwVersion;
            this.switchState = state;
        }

        public EndPoint()
        {

        }

        public string SerialNumber
        {
            set
            {
                this.serialNumber = value;
            }
            get
            {
                return serialNumber;
            }
        }
        public int MeterModelId
        {
            set
            {
                this.meterModelId = value;
            }
            get
            {
                return meterModelId;
            }
        }
        public int MeterNumber
        {
            set
            {
                this.meterNumber = value;
            }
            get
            {
                return meterNumber;
            }
        }
        public string MeterFwVersion
        {
            set
            {
                this.meterFWVersion = value;
            }
            get
            {
                return meterFWVersion;
            }
        }

        public int SwitchState
        {
            set
            {

                this.switchState = value;
            }
            get
            {
                return switchState;
            }
        }

        public bool IsInputValidState(int state)
        {
            if (state == 0 || state == 1 || state == 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Parameter \n");
                return false;
            }

        }

        public bool IsNumber(string data, bool msgError=true)
        {
            bool isNumber = false;
            char[] dataList = data.ToCharArray();

            foreach (var item in dataList)
                isNumber = char.IsDigit(item);

            if (!isNumber && msgError)
            {
                Console.WriteLine("Invalid value, only integer");
                Console.ReadLine();
            }
            return isNumber;
        }
    }
}
