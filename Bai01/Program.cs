using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            // Nhập số nguyên dương n
            n = Input();
            int[] arr = CreateRandomArray(n);
            int choice;
            // In menu
            do
            {
                Console.WriteLine("======Menu======");
                Console.WriteLine("1. In mảng");
                Console.WriteLine("2. Tính tổng các số lẻ");
                Console.WriteLine("3. Đếm số nguyên tố trong mảng");
                Console.WriteLine("4. Tìm số chính phương nhỏ nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    continue;
                }
                // Đọc lựa chọn
                switch (choice)
                {
                    case 1:
                        Inmang(arr);
                        break;
                    case 2:
                        Console.WriteLine("Tổng các số lẻ là: " + TongSoLe(arr));
                        break;
                    case 3:
                        Console.WriteLine("Số lượng số nguyên tố là: " + SoSNT(arr));
                        break;
                    case 4:
                        Console.WriteLine("Số chính phương nhỏ nhất là: " + SCPMin(arr));
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;

                }
            } while (choice != 0);
        }
        static int Input()
        {
            int n;
            do
            {
                Console.Write("Nhập số phần tử của mảng (n>0): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        //Tạo mảng ngẫu nhiên
        static int[] CreateRandomArray(int n)
        {
            var rnd = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-100, 100 + 1);
            return arr;
        }
        // In mảng
        static void Inmang(int[] arr)
        {
            Console.Write("Mảng: ");
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }
        // Tính tổng các số lẻ
        static int TongSoLe(int[] arr)
        {
            int Sum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 != 0) Sum += arr[i];
            return Sum;
        }
        // Kiểm tra số ngyên tố
        static bool LaSNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        // Đếm số lượng số nguyên tố
        static int SoSNT(int[] arr)
        {
            int Sum = 0;
            for (int i = 0; i < arr.Length; i++)
                if (LaSNT(arr[i]) == true) Sum++;
            return Sum;
        }
        // Kiểm tra số chính phương
        static bool LaSCP(int n)
        {
            int x = (int)Math.Sqrt(n);
            return x * x == n;
        }
        // Tìm số chính phương nhỏ nhất
        static int SCPMin(int[] arr)
        {
            bool flag = false;
            int idx = -1;
            for (int i = 0; i < arr.Length; i++)
                if (LaSCP(arr[i]) == true && flag == false)
                {
                    idx = i;
                    flag = true;
                }
                else if (LaSCP(arr[i]) == true && arr[i] < arr[idx]) idx = i;
            if (flag == false) return -1;
            return arr[idx];
        }
    }
}
