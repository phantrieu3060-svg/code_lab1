using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Nhập số nguyên dương n>0
            int n = NhapSoNguyenDuong();
            Console.WriteLine("Tổng các số nguyên tố <n là: " + SumPrimes(n));
        }
        // Đọc số nguyên dương
        static int NhapSoNguyenDuong()
        {
            int n;
            do
            {
                Console.Write("Nhập số nguyên dương n (n>0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 0);
            return n;
        }
        // Kiểm tra số nguyên tố
        static bool isPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        // Tính tổng các số nguyên tố
        static int SumPrimes(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                if (isPrime(i)) sum += i;
            return sum;
        }
    }
}

