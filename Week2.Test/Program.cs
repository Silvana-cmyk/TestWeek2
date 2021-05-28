using System;
using System.Collections;

namespace Week2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList task_lista = new ArrayList();

            int i = Supporto.Menu();
            while (i != 0)
            {
                Supporto.AnalizzaScelta(i, ref task_lista);
                i = Supporto.Menu();
            }
        }
    }
}
