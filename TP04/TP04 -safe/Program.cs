using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TP04__safe
{
    class Program
    {
        static FileThreadSafe<int> f;
        

        static void Main(string[] args)
        {

                Thread t1 = new Thread(Afficher);
                Thread t2 = new Thread(Afficher);

                f = new FileThreadSafe<int>(50);

                for (int i = 1; i <= 25; i++)
                {
                    f.Enfiler(i);
                }

                t1.Start();
                t2.Start();
                
            }


            static void Afficher()
            {
                Console.WriteLine("Nombre d'éléments : ", f.NbElements());
                

                while (!f.Vide())
                {
                    Console.WriteLine(f.Premier());
                    f.Defiler();

                }
            

            }

        }

    }



