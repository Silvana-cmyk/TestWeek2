using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    enum Importanza
    {
        Basso,
        Medio,
        Alto
    }
    class Task
    {
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; } = new DateTime(1970, 1, 1);
        public Importanza Livello { get; set; }

        //metodi
        override public string ToString()
        {
            return $"Descrizione task: {Descrizione};Data di scadenza: {DataScadenza.ToShortDateString()};" +
                $"Importanza: {Livello}";
        }

    }
}
