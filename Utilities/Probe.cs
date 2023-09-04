using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utilities
{
    public class Probe
    {
        public Dictionary<string, IMeasure> Measures = new Dictionary<string, IMeasure>();

        public Dictionary<string,float> LastRecord {get; set;}

        public Probe()
        {
            LastRecord = new Dictionary<string, float>();
            Measures.Add("Temperatura", new Temperature());
            Measures.Add("Umidita", new Umidity());
            Measures.Add("CO2", new CO2());
        }

        public bool PrintMeasures()
        {
            int error = 0;
            bool res = true;

            try
            {
                foreach (var i in Config.Instance.Measures)
                {
                    float lastRecord = Measures[i].Print();
                    LastRecord[i] = lastRecord;
                    error++;
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine ($"Il valore [\"{Config.Instance.Measures[error]}\"] non può venire misurato dal sensore, pertanto verrà rimosso da successive analisi");
                Config.RemoveFields(error);
                Debug.WriteLine (ex.ToString());
                res = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                res = false;
            }

            return res;
        }
    }
}
