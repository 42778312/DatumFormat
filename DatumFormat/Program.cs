using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Geben Sie ein Datum ein (im beliebigen Format):");
            string input = Console.ReadLine();
            //____________________________________________//___________________________

            string dateFormat = GetDateFormat(input);

            if (dateFormat != (""))
            {
                Console.WriteLine($"Das erkannte Datumsformat ist: {dateFormat}");
            }
            else
            {
                Console.WriteLine("Das Datumsformat konnte nicht ermittelt werden.");
            }

            Console.ReadLine();
        }
        
    }
    //_______________________________________________________________________________

    static string GetDateFormat(string input)
    { // Array for the Dates ___________________
        string[] possibleFormats = {
            "dd.MM.yy", "dd.MM.yyyy", "dd-MM-yy", "dd-MM-yyyy",
            "M/d/yy", "M/d/yyyy", "M-d-yy", "M-d-yyyy",
            "yyyy-MM-dd", "yyyy/MM/dd",
            "yy.MM.dd", "yyyy.MM.dd",
        };

        foreach (string format in possibleFormats)
        {
            if (TryParseWithFormat(input, format, out _))
            {
                return (format);
            }
        }

        return ("");
    }
    //______________________________________________________________________________________
    static bool TryParseWithFormat(string input, string format, out DateTime parsedDate)
    {
        return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
    }

    
}
