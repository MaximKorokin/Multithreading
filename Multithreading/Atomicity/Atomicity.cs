using System;
using System.Threading;

namespace Multithreading.Atomicity
{
    static class Atomicity
    {
        private static Bank bank = new Bank();
        private const decimal DefaultMoney = 1000;

        public static void Run()
        {
            bank.CreateAccount("John", DefaultMoney);
            bank.CreateAccount("Alice", DefaultMoney);
            Console.WriteLine($"John has {DefaultMoney} money and Alice has {DefaultMoney} money.");
            var readThread = new Thread(ReadFromBank);
            var writeThread = new Thread(WriteToBank);
            readThread.Start();
            writeThread.Start();
            readThread.Join();
            writeThread.Join();
        }

        private static void ReadFromBank()
        {
            decimal johnMoney;
            decimal aliceMoney;
            for (int i = 0; i < 50000; i++)
            {
                johnMoney = bank.GetAccountMoney("John");
                aliceMoney = bank.GetAccountMoney("Alice");
                if (johnMoney + aliceMoney != DefaultMoney * 2)
                {
                    Console.WriteLine($"Error: John has {johnMoney} money and Alice has {aliceMoney} money.");
                }
            }
        }

        private static void WriteToBank()
        {
            var rand = new Random();
            for (int i = 0; i < 50000; i++)
            {
                bank.MakeTransaction("John", "Alice", rand.Next(1, 10));
                bank.MakeTransaction("Alice", "John", rand.Next(1, 10));
            }
        }
    }
}
