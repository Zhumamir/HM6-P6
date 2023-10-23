using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;
using Bankomat.BankEntities;
using Bankomat.ClientEntities;
using Bankomat.AccountEntities;

namespace BankConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Client client = new Client();
            int attempts = Constants.MaxAttempts;

            while (attempts > 0)
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (client.VerifyPassword(password))
                {
                    Console.WriteLine("Logged in successfully.");
                    break;
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Incorrect password. Attempts left: {attempts}");
                }
            }

            if (attempts == 0)
            {
                Console.WriteLine("Login attempts exhausted. Exiting.");
            }
            else
            {
                Account account = client.Account;

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("a. Check balance");
                    Console.WriteLine("b. Deposit");
                    Console.WriteLine("c. Withdraw");
                    Console.WriteLine("d. Exit");

                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 'a':
                            Console.WriteLine($"Balance: {account.GetBalance()}");
                            break;
                        case 'b':
                            Console.Write("Enter deposit amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                if (account.Deposit(depositAmount))
                                {
                                    Console.WriteLine($"Deposited {depositAmount}. New balance: {account.GetBalance()}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid deposit amount.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;
                        case 'c':
                            Console.Write("Enter withdrawal amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                if (account.Withdraw(withdrawAmount))
                                {
                                    Console.WriteLine($"Withdrawn {withdrawAmount}. New balance: {account.GetBalance()}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;
                        case 'd':
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
