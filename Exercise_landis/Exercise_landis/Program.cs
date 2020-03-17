using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_landis.Model;
using Exercise_landis.Control;


namespace Exercise_landis
{
    class Program
    {
        private static List<EndPoint> endPoints = new List<EndPoint>();
        private static EndPointController endPointController = new EndPointController();


        static void Main(string[] args)
        {
            try
            {
                string option = "";

                while (option != "6")
                {
                    Console.Write("-------------Fleet Manager-------------\n");
                    Console.WriteLine("|Choose an option:                      |\n");
                    Console.WriteLine("|1 - Insert a new EndPoint;             |\n");
                    Console.WriteLine("|2 - Edit an existing EndPoint;         |\n");
                    Console.WriteLine("|3 - Delete an existing EndPoint;       |\n");
                    Console.WriteLine("|4 - List all EndPoints;                |\n");
                    Console.WriteLine("|5 - Find an endpoint by serial number; |\n");
                    Console.WriteLine("|6 - Exit;                              |\n");
                    Console.WriteLine("----------------------------------------\n");

                    option = Console.ReadLine();

                    Console.Clear();

                    switch (option)
                    {
                        case "1":
                            SaveEndPoint(endPoints);
                            break;
                        case "2":
                            EditEndPoint(endPoints);
                            break;
                        case "3":
                            DeleteEndPoint(endPoints);
                            break;
                        case "4":
                            listAllEndPoints(endPoints);
                            break;
                        case "5":
                            FindEndPointBySerial(endPoints);
                            break;
                        case "6":
                            break;
                        default:
                            Console.WriteLine("Option not found! \n");
                            break;

                    }

                    Console.Clear();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();
                
            }
        }

        private static bool IsNumber(string data)
        {
            bool isNumber = false;
            char[] dataList = data.ToCharArray();

            foreach (var item in dataList)
                isNumber = char.IsDigit(item);

            if (!isNumber)
            {
                Console.WriteLine("Invalid value, only integer");
                Console.ReadLine();
            }
            return isNumber;
        }
        

       private static bool VerifySerialExists(string serial, bool errorMsg= true)
       {
            if (endPoints.Exists(p => p.SerialNumber == serial))
                return true;
            else
            {
                if (errorMsg)
                {
                    Console.WriteLine("Serial Number not found");
                    Console.ReadLine();
                }
                return false;
            }
                
        }

        static void SaveEndPoint(List<EndPoint> list)
        {
            try
            {
                int switchStateInt = 0;
                string serialNumber = "", meterModelId = "", meterNumber = "", switchState = "";


                EndPoint endPoint = new EndPoint();
                Console.WriteLine("EndPoint information: \n ");
                Console.WriteLine("- Serial Number: ");
                serialNumber = Console.ReadLine();
                if (!VerifySerialExists(serialNumber, false))
                {
                    endPoint.SerialNumber = serialNumber;
                    Console.WriteLine("- Meter model id (only integer): ");
                    meterModelId = Console.ReadLine();
                    if (IsNumber(meterModelId))
                        endPoint.MeterModelId = Convert.ToInt32(meterModelId);
                    else
                        return;

                    Console.WriteLine("- Meter Number (only integer): ");
                    meterNumber = Console.ReadLine();
                    if (IsNumber(meterNumber))
                        endPoint.MeterNumber = Convert.ToInt32(meterNumber);
                    else
                        return;

                    Console.WriteLine("- Meter fw version: ");
                    endPoint.MeterFwVersion = Console.ReadLine();

                    Console.WriteLine("- Switch State (0) disconnected (1)connected (2) armed : ");
                    switchState = Console.ReadLine();

                    if (IsNumber(switchState))
                    {
                        switchStateInt = Convert.ToInt32(switchState);
                        if (endPoint.IsInputValidState(switchStateInt))
                            endPoint.SwitchState = switchStateInt;
                        else
                            return;
                    }
                    else
                        return;

                    endPoints = endPointController.SaveEndPoint(list, endPoint);
                }
                else
                {
                    Console.WriteLine("Serial Number already exists in memory");
                    Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();

            }
        }

        static void EditEndPoint(List<EndPoint> list)
        {
            try
            {
                EndPoint endPoint = new EndPoint();
                string serial, switchState;
                int switchStateInt = 0;

                Console.WriteLine("Which serial number do you want to edit? \n");
                serial = Console.ReadLine();
                if (VerifySerialExists(serial))
                {
                    Console.WriteLine("- Switch State (0) disconnected (1)connected (2) armed : ");
                    switchState = Console.ReadLine();

                    if (IsNumber(switchState))
                    {
                        switchStateInt = Convert.ToInt32(switchState);
                        if (endPoint.IsInputValidState(switchStateInt))
                            endPoints = endPointController.EditEndPoint(list, serial, switchStateInt);
                        else
                            return;
                    }
                    else
                        return;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();

            }
             
        }

        static void listAllEndPoints(List<EndPoint> list)
        {
            endPointController.DeleteEndPoint(list);
        }

        static void DeleteEndPoint(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to delete? \n");
            string serial = Console.ReadLine();

            endPoints = endPointController.DeleteEndPoint(list, serial);
        }

        static void FindEndPointBySerial(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to find? \n");
            string serial = Console.ReadLine();

            endPointController.FindEndPointBySerial(list, serial);

        }
    }
}
