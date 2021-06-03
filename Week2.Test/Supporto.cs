using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    class Supporto
    {
        public static int Menu()
        {
            Console.WriteLine("1. Inserisci task");
            Console.WriteLine("2. Elimina task");
            Console.WriteLine("3. Visualizza task per importanza");
            Console.WriteLine("4. Visualizza  tutti i task");
            Console.WriteLine("5. Recupero dei dati");
            Console.WriteLine("0. Premi 0 per uscire");

            int scelta;
            bool succ = Int32.TryParse(Console.ReadLine(), out scelta);

            if (succ != true || (scelta < 0 || scelta > 5))
            {
                Console.WriteLine();
                Console.WriteLine("Inserisci un valore corretto.");
                Console.WriteLine();
                scelta = 99;
               // break;
            }
            return scelta;
        }

        public static void AnalizzaScelta(int scelta, ref ArrayList lista)
        {
            Task task = new Task();

            switch (scelta)
            {
                case 1:
                    Inserire(lista);
                    break;
                case 2:
                    Eliminare(lista);
                    break;
                case 3:
                    VisualizzarePerLivello(lista);
                    break;
                case 4:
                    VisualizzareCompleto(lista);
                    break;
                case 5:
                    RecuperoDati(ref lista);
                    break;
                default:
                    scelta = 0;
                    break;
            }

        }


        private static void Inserire(ArrayList lista)
        {
            Task t = new Task();
            try
            {
                Console.WriteLine("Inserisci descrizione");
                t.Descrizione = Console.ReadLine();

                Console.WriteLine("Inserisci data scadenza aaaa mm gg");
                DateTime dt = Convert.ToDateTime(Console.ReadLine());
                while(dt < DateTime.Now) //dt < di DateTime.Today
                {
                    Console.WriteLine("Inserisci data posteriore a oggi");
                    dt = Convert.ToDateTime(Console.ReadLine());
                }
                t.DataScadenza = dt;
                //t.DataScadenza = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Inserisci livello importanza");
                Console.WriteLine("0. Basso");
                Console.WriteLine("1. Medio");
                Console.WriteLine("2. Alto");
                int level = Convert.ToInt32(Console.ReadLine());
                while (level < 0 || level > 2)
                {
                    Console.WriteLine("inserisci valore corretto!");
                    level = level = Convert.ToInt32(Console.ReadLine());
                }
                t.Livello = (Importanza)level;

                lista.Add(t);
                Console.WriteLine("INSERIMENTO AVVENUTO CON SUCCESSO");
                Console.WriteLine();

                // ******SALVATAGGIO SU FILE**********************************
                Console.WriteLine("Vuoi salvare la lista aggiornata su file?");
                Console.WriteLine("Premi Y per salvare altrimenti premi un tasto qualsiasi per saltare passaggio");
                //try
                //{
                    char c = Convert.ToChar(Console.ReadLine());
                    if (c == 'Y')
                    {
                        TaskIO.StampaFile(lista);
                    }
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private static void Eliminare(ArrayList lista)
        {
            int i = 0;
            Console.WriteLine("Quale task vuoi eliminare?");
            foreach (Task item in lista)
            {
                Console.WriteLine(i + ". " + item.Descrizione);
                i++;
            }
            try
            {
                int r = Convert.ToInt32(Console.ReadLine());
                lista.RemoveAt(r);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void VisualizzarePerLivello(ArrayList lista)
        {
            try
            {
                Console.WriteLine("Scegli livello importanza");
                Console.WriteLine("0. Basso");
                Console.WriteLine("1. Medio");
                Console.WriteLine("2. Alto");
                int i = Convert.ToInt32(Console.ReadLine());
                while (i < 0 || i > 2)
                {
                    Console.WriteLine("inserisci valore corretto!");
                    i = i = Convert.ToInt32(Console.ReadLine());
                }
                foreach (Task item in lista)
                {
                    if (item.Livello == (Importanza)i)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void VisualizzareCompleto(ArrayList lista)
        {
            int i = 0;
            Console.WriteLine("Scegli task per visualizzare i dettagli");
            foreach (Task item in lista)
            {
                Console.WriteLine(i + ". " + item.Descrizione);
                i++;
            }
            try
            {
                int j = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(lista[j].ToString());
                Console.WriteLine();

                //VeicoloIO.stampaFile(lista[j]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RecuperoDati(ref ArrayList temp)
        {
            temp = TaskIO.CaricaTaskDaFile();

        }
    }
}
