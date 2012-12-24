using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{
    class Budget
    {
        public int Id { get; set; }         // 预算号
        public int UserId { get; set; }     // 用户号
        public int Year { get; set; }       // 预算的年份
        public int Month { get; set; }      // 预算月份 
        public int InOut { get; set; }      // 支出还是收入
        public int TypeId { get; set; }     // 收支的类型
        public double Money { get; set; }    // 金额

        public Budget()
        { }

        public Budget(int id,int usrid, int year, int month, int inout, int typeid, double money)
        {
            Id = id;
            UserId = usrid;
            Year = year;
            Month = month;
            InOut = inout;
            TypeId = typeid;
            Money = money;
        }

        public Budget(int usrid,int year, int month, int inout, int typeid, double money)
        {
            UserId = usrid;
            Year = year;
            Month = month;
            InOut = inout;
            TypeId = typeid;
            Money = money;
        }

    }

    class ShowBudget
    {
        public int Id { get; set; }  // 预算号
        public int Year { get; set; } // 年份
        public int Month { get; set; } // 月份
        public string InOutName { get; set; }  // 收支类型
        public string TypeName { get; set; }   // 账目类型
        public double Money { get; set; }      // 金额

        public ShowBudget() { }

        public ShowBudget(int id, int year, int month, string inoutname, string typename, double money)
        {
            Id = id;
            Year = year;
            Month = month;
            InOutName = inoutname;
            TypeName = typename;
            Money = money;
        }
    }
}
