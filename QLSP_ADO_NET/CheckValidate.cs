using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_NET
{
    public class CheckValidate
    {
        public static int ValidateIntInput(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }
            }
        }

        public static string ValidateStringInput(string prompt)
        {
            string value;
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Giá trị không được để trống. Vui lòng nhập lại.");
                }
            }
        }

    }
}
