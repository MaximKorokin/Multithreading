using System;
using System.Collections.Generic;
using System.Text;

namespace Multithreading.AtomicityAndRaceCondition
{
    class Bank
    {
        private Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

        // non-atomic operation
        public void MakeTransaction(string fromAccount, string toAccount, decimal sum)
        {
            if (accounts[fromAccount] < sum)
            {
                return;
            }
            accounts[fromAccount] -= sum;
            accounts[toAccount] += sum;
        }

        public decimal GetAccountMoney(string account)
        {
            return accounts[account];
        }

        public void CreateAccount(string account, decimal money)
        {
            accounts.Add(account, money);
        }
    }
}
