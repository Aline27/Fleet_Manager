using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_landis.Model;

namespace Exercise_landis.Control
{
    public class EndPointController
    {

        public List<EndPoint> save (List <EndPoint> endPoints, EndPoint endPoint)
        {
            try
            {
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


        public List<EndPoint> edit (List<EndPoint> endPoints, string serial, int new_state)
        {
            try
            {

                if (endPoints.Exists(p => p.Serial_number == serial))
                {

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

        public List<EndPoint> delete (List<EndPoint> endPoints, string serial)
        {
            try
            {

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

        public void find_by_serial (List<EndPoint> endPoints, string serial)
        {
            try
            {

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
