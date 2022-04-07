
using System;


namespace Cafetera
{
    class Program
    {
      

        static int vasosD = 0;
        static int azucarD = 0;
        static int cafeD = 0;
        static void Main(string[] args)
        {


            Console.WriteLine("Maquina de Cafe");

            var respuesta = Inicio();
            while(respuesta != 0)
            {
                if (respuesta == 1)
                {
                    Console.WriteLine(" 1:Agregar Vasos\n 2: Agregar Azucar\n 3:Agregar Cafe");
                    int agregar = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Cantidad a Agregar:");
                    int cantidad = Convert.ToInt32(Console.ReadLine());

                    switch (agregar)
                    {
                        case 1:
                            vasosD = vasosD + cantidad;
                            break;
                        case 2:
                            azucarD = azucarD + cantidad;
                            break;
                        case 3:
                            cafeD = cafeD + cantidad;
                            break;
                        default:
                            break;
                    }
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Maquina de Cafe");
                    while (cafeD > 0 || vasosD > 0 || azucarD > 0)
                    {

                        stock();
                        Console.WriteLine("");
                        var CantDeVasos = getCantidadDeVaso();
                        if (CantDeVasos > vasosD)
                        {
                            Console.WriteLine("NO TENEMOS LA CANTIDAD DE VASOS PROPORCIANADO, INTRODUSCA OTRA CANTIDAD");
                            getCantidadDeVaso();
                        }

                        for (int i = 1; i <= CantDeVasos; i++)
                        {
                            var TipoVaso = getTipoVaso();

                            var CantAzucar = SetCantidadDeAzucar();
                            if (CantAzucar > azucarD)
                            {
                                Console.WriteLine("NO TENEMOS LA CANTIDAD DE AZUCAR PROPORCIANADO, INTRODUSCA OTRA CANTIDAD");
                                SetCantidadDeAzucar();
                            }

                            GetVasosDeCafe(TipoVaso, CantAzucar, i);
                        }
                    }
                    Console.WriteLine("Llamar al administrador");
                }
                respuesta=Inicio();
            }
           

            
           


        }

        public static void stock()
        {
            Console.WriteLine($" Vasos Disponible {vasosD} \n Azucar Disponible {azucarD}\n Cafe Disponible {cafeD}");

        }
        public static int Inicio()
        {
            Console.WriteLine(" 1: Para Admin\n 2: Para usuario");
            int resp = Convert.ToInt32(Console.ReadLine());
            return resp;
        }

        public static int getTipoVaso()
        {
            Console.WriteLine("Digite el tamaño de su Vaso");
            Console.WriteLine(" 1: Pequeno \n 2: Mediano \n 3: Grande");

            int vaso = Convert.ToInt32(Console.ReadLine());

            return vaso;
        }
        public static int getCantidadDeVaso()
        {
            Console.WriteLine($"Cuantos vasos quieres");
        
                                                                


            int Cantvaso = Convert.ToInt32(Console.ReadLine());

            return Cantvaso;
        }
        public static int SetCantidadDeAzucar()
        {
            Console.WriteLine("Digite la cantidad de Azucar");
            int azucar = Convert.ToInt32(Console.ReadLine());

            return azucar;
        }
        public static void GetVasosDeCafe(int tipoDeVaso, int cantDeAzucar, int cantDeVasos)
        {
            switch (tipoDeVaso)
            {

                case 1:
                    Console.WriteLine($"Su cafe #{cantDeVasos} es pequeno con {cantDeAzucar} cucharadas de azucar");
                    break;
                case 2:
                    Console.WriteLine($"Su cafe #{cantDeVasos} es mediano con {cantDeAzucar} cucharadas de azucar");
                    break;
                case 3:
                    Console.WriteLine($"Su cafe #{cantDeVasos} es grande con {cantDeAzucar} cucharadas de azucar");
                    break;
                default:
                    break;
            }
            cafeD--;
            vasosD = vasosD - cantDeVasos;
            azucarD = azucarD-cantDeAzucar;
            stock();
        }
    }
}
