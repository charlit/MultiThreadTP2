using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace TP04
{
    class Program
    {
        static FileThreadUnsafe<int> f;

        static void Main(string[] args)
        {

            Thread t1 = new Thread(Defiler);
            Thread t2 = new Thread(Afficher);

            f = new FileThreadUnsafe<int>(10);

            for (int i = 1; i <= 5; i++)
            {
                f.Enfiler(i);
            }

                t1.Start();
                t2.Start();
                Console.ReadKey();
            }

            static void Defiler()
            {
                Console.WriteLine("Nombre d'éléments : ", f.NbElements());
                while (!f.Vide())
                {
                    f.Defiler();

                }

            }
            static void Afficher()
            {
                Console.WriteLine("Nombre d'éléments : ", f.NbElements());
                while (!f.Vide())
                {
                    Console.WriteLine(f.Premier());

                }

            }



        }

    }

