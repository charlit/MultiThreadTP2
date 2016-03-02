using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP04
{
   public class FileThreadUnsafe<T>
    {

        private T[] tab;
        private int tete, queue;
        
        public FileThreadUnsafe(int taille)
        {
            tab = new T[taille];
            Init();
        }
        private int Suivant(int i)
        {
            return (i + 1) % tab.Length;
        }
        private void Init()
        {
            tete = queue = -1;
        }
        public void Enfiler(T element)
        {
            if (Pleine())
                throw new ExceptionFilePleine();
            else if (Vide())
            {
                
                tab[queue = tete = 0] = element;
            }
            else
            { 
                
                tab[queue = Suivant(queue)] = element;
            }
        }
        public void Defiler()
        {
            
            if (Vide())
                throw new ExceptionFileVide();
            else if (NbElements() == 1)
            {
                Thread.Sleep(1000);
                Init();
            }
            else
                tete = Suivant(tete);

        }
        public bool Vide()
        {
            return ((tete == -1) &&(queue== -1));
        }
        public bool Pleine()
        {
            return Suivant(queue) == tete;
        }
        public int NbElements()
        {
            if (Vide())
                return 0;
            else if (tete <= queue)
                return queue - tete + 1;
            else
                return tab.Length + queue - tete + 1;
        }
        public T Premier()
        {
            if (Vide())
                throw new ExceptionFileVide();
            else
                Thread.Sleep(2000);
                return tab[tete];

        }
    }
}
public class ExceptionFileVide : Exception { }
public class ExceptionFilePleine : Exception { }
