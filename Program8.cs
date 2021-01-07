using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp51
{

    public class Persona
    {
        private string _nom;
        private int _edad;
        private int _pos;
        private string[] sexe = { "Home", "Dona" };

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        public int Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Persona (string n, int e, int p)
        {
            Nom = n;
            Edad = e;
            Pos = p;
        }

    }

    public class Estudiant : Persona
    {
        private int _calificacio;
        private bool _nudillos;

        public int Calificacion
        {
            get { return _calificacio; }
            set { _calificacio = value; }
        }

        public bool Nudillos
        {
            get { return _nudillos; }
            set { _nudillos = value; }
        }

        public Estudiant(string n,int e, int p, int cal) 
            : base(n,e,p)
        {
            Calificacion = cal;
            Nudillos = provaNudillos();
        }

        private bool provaNudillos()
        {            
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 50)
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            return string.Format("El estudiant estara a fora? {1}", Nudillos);
        }
    }

    public class Profesor : Persona
    {
        private int _posi;
        private bool _disponible;
        private string[] opcions = { "Mates", "Filo", "Fisica"};

        public int Posi
        {
            get { return _posi; }
            set { _posi = value; }
        }

        public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        public Profesor(string n, int e, int p, int pos)
           : base(n, e, p)
        {
            Posi = pos;
            Disponible = provaDisponible();
        }

        private bool provaDisponible()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 25)
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            return string.Format("El profe es de {0} i estara {1}", opcions[Posi],Disponible);
        }
    }
    
    public class Aula
    {
        private int _id;
        private int _maxpersonas;
        private int _pos;
        private string[] opcions = { "Mates", "Filo", "Fisica" };

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int MaxPersones
        {
            get { return _maxpersonas; }
            set { _maxpersonas = value; }
        }

        public int Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Aula(int n, int e, int p)
        {
            ID = n;
            MaxPersones = e;
            Pos = p;
        }


        public override string ToString()
        {
            return string.Format("El aula es de {0}", opcions[Pos]);
        }
    }

    class Program8
    {
        static void Main(string[] args)
        {
            Dictionary<Profesor, List<Estudiant>> classe = new Dictionary<Profesor, List<Estudiant>>();
            Dictionary<Aula, Profesor> aules = new Dictionary<Aula, Profesor>();
            List<Profesor> profes = new List<Profesor>();
            List<Estudiant> alumnes = new List<Estudiant>();
            Random rnd = new Random();
            int num = 0;

            for (int l = 0; l < 40; l++)
                profes.Add(new Profesor("Predator",40+l, rnd.Next(0, 2), rnd.Next(0, 3)));


            while (num < 3)
            {
                alumnes.Clear();
                
                Aula prova;

                for (int n = 0; n < 100; n++)
                    alumnes.Add(new Estudiant("Plane",12, rnd.Next(0, 2), rnd.Next(0, 11)));

                prova = new Aula(num, 100, num);
               
                foreach (Profesor k in profes)
                    if (k.Disponible && prova.Pos == k.Posi)
                    {
                        classe.Add(k, alumnes.ToList());
                        aules.Add(prova, k);
                        profes.Remove(k);
                        break;
                    }

                num++;                        
            }

            foreach (KeyValuePair < Aula, Profesor> entry in aules)
            {
                Console.WriteLine(entry.Key.ToString());

                Console.WriteLine(entry.Value.ToString());

                Profesor ret = entry.Value;

                int count = 0;
                int countM = 0;
                int countF = 0;
                int Fchat = 0;

                List<Estudiant> array = classe[ret];

                foreach (Estudiant n in array)
                {
                    if (n.Nudillos)
                        count++;
                }

                if (count < 50)
                {
                    Console.WriteLine(" \nEs poden fer classes hi han {0} estudiants de 100 \n", count);

                    foreach (Estudiant n in array)
                    {
                        if (!n.Nudillos && n.Pos == 0 && n.Calificacion > 4)
                            countM++;
                        if (!n.Nudillos && n.Pos == 1 && n.Calificacion > 4)
                            countF++;
                        if (!n.Nudillos && n.Calificacion < 5)
                            Fchat++;
                    }

                    Console.WriteLine("Han aprovat {0} nois", countM);
                    Console.WriteLine("Han aprovat {0} noies \n", countF);
                    Console.WriteLine("Han suspes {0} alumnes qu no han fet nudillos\n", Fchat);
                }
                   
                else
                    Console.WriteLine("\nNo es poden fer classes falten {0} estudiants de 100 \n", count);
            }

            Console.WriteLine("Papas");
        }
    }
}
