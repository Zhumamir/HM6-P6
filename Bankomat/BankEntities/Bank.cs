using Bankomat.ClientEntities;
using Bankomat.AccountEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.BankEntities
{
    public class Bank
    {
        private List<Client> clients;

        public Bank()
        {
            clients = new List<Client>();
        }

        public void OpenAccount(Client client, string accountNumber, decimal initialBalance)
        {
            clients.Add(client);
            client.Account = new Account(accountNumber, initialBalance);
        }

        public Client GetClientByAccountNumber(string accountNumber)
        {
            return clients.FirstOrDefault(client => client.Account.AccountNumber == accountNumber);
        }

        public bool VerifyPassword(Client client, string password)
        {
            return client.VerifyPassword(password);
        }

        public void Deposit(Client client, decimal amount)
        {
            client.Account.Deposit(amount);
        }

        public bool Withdraw(Client client, decimal amount)
        {
            return client.Account.Withdraw(amount);
        }
    }
}
