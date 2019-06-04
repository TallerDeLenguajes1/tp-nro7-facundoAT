using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp7_facundoToconás
{
    public enum cargoEnum { auxiliar = 1, administrativo = 2, ingeniero = 3, especialista = 4, investigador = 5 };
    public enum estadoCivilEnum { casado, soltero }
    public enum generoEnum { femenino, masculino }
    //             ESTRUCTURA Y FUNCIONES DENTRO DE LA ESTRUCTURA
    public struct empleado
    {
        public string nombre;
        public string apellido;
        public DateTime fechaNacimiento;
        public estadoCivilEnum estadoCivil;// casado,soltero true-false
        public generoEnum genero; //femenino,masculino  true-falsa
        public DateTime fechaDeIngreso;
        public double sueldoBasico;
        public cargoEnum cargo;  //porque no puedo poner public                                
        int hijos;//int cargo;


        //constructor
        public empleado(string _nombre, string _apellido, DateTime _fechaNacimiento, estadoCivilEnum _estadoCival, generoEnum _genero, DateTime _fechaDeIngreso, double _sueldoBasico, cargoEnum _cargo, int _hijos)
        {
            nombre = _nombre;
            apellido = _apellido;
            fechaNacimiento = _fechaNacimiento;
            estadoCivil = _estadoCival;
            genero = _genero;
            fechaDeIngreso = _fechaDeIngreso;
            sueldoBasico = _sueldoBasico;
            cargo = _cargo;
            hijos = _hijos;
        }

        public void mostrar()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apellido: " + apellido);
            Console.WriteLine("Fecha de nacimiento:{0}-{1}-{2}", fechaNacimiento.Day, fechaNacimiento.Month, fechaNacimiento.Year);
            Console.WriteLine("Estado Civil: " + estadoCivil);
            Console.WriteLine("Genero: " + genero);
            Console.WriteLine("Fecha de ingreso a la empresa: {0}-{1}-{2}", fechaDeIngreso.Day, fechaDeIngreso.Month, fechaDeIngreso.Year);
            Console.WriteLine("Sueldo basico: " + sueldoBasico);
            Console.WriteLine("Cargo: " + cargo);
        }
        public int antiguedadEmpleado() => (DateTime.Today.Year - fechaDeIngreso.Year);

        public int edadEmpleado() => (DateTime.Today.Year - fechaNacimiento.Year);

        public int jubilacion()
        {
            if (genero == generoEnum.femenino)
                return (60 - edadEmpleado());
            else
                return (65 - edadEmpleado());
        }
        public double salario()
        {
            double adicional;
            if (antiguedadEmpleado() <= 20)
            {
                adicional = (0.02 * sueldoBasico) * antiguedadEmpleado();
            }
            else
            {
                adicional = (0.25 * sueldoBasico);
            }
            if (cargo == cargoEnum.ingeniero || cargo == cargoEnum.especialista) // 3 ingeniero , 4 especialista
            {
                adicional = (adicional * 0.5) + adicional;
            }
            if (estadoCivil == estadoCivilEnum.casado && hijos > 2)
            {
                adicional = adicional + 5000;
            }
            return (adicional + sueldoBasico);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // PREGUNTAR LAS DIFERENCIAS DE: double con Double y casos similares

            List<empleado> empresa;
            empresa = new List<empleado>();
            empleado empl = new empleado();

            /*empl = new empleado("Facundo", "Toconás", new DateTime(1996, 05, 27),estadoCivilEnum.casado ,generoEnum.masculino , new DateTime(2003, 02, 20), 5000.0, cargoEnum.administrativo, 2);
            empresa.Add(empl);
            empl.mostrar();

            //empl = cargoEmpleados();
            //empresa.Add(empl);

            //empl = cargoEmpleados();
            */
            for (int i = 0; i < 5; i++)
            {
                empl = cargoEmpleados();
                empresa.Add(empl);
                Console.ReadKey();
            }
            mostrar(empresa);
            /*
            empleado = new empleado("Facundo", "Toconás", new DateTime(1996, 05, 27), true, false, new DateTime(2003, 02, 20), 5000.0,cargoEnum.administrativo, 2);
            //empleado.mostrar();
            empresa.Add(empleado);
            empleado = new empleado("Andres", "Gonzales", new DateTime(1980, 06, 12), false, true, new DateTime(2003, 02, 20), 5000.0, cargoEnum.auxiliar, 4);

            empresa.Add(empleado);
            mostrar(empresa);*/
            /*   
           Console.WriteLine("Antiguedad: " + empl.antiguedadEmpleado());
           Console.WriteLine("Edad: " + empl.edadEmpleado());
           Console.WriteLine("Cantidad de años que le faltan para poder jubilarse: " + empl.jubilacion());
           Console.WriteLine("Salario: " + empl.salario());
           Console.WriteLine("Cantidad de empleados: "+cantidadEmpleados(empresa)); // porque si mi funcion no tiene static no funciona
           */


            Console.ReadKey();
        }

        //             FUNCIONES FUERA DE LA ESTRUCTURA
        public static int cantidadEmpleados(List<empleado> empresa) => empresa.Count();
        public static double montoTotal(List<empleado> empresa)
        {
            double total = 0;
            for (int i = 0; i < empresa.Count(); i++)
            {
                total = empresa[i].salario() + total;
            }
            return (total);
        }
        public static void mostrar(List<empleado> empresa)
        {
            for (int i = 0; i < empresa.Count(); i++)
            {
                Console.WriteLine("----- Empleado {0} -----", i + 1);
                empresa[i].mostrar();
            }
        }
        public static empleado cargoEmpleados()
        {
            string[] nombresArreglo = { "facu", "martin", "andres", "mario", "juan" };
            string[] apellidosArreglo = { "Toconás", "Gonzales", "Torres", "Alvarez", "Riquelme" };


            Random rand = new Random(); //    preguntar porque es asi
            int aleatorio = rand.Next(5);

            string nombreAleatorio = nombresArreglo[aleatorio];

            aleatorio = rand.Next(5);
            string apellidoAleatorio = apellidosArreglo[aleatorio];

            int anioAleatorio = rand.Next(1930, 2000);
            int mesAleatorio = rand.Next(1, 12);
            int diaAleatorio = rand.Next(1, 29);
            DateTime nacimientoAleatorio = new DateTime(anioAleatorio, mesAleatorio, diaAleatorio);

            anioAleatorio = rand.Next(2000, 2018);
            mesAleatorio = rand.Next(1, 12);
            diaAleatorio = rand.Next(1, 29);
            DateTime ingresoAleatorio = new DateTime(anioAleatorio, mesAleatorio, diaAleatorio);
            //Console.WriteLine(nombreAleatorio);
            //Console.WriteLine(apellidoAleatorio);
            estadoCivilEnum estadoCivilAleatorio = (estadoCivilEnum)rand.Next(1, 2);
            generoEnum generoAleatorio = (generoEnum)rand.Next(1, 2);

            double basicoAleatorio = (double)rand.Next(10000, 20000);
            cargoEnum cargoAleatorio = (cargoEnum)rand.Next(1, 5);
            int hijosAleatorio = (int)rand.Next(1, 4);
            empleado empl = new empleado(nombreAleatorio, apellidoAleatorio, nacimientoAleatorio, estadoCivilAleatorio, generoAleatorio, ingresoAleatorio, basicoAleatorio, cargoAleatorio, hijosAleatorio);
            //empl.mostrar();


            return empl;
        }

    }
}
