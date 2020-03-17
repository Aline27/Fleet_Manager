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

        public List<EndPoint> SaveEndPoint (List <EndPoint> endPoints, EndPoint endPoint)
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


        public List<EndPoint> EditEndPoint (List<EndPoint> endPoints, string serial, int new_state)
        {
            try
            {

                if (endPoints.Exists(p => p.SerialNumber == serial))
                {

                    // Lambda Expression
                    var item = endPoints.Where(c => c.SerialNumber.Equals(serial)).FirstOrDefault();

                    item.SwitchState = new_state;

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

        public List<EndPoint> DeleteEndPoint (List<EndPoint> endPoints, string serial)
        {
            try
            {

                if (endPoints.Exists(p => p.SerialNumber == serial))
                {
                    //Lambda expression
                    var item = endPoints.Where(c => c.SerialNumber.Equals(serial)).FirstOrDefault();

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

        public void DeleteEndPoint (List<EndPoint> endPoints)
        {
            try
            {
                Console.WriteLine("------EndPoints------\n");

                int cont = 0;
                foreach (var elemento in endPoints)
                {
                    Console.WriteLine("Endpoint - " + cont);
                    Console.WriteLine("Serial Number: " + elemento.SerialNumber);
                    Console.WriteLine("Model Id: " + elemento.MeterModelId);
                    Console.WriteLine("Meter number: " + elemento.MeterNumber);
                    Console.WriteLine("FW version: " + elemento.MeterFwVersion);
                    Console.WriteLine("Switch state: " + elemento.SwitchState);
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

        public void FindEndPointBySerial (List<EndPoint> endPoints, string serial)
        {
            try
            {

                if (endPoints.Exists(p => p.SerialNumber == serial))
                {
                    // LINQ query
                    var element = from x in endPoints
                                   where x.SerialNumber.Contains(serial)
                                   select x;

                    Console.WriteLine("--------------Result------------");
                    Console.WriteLine("Serial Number: " + element.First().SerialNumber);
                    Console.WriteLine("Model Id: " + element.First().MeterModelId);
                    Console.WriteLine("Meter number: " + element.First().MeterNumber);
                    Console.WriteLine("FW version: " + element.First().MeterFwVersion);
                    Console.WriteLine("Switch state: " + element.First().SwitchState);

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
