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
                Console.WriteLine("- Switch State - (0)disconnect (1)connect (2)Armed: ");
                endPoint.Switch_state = Convert.ToInt32(Console.ReadLine());

                endPoints.Add(endPoint);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - "+ex.Message);
                Console.ReadLine();
            }

            return endPoints;

        }

        public List<EndPoint> edit (List<EndPoint> endPoints)
        {
            Console.WriteLine("Which serial number do you want to edit? \n");
            string serial = Console.ReadLine();

            if (endPoints.Exists(p => p.Serial_number == serial))
            {
                Console.WriteLine("- Switch State - (0)disconnect (1)connect (2)Armed: ");
                int new_state = Convert.ToInt32(Console.ReadLine());

                var item = endPoints.Where(c => c.Serial_number.Equals(serial)).FirstOrDefault();

                item.Switch_state = new_state;

            }
            else
            {
                Console.WriteLine("Serial Number not found");
                Console.ReadLine();
            }


            return endPoints;
        }

        public bool delete (List<EndPoint> endPoints)
        {

            return true;
        }

        public void list_all (List<EndPoint> endPoints)
        {
            Console.Clear();
            Console.WriteLine("------EndPoints------\n");

            int cont = 0;
            foreach (var elemento in endPoints)
            {
                Console.WriteLine("Endpoint - "+cont);
                Console.WriteLine("Serial Number: "+elemento.Serial_number);
                Console.WriteLine("Model Id: "+elemento.Meter_model_id);
                Console.WriteLine("Meter number: "+elemento.Meter_number);
                Console.WriteLine("FW version: "+elemento.Meter_fw_version);
                Console.WriteLine("Switch state: "+elemento.Switch_state);
                Console.WriteLine("---------------------");

                cont++;
            }

            Console.ReadLine();
        }

        public EndPoint find_by_serial (string serial, List<EndPoint> endPoints)
        {
            EndPoint endPoint = new EndPoint();


            return endPoint;
        }

        public void exit()
        {

        }
    }
}
