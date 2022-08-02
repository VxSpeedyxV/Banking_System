using Bank_System.Dto_s;

namespace Bank_System.Controller
{
    public class Bank_Controller
    {
        static void Main(string[] args)
        {
            
        }

        // User can deposit an amount into an account at a specific bank
        public static Bank_Dto Deposit(double amount, Bank_Dto bankDto)
        {
            // Validate there is an account and bank name.
            if (!string.IsNullOrEmpty(bankDto.AccountId) && !string.IsNullOrEmpty(bankDto.BankName))
            {
                var accountBalance = bankDto.AccountDto.Balance;

                bankDto.AccountDto.Balance = accountBalance + amount;

                return bankDto;
            }
            else
            {
                Console.WriteLine($"Sorry, we could not find the account id {bankDto.AccountId} at the bank {bankDto.BankName} .");
            }

            return bankDto;
        }

        // Transfer between to bank accounts
        public static List<Bank_Dto> Transfer(double amount, List<Bank_Dto> bankDto)
        {
            bool validatedAccounts = Transfer_Account_Checker(bankDto);

            // Validate the accounts exist.
            if (validatedAccounts)
            {
                if(amount <= bankDto[1].AccountDto.Balance)
                {
                    bankDto[0].AccountDto.Balance = bankDto[0].AccountDto.Balance + amount;
                    bankDto[1].AccountDto.Balance = bankDto[1].AccountDto.Balance - amount;

                    return bankDto;
                }
                else
                {
                    Console.WriteLine($"insufficient funds in account {bankDto[1].AccountId} at {bankDto[1].BankName}.");
                }
            }

            return bankDto;
          
        }

        // Withdraw an amount froma specific bank account
        public static Bank_Dto Withdrawal(double amount, Bank_Dto bankDto)
        {
            if (!string.IsNullOrEmpty(bankDto.AccountId) && !string.IsNullOrEmpty(bankDto.BankName))
            {
                // Check if the withdrawl amount is above the limit
                if (amount <= 500)
                {
                    var accountBalance = bankDto.AccountDto.Balance;
                    // Check if there is enough money in the account
                    if (accountBalance >= amount)
                    {
                        bankDto.AccountDto.Balance = accountBalance - amount;


                        return bankDto;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, you have only amount of {accountBalance} in this account! Please try again!");
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, the amount: {amount} is greater than $500. Please try again!");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, we could not find the account id {bankDto.AccountId} at the bank {bankDto.BankName}.");
            }

            return bankDto;

        }

        // Function to validate that there is a bank name and account for transfer.
        public static bool Transfer_Account_Checker(List<Bank_Dto> bankDtos)
        {
            if (string.IsNullOrEmpty(bankDtos[0].AccountId) && string.IsNullOrEmpty(bankDtos[0].BankName))
            {
                Console.WriteLine($"Sorry, we could not find the account id {bankDtos[0].AccountId} at the bank {bankDtos[0].BankName}.");

                return false;
            }

            if (string.IsNullOrEmpty(bankDtos[1].AccountId) && string.IsNullOrEmpty(bankDtos[1].BankName))
            {
                Console.WriteLine($"Sorry, we could not find the account id {bankDtos[1].AccountId} at the bank {bankDtos[1].BankName}.");

                return false;
            }

            else return true;

        }


    }
}
