using CommandPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CommandPattern.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void History()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            Queue<ICommand> commands = new Queue<ICommand>();

            commands.Enqueue(new DepositCommand(bankAccount, 100));
            commands.Enqueue(new WithdrawCommand(bankAccount, 100));
            commands.Enqueue(new DepositCommand(bankAccount, 200));
            commands.Enqueue(new DepositCommand(bankAccount, 100));
            commands.Enqueue(new WithdrawCommand(bankAccount, 50));

            // Act

            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                {
                    command.Execute();
                }
            }

            //foreach (ICommand command in commands)
            //{
            //    if (command.CanExecute())
            //    {
            //        command.Execute();
            //    }
            //}

            
            var result = bankAccount.GetBalance();

            // Assert
            Assert.AreEqual(250, result);
        }

        [TestMethod]
        public void Withdraw_OverdraftLimit_ShouldThrowsApplicationException()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();


            ICommand command = new DepositCommand(bankAccount, 100);

            // Act
            Action act = () => command.Execute();

            // Assert
            Assert.ThrowsException<ApplicationException>(act);
        }
    }
}
