using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Nhập vào lần lượt ngày, tháng năm
            int day = Nhap("Nhập ngày: ");
            int month = Nhap("Nhập tháng: ");
            int year = Nhap("Nhập năm: ");
            Console.WriteLine("Ngày vừa nhập là: {0}/{1}/{2}. ", day, month, year);
            // Xuất kết luận về tính hợp lệ của ngày tháng năm
            if (CheckDay(day, month, year)) Console.WriteLine("Hợp lệ.");
            else Console.WriteLine("Không hợp lệ.");

        }
        // Đọc số nguyên
        static int Nhap(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        // Kiểm tra năm nhuận
        static bool IsLeapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
        }
        // Kiểm tra ngày có hợp lệ?
        static bool CheckDay(int d, int m, int y)
        {
            if (d <= 0 || m <= 0 || m > 12) return false;
            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (d > 31) return false;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (d > 30) return false;
                    break;
                case 2:
                    if (d > 28 && !IsLeapYear(y)) return false;
                    if (d > 29 && IsLeapYear(y)) return false;
                    break;
            }
            return true;

        }
    }
}
