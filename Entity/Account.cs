using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{

    // 这个是表示数据库中的一条记录
    class Account
    {
        public int AccountId { get; set; }      // 账目编号 
        public int UserId { get; set; }         // 用户号
        public int AccountType { get; set; }    // 账目类型
        public int InOut { get; set; }          // 支出或者收入
        public double Money { get; set; }        // 钱
        public string Content { get; set; }     // 具体的内容
        public DateTime Date { get; set; }      // 使用的时间

        public Account()
        { }

        public Account(int accId, int usrId, int accType, int inout, double money, string content, DateTime time)
        {
            AccountId = accId;
            UserId = usrId;
            AccountType = accType;
            InOut = inout;
            Money = money;
            Content = content;
            Date = time;
        }

        public Account(int usrId, int accType, int inout, double money, string content, DateTime time)
        {
            UserId = usrId;
            AccountType = accType;
            InOut = inout;
            Money = money;
            Content = content;
            Date = time;
        }

    }

    // 表示要显示出来的账目的项
    class ShowAccount
    {
        public string Date { get; set; }          // 日期
        public string InOutName { get; set; }       // 收入或者支出
        public string AccountTypeName { get; set;}   // 账目类型
        public double Money { get; set; }            // 多少钱
        public string Content { get; set; }         // 具体内容

        public ShowAccount()
        { }

        public ShowAccount(string date, string inout, string acctypename, double money, string content)
        {
            Date = date;
            InOutName = inout;
            AccountTypeName = acctypename;
            Money = money;
            Content = content;
        }
    }
}
