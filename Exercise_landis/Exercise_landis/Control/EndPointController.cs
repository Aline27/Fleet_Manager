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

        public List<EndPoint> salvar (List <EndPoint> endPoints)
        {
            try
            {
                EndPoint endPoint = new EndPoint();
                Console.WriteLine("Entre com as informações do EndPoint: \n ");
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
            }

            return endPoints;

        }

        public bool edit (EndPoint endPoint)
        {
            return true;
        }

        public bool delete (EndPoint endPoint)
        {

            return true;
        }

        public bool list_all (EndPoint endPoint)
        {
            return true;
        }

        public EndPoint find_by_serial (string serial)
        {
            EndPoint endPoint = new EndPoint();


            return endPoint;
        }

        public void exit()
        {

        }
    }
}
