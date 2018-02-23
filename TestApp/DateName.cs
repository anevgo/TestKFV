using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameDayApp;

namespace NameDayApp
{
    public class DateName
    {
        static void Main(string[] args)
        {
            if (args!= null)
            {
                try
                {
                    DateInput.ProcessDate(args[0]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong while processing the request... \nMore detailed information: " + ex.Message);
                }
                
            }                      
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();                   
        }        
    }

    public static class DateInput
    {
        private static List<DayName> iNames = new List<DayName>();
        private static ImportNames import = new ImportNames();
        private static DateTime cDate = new DateTime();
        private static string[] names = new string[] { };

        public static string[] ProcessDate(string input)
        {
            iNames = import.ReadFile();

            if (input != null)
            {
                try
                {
                    cDate = DateTime.ParseExact(input, "d.M", null);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Date in the wrong format. Please use \"d.m\" format" + "\n\nDetailed error description: " + "\n\n" + ex.Message);
                    throw ex;
                }
            }
            bool contains = iNames.Any(n => n.Date == cDate);

            if (contains)
            {
                foreach (var n in iNames)
                {
                    if (cDate == n.Date)
                    {
                        Console.WriteLine(cDate.ToString("d.M.") + " is the name day for the following names:");
                        names = n.Names;
                        for (int i = 0; i < n.Names.Length; i++)
                        {
                            Console.WriteLine(n.Names[i]);
                        }
                    }                  
                }
                return names;
            }
            else
            {
                throw new ApplicationException("No names for such date.");
            }          
        }
    }

    public class DayName
    {
        public DateTime Date { get; set; }
        public string[] Names { get; set; }
    }

}
