using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool valid = false; // Lưu giá trị hợp lệ của ngày tháng năm vừa nhập
            int day, month, year;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                // Nhập lần lượt ngày, tháng, năm
                day = Nhap("Nhập ngày: ");
                month = Nhap("Nhập tháng: ");
                year = Nhap("Nhập năm: ");
                Console.Write("Ngày vừa nhập là: {0}/{1}/{2} ", day, month, year);
                valid = CheckDay(day, month, year);
                if (!valid) Console.WriteLine("không hợp lệ. Vui lòng nhập lại!");
            } while (!valid);
            Console.WriteLine("là " + DayOfWeek(day, month, year));
        }
        // Đọc số nguyên
        static int Nhap(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n));
            return n;
        }
        // Kiểm tra năm nhuận
        static bool IsLeapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
        }
        // Kiểm tra tính hợp lệ của ngày tháng năm
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
        // Xác định thứ dựa trên thuật toán Sakamoto
        static string DayOfWeek(int d, int m, int y)
        {
            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            if (m < 3) y--;
            int r = (y + y / 4 - y / 100 + y / 400 + t[m - 1] + d) % 7;
            string[] Day = { "Chủ nhật", "thứ Hai", "thứ Ba", "thứ Tư", "thứ Năm", "thứ Sáu", "thứ Bảy" };
            return Day[r];
        }
    }
}
