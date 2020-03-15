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
            int opcao = 0;

            while (opcao != 6)
            {
                Console.Write("-------------Gerenciador de Frota-------------\n");
                Console.WriteLine("|Entre com uma opção:                        |\n");
                Console.WriteLine("|1 - Salvar novo EndPoint;                   |\n");
                Console.WriteLine("|2 - Editar um EndPoint;                     |\n");
                Console.WriteLine("|3 - Deletar um EndPoint;                    |\n");
                Console.WriteLine("|4 - Listar todos os EndPoints;              |\n");
                Console.WriteLine("|5 - Encontrar EndPoints pelo serial number; |\n");
                Console.WriteLine("|6 - Exit;                                   |\n");
                Console.WriteLine("----------------------------------------------\n");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        salvar_endpoint(endPoints);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada! \n");
                        break;

                }

                Console.Clear();
            }    
            
        }

        static void salvar_endpoint(List<EndPoint> lista)
        {

            endPoints = endPointController.salvar(lista);

        }

        static void editar_endpoint(List<EndPoint> lista)
        {

            endPoints = endPointController.salvar(lista);

        }

    }
}
