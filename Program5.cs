using System;
using System.Collections.Generic;

namespace ConsoleApp48
{
    class Program5
    {

        public interface Entregable
        {
            void entregar();

            void devolver();

            bool isEntregado();

        }

        public class Serie : Entregable
        {
            private string _titulo;
            private int _temporadas;
            private bool Entregado;
            private string _genero;
            private string _creador;

            public string Titulo
            {
                get { return _titulo; }
                set { _titulo = value; }
            }

            public int Temporadas
            {
                get { return _temporadas; }
                set { _temporadas = value; }
            }

            public string Genero
            {
                get { return _genero; }
                set { _genero = value; }
            }

            public string Creador
            {
                get { return _creador; }
                set { _creador = value; }
            }

            public Serie()
            {
                Titulo = "";
                Creador = "";
                Genero = "";
                Temporadas = 3;
                Entregado = false;
            }

            public Serie(string tit, string autor)
            {
                Titulo = tit;
                Creador = autor;
                Genero = "";
                Temporadas = 3;
                Entregado = false;
            }

            public Serie(string tit, string autor, string gen, int temp)
            {
                Titulo = tit;
                Creador = autor;
                Genero = gen;
                Temporadas = temp;
                Entregado = false;
            }

            public int CompareTo(Serie obj)
            {
                return Temporadas.CompareTo(obj.Temporadas);
            }

            public override string ToString()
            {
                return string.Format("Titulo:{0} Temporadas:{1} Entregado:{2} Genero:{3} Creador:{4} ", _titulo, _temporadas, Entregado, _genero, _creador);
            }

            public void entregar()
            {
                Entregado = true;
            }

            public void devolver()
            {
                Entregado = false;
            }

            public bool isEntregado()
            {
                return Entregado;
            }
        }

        public class Videojuego : Entregable
        {
            private string _titulo;
            private int _horas;
            private bool Entregado;
            private string _genero;
            private string _compañia;

            public string Titulo
            {
                get { return _titulo; }
                set { _titulo = value; }
            }

            public int Horas
            {
                get { return _horas; }
                set { _horas = value; }
            }

            public string Genero
            {
                get { return _genero; }
                set { _genero = value; }
            }

            public string Compañia
            {
                get { return _compañia; }
                set { _compañia = value; }
            }

            public Videojuego()
            {
                Titulo = "";
                Compañia = "";
                Genero = "";
                Horas = 10;
                Entregado = false;
            }

            public Videojuego(string tit, int hou)
            {
                Titulo = tit;
                Horas = hou;
                Genero = "";
                Compañia = "";
                Entregado = false;
            }

            public Videojuego(string tit, int hou, string gen, string com)
            {
                Titulo = tit;
                Horas = hou;
                Genero = gen;
                Compañia = com;
                Entregado = false;
            }

            public int CompareTo(Videojuego obj)
            {
                return Horas.CompareTo(obj.Horas);
            }

            public override string ToString()
            {
                return string.Format("Titulo:{0} Horas:{1} Entregado:{2} Genero:{3} Compañia:{4} ", _titulo, _horas, Entregado, _genero, _compañia);
            }

            public void entregar()
            {
                Entregado = true;
            }

            public void devolver()
            {
                Entregado = false;
            }

            public bool isEntregado()
            {
                return Entregado;
            }
        }


        static void Main(string[] args)
        {
            ex5();
        }

        public static void ex5()
        {
            List<Serie> array1 = new List<Serie>();
            List<Videojuego> array2 = new List<Videojuego>();

            for (int i = 0; i < 10; i++)
            {
                array1.Add(new Serie("Rol", "Pol", "Miedo", i));
                array2.Add(new Videojuego("Play", i, "Miedo", "Pompas"));
            }

            array1[2].entregar();
            array1[4].entregar();
            array1[6].entregar();

            array2[3].entregar();
            array2[5].entregar();
            array2[7].entregar();

            int count1 = 0;
            int count2 = 0;

            foreach (Serie n in array1)
                if (n.isEntregado())
                    count1++;

            foreach (Videojuego n in array2)
                if (n.isEntregado())
                    count2++;

            Console.WriteLine("El numero de entregados en series es de " + count1);
            Console.WriteLine("El numero de entregados en videojuegos es de " + count2);


            Serie max = null;
            foreach (Serie n in array1)
            {
                if (max == null)
                    max = n;
                else if (0 < n.CompareTo(max))
                    max = n;
            }

            Videojuego max2 = null;
            foreach (Videojuego n in array2)
            {
                if (max2 == null)
                    max2 = n;
                else if (0 < n.CompareTo(max2))
                    max2 = n;
            }

            Console.WriteLine(max.ToString());
            Console.WriteLine(max2.ToString());
        }

    }
}
