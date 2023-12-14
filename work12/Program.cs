using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace work12
{
    internal class Program
    {
        static void CountToTen()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
        static async Task<uint> CalculateFactorialAsync(uint n)
        {
            await Task.Delay(8000);
            return await Task.Run(() =>
            {
                uint f = 1;
                for (uint i = 1; i <= n; i++)
                {
                    f *= i;
                }
                return f;
            });
        }
        static uint Square(uint n)
        {
            return n * n;
        }
        static void Main()
        {
            {
                Console.WriteLine("Задача 1:");
                Thread thread1 = new Thread(new ThreadStart(CountToTen));
                Thread thread2 = new Thread(new ThreadStart(CountToTen));
                Thread thread3 = new Thread(new ThreadStart(CountToTen));

                thread1.Start();
                thread2.Start();
                thread3.Start();
            }

            {
                Console.WriteLine("Задача 2:");
                bool flag = false;
                uint n;
                do
                {
                    Console.Write("Введите число: ");
                    flag = uint.TryParse(Console.ReadLine(), out n);
                } while (!flag);
                uint square = Square(n);
                Console.WriteLine($"Квадрат числа: {square}");
                Task<uint> factorialTask = CalculateFactorialAsync(n);
                factorialTask.Wait();
                uint factorial = factorialTask.Result;
                Console.WriteLine($"Факториал числа: {factorial}");
            }

            {
                Console.WriteLine("Задача 3:");
                Ref1 ref1 = new Ref1();
                Type ref1_type = ref1.GetType();
                MethodInfo[] methods = ref1_type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }
}