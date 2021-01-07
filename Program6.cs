using System;
using System.Collections.Generic;

namespace ConsoleApp49
{
    class Program6
    {

        public class Libro
        {
            private int _ISBN;
            private string _titulo;
            private string _autor;
            private int _npag;

            public int ISBN
            {
                get { return _ISBN; }
                set { _ISBN = value; }
            }

            public string Titulo
            {
                get { return _titulo; }
                set { _titulo = value; }
            }

            public string Autor
            {
                get { return _autor; }
                set { _autor = value; }
            }

            public int Npag
            {
                get { return _npag; }
                set { _npag = value; }
            }

            public Libro (int isb,string tit,string aut,int num)
            {
                ISBN = isb;
                Titulo = tit;
                Autor = aut;
                Npag = num;
            }

            public int CompareTo(Libro obj)
            {
                return Npag.CompareTo(obj.Npag);
            }

            public override string ToString()
            {
                return string.Format("El libro {0} con ISBN {1} creado por el autor {2} tiene páginas {3}",Titulo,ISBN, Autor,Npag);
            }
        }

        static void Main(string[] args)
        {
            Libro ex1 = new Libro(12345678,"Morales","Pep",145);
            Libro ex2 = new Libro(45678901,"Rabal", "Jon", 50);

            List<Libro> array = new List<Libro>();

            array.Add(ex1);
            array.Add(ex2);

            Libro max = null;

            foreach (Libro n in array)
            {
                Console.WriteLine(n.ToString());

                if (max == null)
                    max = n;
                else if (0 < n.CompareTo(max))
                    max = n;
            }

            Console.WriteLine("El libro {0} es el que tiene mas paginas",max.Titulo);
        }
    }
}
