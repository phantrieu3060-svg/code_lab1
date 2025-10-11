using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Nhập lần lượt tháng , năm
            int month = InputMonth();
            int year = InputYear();
            Console.WriteLine("Số ngày của tháng {0}/{1} là: {2} ngày", month, year, NumberOfDays(month, year));
        }
        // Đọc tháng
        static int InputMonth()
        {
            int m;
            do
            {
                Console.Write("Nhập vào tháng: ");
            } while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m > 12);
            return m;
        }
        // Đọc năm
        static int InputYear()
        {
            int y;
            do
            {
                Console.Write("Nhập vào năm: ");
            } while (!int.TryParse(Console.ReadLine(), out y));
            return y;
        }
        // Kiểm tra năm nhuận
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
        // Tra số ngày của tháng 
        static int NumberOfDays(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    if (IsLeapYear(year)) return 29;
                    return 28;
            }
        }
    }
}
