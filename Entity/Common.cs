using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{
    class InOutType
    {
        public int Id { get; set; }        // 类型id
        public string Name { get; set; }   // 类型名称

        public InOutType()
        { }

        public InOutType(int i, string m)
        {
            Id = i;
            Name = m;
        }
    }

    /*
     * 这个类主要是用来获取一些数据
     * */
    class Commons
    {
        public List<InOutType> InOutList { get; set; }
        public List<AccountType> AccountTypeList { get; set; }  // 这一点表示所有的账目的列表
        public List<AccountType> InAccTypeList { get; set; }  // 这个表示当前用户记录过的账目
        public List<string> YearList { get; set; } // 这个用户的年份
        public List<string> MonthList { get; set; } // 用户时间的月份
        public List<string> DayList { get; set; } // 日子

        public List<Entity.ShowAccount> ShowAccountList { get; set; }// 这个表示用户的账目的list
        //public List<Entity.ShowAccount> FinalShowAccountList { get; set; } // 最终显示的用户的列



        // 和Budget相关的列表
        public List<Entity.ShowBudget> ShowBudgetList { get; set; }  // 这里表示预算的列表
        public List<AccountType> InBudgetTypeList { get; set; }  // 预算中存在的账目的类型
        public List<int> BudYearList { get; set; } // 预算中的具有的年份
        public List<int> BudMonthList { get; set; }   // 预算中具有的月份   


        DBHelper helper;
        string currentUser;

        public Commons(string name)
        {
            helper = new DBHelper();
            InOutList = new List<InOutType>();
            YearList = new List<string>();
            MonthList = new List<string>();
            DayList = new List<string>();
            
            currentUser = name;

            InOutList.Add(new InOutType(0, "收入"));
            InOutList.Add(new InOutType(1, "支出"));
            AccountTypeList = helper.getAllAccountypes();
            getInAccTypeList();
            ShowAccountList = helper.getAllShowAccount(currentUser);
            getYearMonthDayList();

            BudgetInitialize();
        }

        // 获取预算的年份和月份信息
        public void getBudgetYearMonthList()
        {
            BudYearList = new List<int>();
            BudMonthList = new List<int>();
            foreach (Entity.ShowBudget budget in ShowBudgetList)
            {
                if (!BudMonthList.Contains(budget.Month))
                {
                    BudMonthList.Add(budget.Month);
                }

                if (!BudYearList.Contains(budget.Year))
                {
                    BudYearList.Add(budget.Year);
                }
            }
        }

        public void getInBudgetTypeList()
        {
            InBudgetTypeList = helper.getInBudgetTypeList(currentUser);
        }

        public void BudgetInitialize()
        {
            ShowBudgetList = helper.getAllShowBudget(currentUser);

            getInBudgetTypeList();
            getBudgetYearMonthList();

        }

        public void getInAccTypeList()
        {
            InAccTypeList = helper.getInAccTypeList(currentUser);
        }

        public void getYearMonthDayList()
        {
            foreach (Entity.ShowAccount show in ShowAccountList)
            {
                string[] temp = show.Date.Split('-');
                if (!YearList.Contains(temp[0]))       
                {
                    YearList.Add(temp[0]);
                }
                if (!MonthList.Contains(temp[1]))
                {
                    MonthList.Add(temp[1]);
                }
                if (!DayList.Contains(temp[2]))
                {
                    DayList.Add(temp[2]);
                }
            }
        }

        // 获取筛选后要显示的结果
        public List<ShowAccount> getFinalShowAccountList(string inout, string acctype, string year, string month, string day)
        {
            List<Entity.ShowAccount> FinalShowAccountList = new List<ShowAccount>();
            foreach (Entity.ShowAccount show in ShowAccountList)
            {
                if (inout != "")
                    if (show.InOutName != inout)
                        continue;
                if (acctype != "")
                    if (show.AccountTypeName != acctype)
                        continue;
                string[] temp = show.Date.Split('-');
                if (year != "")
                    if (temp[0] != year)
                        continue;
                if (month != "")
                    if (temp[1] != month)
                        continue;
                if (day != "")
                    if (temp[2] != day)
                        continue;
                FinalShowAccountList.Add(show);
            }
            return FinalShowAccountList;
        }

        // 获取筛选后的要显示预算信息
        public List<ShowBudget> getFinalShowBudgetList(string inout, string acctype, int year, int month)
        {
            List<Entity.ShowBudget> final = new List<ShowBudget>();
            foreach (Entity.ShowBudget show in ShowBudgetList)
            {
                if (inout != "")
                    if (show.InOutName != inout)
                        continue;
                if (acctype != "")
                    if (show.TypeName != acctype)
                        continue;
                if (year != 0)
                    if (show.Year != year)
                        continue;
                if (month != 0)
                    if (show.Month != month)
                        continue;
                final.Add(show);
            }
            return final;
        }
    }
}
