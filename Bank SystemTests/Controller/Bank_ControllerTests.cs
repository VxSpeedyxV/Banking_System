using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank_System.Dto_s;

namespace Bank_System.Controller.Tests
{
    [TestClass()]
    public class Bank_ControllerTests
    {
        Bank_Dto bank_Dto1 = new Bank_Dto()
        {
            BankName = "Wells Fargo",
            AccountId = "193837291",

            AccountDto = new Account_Dto()
            {
                Owner = "Micheal Phelps",
                Balance = 500,
                AccountType = "Checking",
                InvestmentType = "Individual"
            }
        };

        Bank_Dto bank_Dto2 = new Bank_Dto()
        {
            BankName = "US Bank",
            AccountId = "193837291",

            AccountDto = new Account_Dto()
            {
                Owner = "Micheal Phelps",
                Balance = 1500.75,
                AccountType = "Checking",
                InvestmentType = "Individual"
            }
        };

        Bank_Dto bank_Dto3 = new Bank_Dto()
        {
            BankName = "",
            AccountId = "193837291",

            AccountDto = new Account_Dto()
            {
                Owner = "Micheal Phelps",
                Balance = 6531.93,
                AccountType = "Checking",
                InvestmentType = "Individual"
            }
        };

        Bank_Dto bank_Dto4 = new Bank_Dto()
        {
            BankName = "Wells Fargo",
            AccountId = "",

            AccountDto = new Account_Dto()
            {
                Owner = "Micheal Phelps",
                Balance = 5034.00,
                AccountType = "Checking",
                InvestmentType = "Individual"
            }
        };

        Bank_Dto bank_Dto5 = new Bank_Dto()
        {
            BankName = "Wells Fargo",
            AccountId = "193837291",

            AccountDto = new Account_Dto()
            {
                Owner = "Micheal Phelps",
                Balance = 50,
                AccountType = "Checking",
                InvestmentType = "Individual"
            }
        };

        [TestMethod()]
        public void DepositTest_Successful_Deposit()
        {
            var prevBalance = bank_Dto1.AccountDto.Balance;
            var result = Bank_Controller.Deposit(400.65, bank_Dto1);

            Assert.AreEqual(result.AccountDto.Balance, (prevBalance + 400.65));
            Assert.AreEqual(result.BankName, bank_Dto1.BankName);
            Assert.AreEqual(result.AccountId, bank_Dto1.AccountId);
            Assert.AreEqual(result.AccountDto.AccountType, bank_Dto1.AccountDto.AccountType);
            Assert.AreEqual(result.AccountDto.Owner, bank_Dto1.AccountDto.Owner);
            Assert.AreEqual(result.AccountDto.InvestmentType, bank_Dto1.AccountDto.InvestmentType);


        }

        [TestMethod()]
        public void DepositTest_No_Account_Fail_Deposit()
        {
            var prevBalance = bank_Dto4.AccountDto.Balance;
            var result = Bank_Controller.Deposit(400.65, bank_Dto1);

            Assert.AreNotEqual(result.AccountDto.Balance, (prevBalance + 400.65));
        }

        [TestMethod()]
        public void TransferTest_Successful_Transfer()
        {
            List<Bank_Dto> bankDtos = new List<Bank_Dto>();
            bankDtos.Add(bank_Dto1);
            bankDtos.Add(bank_Dto3);

            var prevBalance = bank_Dto1.AccountDto.Balance;
            var prevBalance2 = bank_Dto3.AccountDto.Balance;

            var result = Bank_Controller.Transfer(64.23, bankDtos);
            Assert.AreEqual(result[0].AccountDto.Balance, (prevBalance + 64.23));
            Assert.AreEqual(result[1].AccountDto.Balance, (prevBalance2 - 64.23));
        }

        public void TransferTest_Fails_Insufficient_Funds_Transfer()
        {
            List<Bank_Dto> bankDtos = new List<Bank_Dto>();
            bankDtos.Add(bank_Dto1);
            bankDtos.Add(bank_Dto3);

            var prevBalance = bank_Dto1.AccountDto.Balance;
            var prevBalance2 = bank_Dto3.AccountDto.Balance;

            var result = Bank_Controller.Transfer(125, bankDtos);
            Assert.AreNotEqual(result[0].AccountDto.Balance, (prevBalance + 64.23));
            Assert.AreNotEqual(result[1].AccountDto.Balance, (prevBalance2 - 64.23));
        }


        [TestMethod()]
        public void WithdrawTest_Successful_Withdrawl()
        {
            var prevBalance = bank_Dto1.AccountDto.Balance;
            var result = Bank_Controller.Withdrawal(400.65, bank_Dto1);

            Assert.AreEqual(result.AccountDto.Balance, (prevBalance - 400.65));
        }

        public void WithdrawTest_Fails_Insufficient_Funds_Withdrawl()
        {
            var prevBalance = bank_Dto1.AccountDto.Balance;
            var result = Bank_Controller.Withdrawal(400.65, bank_Dto5);

            Assert.AreNotEqual(result.AccountDto.Balance, (prevBalance - 400.65));
        }

        public void WithdrawTest_Fails_Limit_Withdrawl()
        {
            var prevBalance = bank_Dto1.AccountDto.Balance;
            var result = Bank_Controller.Withdrawal(865, bank_Dto3);

            Assert.AreNotEqual(result.AccountDto.Balance, (prevBalance - 865));
        }
    }
}