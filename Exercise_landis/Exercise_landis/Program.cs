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

        static void save_endpoint(List<EndPoint> list)
        {
            endPoints = endPointController.save(list);
        }

        static void edit_endpoint(List<EndPoint> list)
        {
            endPoints = endPointController.edit(list);
        }

        static void listall_endpoint(List<EndPoint> list)
        {
            endPointController.list_all(list);
        }

        static void delete_endpoint(List<EndPoint> list)
        {
            endPoints = endPointController.delete(list);
        }

        static void find_endpoint_by_serial(List<EndPoint> list)
        {
            endPointController.find_by_serial(list);
        }
    }
}
