using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_landis.Model;

namespace Exercise_landis.Control
{
    class EndPointController
    {

        public List<EndPoint> save (List <EndPoint> endPoints)
        {
            try
            {
                Console.Clear();

                EndPoint endPoint = new EndPoint();
                Console.WriteLine("EndPoint information: \n ");
                Console.WriteLine("- Serial Number: ");
                endPoint.Serial_number = Console.ReadLine();
                Console.WriteLine("- Meter model id: ");
                endPoint.Meter_model_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("- Meter Number: ");
                endPoint.Meter_number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("- Meter fw version: ");
                endPoint.Meter_fw_version = Console.ReadLine();
                endPoint = validate_switch_state(endPoint);

                endPoints.Add(endPoint);

                Console.WriteLine("Serial Number saved successfully");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - "+ex.Message);
                Console.ReadLine();
            }

            return endPoints;

        }

        private EndPoint validate_switch_state(EndPoint endPoint)
        {
            int state = 5;
            while (state != 0 && state != 1 && state != 2)
            {
                Console.WriteLine("- Switch State - (0)disconnect (1)connect (2)Armed: ");
                state = Convert.ToInt32(Console.ReadLine());
                if (state == 0 || state == 1 || state == 2)
                    endPoint.Switch_state = state;
                else
                {
                    Console.WriteLine("Invalid Number");
                }
            }

            return endPoint;

        }

        public List<EndPoint> edit (List<EndPoint> endPoints)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Which serial number do you want to edit? \n");
                string serial = Console.ReadLine();

                if (endPoints.Exists(p => p.Serial_number == serial))
                {
                    Console.WriteLine("- Switch State - (0)disconnect (1)connect (2)Armed: ");
                    int new_state = Convert.ToInt32(Console.ReadLine());

                    // Lambda Expression
                    var item = endPoints.Where(c => c.Serial_number.Equals(serial)).FirstOrDefault();

                    item.Switch_state = new_state;

                    Console.WriteLine("Serial Number edited successfully");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Serial Number not found");
                    Console.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();
            }

            return endPoints;
        }

        public List<EndPoint> delete (List<EndPoint> endPoints)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Which serial number do you want to delete? \n");
                string serial = Console.ReadLine();

                if (endPoints.Exists(p => p.Serial_number == serial))
                {
                    //Lambda expression
                    var item = endPoints.Where(c => c.Serial_number.Equals(serial)).FirstOrDefault();

                    endPoints.Remove(item);

                    Console.WriteLine("Serial Number removed successfully");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Serial Number not found");
                    Console.ReadLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();
            }

            return endPoints;
        }

        public void list_all (List<EndPoint> endPoints)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------EndPoints------\n");

                int cont = 0;
                foreach (var elemento in endPoints)
                {
                    Console.WriteLine("Endpoint - " + cont);
                    Console.WriteLine("Serial Number: " + elemento.Serial_number);
                    Console.WriteLine("Model Id: " + elemento.Meter_model_id);
                    Console.WriteLine("Meter number: " + elemento.Meter_number);
                    Console.WriteLine("FW version: " + elemento.Meter_fw_version);
                    Console.WriteLine("Switch state: " + elemento.Switch_state);
                    Console.WriteLine("---------------------");

                    cont++;
                }

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();
            }

        }

        public void find_by_serial (List<EndPoint> endPoints)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Which serial number do you want to find? \n");
                string serial = Console.ReadLine();

                if (endPoints.Exists(p => p.Serial_number == serial))
                {
                    // LINQ query
                    var elemento = from x in endPoints
                                   where x.Serial_number.Contains(serial)
                                   select x;

                    Console.WriteLine("--------------Result------------");
                    Console.WriteLine("Serial Number: " + elemento.First().Serial_number);
                    Console.WriteLine("Model Id: " + elemento.First().Meter_model_id);
                    Console.WriteLine("Meter number: " + elemento.First().Meter_number);
                    Console.WriteLine("FW version: " + elemento.First().Meter_fw_version);
                    Console.WriteLine("Switch state: " + elemento.First().Switch_state);

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Serial Number not found");
                    Console.ReadLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
                Console.ReadLine();
            }
        }

        public void exit()
        {

        }
    }
}
