using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_landis.Model;
using Exercise_landis.Control;


namespace Exercise_landis
{
    /// <summary>
    /// This class contains the main user interface for this exercise 
    /// </summary>
    class Program
    {

        private static List<EndPoint> endPoints = new List<EndPoint>();
        private static EndPointController endPointController = new EndPointController();

        /// <summary>
        /// Show options for user and wait an action
        /// </summary>
        /// <param name="args"></param>
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
     
        /// <summary>
        /// Verify if serial already exists in memory
        /// </summary>
        /// <param name="serial"> string </param>
        /// <param name="errorMsg"> bool </param>
        /// <returns>
        /// boolean
        /// </returns>
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

        /// <summary>
        /// Save endpoint in memory 
        /// </summary>
        /// <param name="list"> lista de endpoints</param>
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
                    if (endPoint.IsNumber(meterModelId))
                        endPoint.MeterModelId = Convert.ToInt32(meterModelId);
                    else
                        return;

                    Console.WriteLine("- Meter Number (only integer): ");
                    meterNumber = Console.ReadLine();
                    if (endPoint.IsNumber(meterNumber))
                        endPoint.MeterNumber = Convert.ToInt32(meterNumber);
                    else
                        return;

                    Console.WriteLine("- Meter fw version: ");
                    endPoint.MeterFwVersion = Console.ReadLine();

                    Console.WriteLine("- Switch State (0) disconnected (1)connected (2) armed : ");
                    switchState = Console.ReadLine();

                    if (endPoint.IsNumber(switchState))
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

        /// <summary>
        /// User can edit an endpoint based on serial number
        /// </summary>
        /// <param name="list"></param>
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

                    if (endPoint.IsNumber(switchState))
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

        /// <summary>
        /// List all endpoints in memory
        /// </summary>
        /// <param name="list"></param>
        static void listAllEndPoints(List<EndPoint> list)
        {
            endPointController.DeleteEndPoint(list);
        }

        /// <summary>
        /// User can delete an endpoint based on serial number
        /// </summary>
        /// <param name="list"></param>
        static void DeleteEndPoint(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to delete? \n");
            string serial = Console.ReadLine();

            endPoints = endPointController.DeleteEndPoint(list, serial);
        }

        /// <summary>
        /// User can find information about an endpoint
        /// </summary>
        /// <param name="list"></param>
        static void FindEndPointBySerial(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to find? \n");
            string serial = Console.ReadLine();

            endPointController.FindEndPointBySerial(list, serial);

        }
    }
}
