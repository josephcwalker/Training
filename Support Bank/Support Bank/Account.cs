﻿using System;

namespace Support_Bank
{
    using System.Collections.Generic;
    public class Account
    {

   public Account(string name)
   {
       m_Name = name;

       m_Incomings = new List<Transaction>();
       m_Outgoings = new List<Transaction>();
   }

   public void HandleIncoming(ref Transaction transaction)
   {
       m_Incomings.Add(transaction);
       m_TotalIncomings += transaction.GetAmount();
   }
   
   public void HandleOutgoing(ref Transaction transaction)
   {
       m_Outgoings.Add(transaction);
       m_TotalOutgoings += transaction.GetAmount();
   }
   
   // Getter 
   
   // Determines and sets total account balance
   public void CalculateAccountBalance()
   {
       m_AccountBalance = m_TotalIncomings - m_TotalOutgoings;
   }
       // Prints formatted account info to console

   public void PrintSimpleInfo()
   {
       Console.WriteLine($"Account Name: {m_Name} \r\n Owing: {m_TotalOutgoings} \r\n Owed: {m_TotalIncomings}");
       if (m_AccountBalance < 0)
       {
           Console.WriteLine($"After settling, {m_Name} will owe {-m_AccountBalance}");
       }
       else if (m_AccountBalance > 0)
       {
           Console.WriteLine($"After settling, {m_Name} will be owed {m_AccountBalance}");
       }
       else
       {
           Console.WriteLine($"Hey, {m_Name} broke even!");
       }
   }
   
   public void PrintAllInfo()
   {
       foreach (Transaction tr in m_Outgoings)
       {
           var onlyDate = tr.GetDate().ToString("dd/MM/yyyy");
           var amountFormatted = string.Format("{0:0.00}", tr.GetAmount());
           Console.WriteLine($"{onlyDate} - £{amountFormatted} going to {tr.GetReceiver().m_Name} - {tr.GetNarrative()}");
       }
   }
   
   // Members
   private List<Transaction> m_Incomings;
   private List<Transaction> m_Outgoings;
   
   private string m_Name = "";
   private float m_TotalIncomings = 0;
   private float m_TotalOutgoings = 0;
   private float m_AccountBalance = 0;
    }
}