using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndManufacturers.Logic
{
    public static class ConsoleHelper
    {
        public static void Print(this string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        public static (int index, string option) GetUserSelection(this IEnumerable<string> options, bool sort = true)
        {
            var all = options
                .Select((option, index) => (option, index))
                .ToList();

            if (sort)
            {
                all.OrderBy(m => m);
            }
            
            "please Select: ".Print(ConsoleColor.Green);

            foreach (var item in all)
            {
                $"{item.index + 1}. {item.option}".Print(ConsoleColor.Yellow);
            }

            return SelectionHandler(all);
        }

        private static (int index, string option) SelectionHandler(List<(string option, int index)> all)
        {
            while (true)
            {
                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int optionIndex))
                {
                    if ((optionIndex < 1) || (optionIndex > all.Count))
                    {
                        $"Please select on option between 1 and {all.Count}".Print(ConsoleColor.Red);
                    }

                    else
                    {
                        return (index: optionIndex, option: all[optionIndex - 1].option);
                    }
                }

                else
                {
                    "Please select a valid number".Print(ConsoleColor.Red);
                }
            }
        }
    }
}
