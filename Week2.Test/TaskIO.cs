using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    class TaskIO
    {
        public static void StampaFile(ArrayList listaT)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop), "testoT.txt");
            StreamWriter file = null;
            try
            {
                using (file = File.CreateText(filePath))
                {
                    foreach (Task item in listaT)
                        file.WriteLine(item);
                }
                Console.WriteLine("Stampa su file eseguita con successo");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                file.Close();
            }
        }

        public static ArrayList CaricaTaskDaFile()
        {
            ArrayList task = new ArrayList();
            string path = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop), "testoT.txt");
            string line;
            try
            {
                using (StreamReader fileReader = File.OpenText(path))
                {
                    //leggo fino a quando trovo contenuto nel file
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        string[] valori = line.Split(";");
                        string descrizione = valori[0].Substring(18);
                        DateTime dataScadenza = Convert.ToDateTime(valori[1].Substring(18));
                        String livello = valori[2].Substring(12);
                        int l;
                        if (livello == "Basso")
                        {
                            l = 0;
                        }
                        else if (livello == "Medio")
                        {
                            l = 1;
                        } else
                        {
                            l = 2;
                        }

                        Task t = new Task()
                        {
                            Descrizione = descrizione,
                            DataScadenza = dataScadenza,
                            Livello = (Importanza)l
                        };
                        
                        task.Add(t);
                    }
                }//qui richiamo l'azione del garbage collector
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return task;
        }

    }
}
