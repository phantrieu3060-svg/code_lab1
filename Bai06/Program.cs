using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Nhập số dòng và số cột cho ma trận
            int n = Nhap("Nhập số dòng (n>0): ");
            int m = Nhap("Nhập số cột (m>0): ");
            // Tạo ma trận ngẫu nhiên
            int[,] matrix = CreateRandomMatrix(n, m, -100, 100);
            int choice;
            do
            {
                //In menu
                Console.WriteLine("=====MENU====");
                Console.WriteLine("1. In ma trận");
                Console.WriteLine("2. Tìm phần tử lớn nhất");
                Console.WriteLine("3. Tìm phần tử nhỏ nhất");
                Console.WriteLine("4. Tìm dòng có tổng lớn nhất");
                Console.WriteLine("5. Tính tổng các số không phải số nguyên tố");
                Console.WriteLine("6. Xóa dòng thứ k");
                Console.WriteLine("7. Xóa cột chứa phần tử lớn nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                //Đọc lựa chọn
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ");
                    continue;
                }
                //Xử lý lựa chọn bằng switch
                switch (choice)
                {
                    case 1:
                        Xuat(matrix);
                        break;
                    case 2:
                        Console.WriteLine("Phần tử lớn nhất là: " + MaxVal(matrix));
                        break;
                    case 3:
                        Console.WriteLine("Phần tử nhỏ nhất là: " + MinVal(matrix));
                        break;
                    case 4:
                        Console.WriteLine("Dòng có tổng lớn nhất là: " + MaxSum(matrix));
                        break;
                    case 5:
                        Console.WriteLine("Tổng các số không phải số nguyên tố là: " + SumNotPrime(matrix));
                        break;
                    case 6:
                        Console.Write("Nhập dòng muốn xóa: ");
                        int k = int.Parse(Console.ReadLine());
                        matrix = RemoveCow(matrix, k);
                        break;
                    case 7:
                        Console.WriteLine("Đã xóa cột chứa phần tử lớn nhất.");
                        matrix = RemoveCol(matrix, MaxVal(matrix, 1));
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;

                }
            } while (choice != 0);
        }
        //Nhập số nguyên dương
        static int Nhap(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        //Tạo ma trận ngẫu nhiên có n*m phần tử, có giá trị thuộc [minVal,maxVal]
        static int[,] CreateRandomMatrix(int n, int m, int minVal, int maxVal)
        {
            var rnd = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rnd.Next(minVal, maxVal + 1);
            return a;
        }
        //In ma trận
        static void Xuat(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        // Trả về phần tử lớn nhất khi mode=0, trả về vị trí cột chứa phần tử lớn nhất nếu mode!=0
        static int MaxVal(int[,] matrix, int mode = 0)
        {
            int maxval = matrix[0, 0];
            int idx = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > maxval)
                    {
                        maxval = matrix[i, j];
                        idx = j;
                    }
            if (mode == 0) return maxval;
            return idx;
        }
        // Trả về phần tử nhỏ nhất
        static int MinVal(int[,] matrix)
        {
            int minval = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    if (matrix[i, j] < minval) minval = matrix[i, j];
            return minval;
        }
        // Vị trí dòng có tổng các phần tử lớn nhất
        static int MaxSum(int[,] matrix)
        {
            int idx = 0;
            int summax = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                summax += matrix[0, i];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];
                if (sum > summax)
                {
                    summax = sum;
                    idx = i;
                }
            }
            return idx;
        }
        // Kiểm tra số nguyên tố
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        // Tính tổng các phần tử không phải số nguyên tố
        static int SumNotPrime(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (!IsPrime(matrix[i, j])) sum += matrix[i, j];
            return sum;
        }
        // Xóa dòng của ma trận
        static int[,] RemoveCow(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] tmp = new int[n - 1, m];
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    tmp[row, j] = matrix[i, j];
                row++;
            }
            return tmp;
        }
        // Xóa cột của ma trận
        static int[,] RemoveCol(int[,] matrix, int idx)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] tmp = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int col = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == idx) continue;
                    tmp[i, col] = matrix[i, j];
                    col++;
                }
            }
            return tmp;
        }
    }
}
