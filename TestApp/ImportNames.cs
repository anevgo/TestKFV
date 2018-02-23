using NameDayApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayApp
{
    public class ImportNames
    {
        public List<DayName> ReadFile()
        {
            List<DayName> importedData = new List<DayName>();

            using (StreamReader reader = new StreamReader(File.OpenRead("nimet.csv")))
            {                
                while (!reader.EndOfStream)
                {                    
                    string line = reader.ReadLine();
                    string[] values = line.Split(new char[] { ';', ',' }, StringSplitOptions.None);
                    List<string> names = new List<string>();

                    if (values.Length > 1)
                    {
                        for (int i = 1; i < values.Length; i++)
                        {
                            names.Add(values[i].Trim());
                        }
                    }

                    DayName name = new DayName()
                    {                       
                        Date = DateTime.ParseExact(values[0], "d.M.",null),
                        Names = names.ToArray()
                    };

                    importedData.Add(name);
                }               

            }

            return importedData;
        }
    }
}
