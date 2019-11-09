using System;
using System.Collections.Generic;
using System.Threading;

namespace Multithreading.AtomicityAndRaceCondition
{
    static class AtomicityAndRaceCondition
    {
        private static Bank bank = new Bank();
        private static decimal defaultMoney = 1000;

        public static void Run()
        {
            bank.CreateAccount("John", defaultMoney);
            bank.CreateAccount("Alice", defaultMoney);
            Console.WriteLine($"John has {defaultMoney} money and Alice has {defaultMoney} money.");
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
                if (johnMoney + aliceMoney != defaultMoney * 2)
                {
                    Console.WriteLine($"Race condition: John has {johnMoney} money and Alice has {aliceMoney} money.");
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
