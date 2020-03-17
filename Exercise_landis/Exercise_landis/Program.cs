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
        static List<EndPoint> endPoints = new List<EndPoint>();
        static EndPointController endPointController = new EndPointController();


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
                            save_endpoint(endPoints);
                            break;
                        case "2":
                            edit_endpoint(endPoints);
                            break;
                        case "3":
                            delete_endpoint(endPoints);
                            break;
                        case "4":
                            listall_endpoint(endPoints);
                            break;
                        case "5":
                            find_endpoint_by_serial(endPoints);
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

       static int verify_input(EndPoint endPoint, string tipo)
        {
            if (tipo == "state")
            {
                Console.WriteLine("- Switch State - (0)disconnect (1)connect (2)Armed: ");
            }

            string state = Console.ReadLine();
            while (!endPoint.verify_input(state, tipo))
                state = Console.ReadLine();

            int input = Convert.ToInt32(state);
            return input;

        }

        static bool verify_serial(string serial)
        {
            if (endPoints.Exists(p => p.Serial_number == serial))
                return true;
            else
            {
                Console.WriteLine("Serial Number not found");
                Console.ReadLine();
                return false;
            }
                
        }

        static void save_endpoint(List<EndPoint> list)
        {
            EndPoint endPoint = new EndPoint();
            Console.WriteLine("EndPoint information: \n ");
            Console.WriteLine("- Serial Number: ");
            endPoint.Serial_number = Console.ReadLine();
            Console.WriteLine("- Meter model id: ");
            endPoint.Meter_model_id = verify_input(endPoint, "model id");
            Console.WriteLine("- Meter Number: ");
            endPoint.Meter_number = verify_input(endPoint, "meter number");
            Console.WriteLine("- Meter fw version: ");
            endPoint.Meter_fw_version = Console.ReadLine();

            endPoint.Switch_state = verify_input(endPoint, "state");

            endPoints = endPointController.save(list, endPoint);
        }

        static void edit_endpoint(List<EndPoint> list)
        {
            EndPoint endPoint = new EndPoint();
            string serial;
            int state;

            Console.WriteLine("Which serial number do you want to edit? \n");
            serial = Console.ReadLine();
            if (verify_serial(serial))
            {
                state = verify_input(endPoint, "state");
                endPoints = endPointController.edit(list, serial, state);
            }
            
        }

        static void listall_endpoint(List<EndPoint> list)
        {
            endPointController.list_all(list);
        }

        static void delete_endpoint(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to delete? \n");
            string serial = Console.ReadLine();

            endPoints = endPointController.delete(list, serial);
        }

        static void find_endpoint_by_serial(List<EndPoint> list)
        {

            Console.WriteLine("Which serial number do you want to find? \n");
            string serial = Console.ReadLine();

            endPointController.find_by_serial(list, serial);

        }
    }
}
