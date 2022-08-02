using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Dto_s
{
    public class Bank_Dto
    {
        public string BankName { get; set; }
        public string AccountId { get; set; }
        public Account_Dto AccountDto { get; set; } 

    }

    public class Account_Dto
    {
        public string Owner { get; set; }
        public double Balance { get; set; }
        public string AccountType {  get; set; }  
        public string InvestmentType { get; set; }  
    }


       
}
