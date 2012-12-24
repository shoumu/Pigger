using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{
    class BudgetDrawData
    {
        string currentUser;  // 当前用户
        Commons common;
        List<ShowBudget> showBudgetList;
        public List<int> YearList {get;set;}
        public List<int> MonthList { get; set; }

        // 初始化
        public BudgetDrawData(string str) 
        {
            currentUser = str;
            common = new Commons(currentUser);
            showBudgetList = common.ShowBudgetList;
            initialize();
        }

        public void initialize()
        {
            YearList = new List<int>();
            MonthList = new List<int>();
            foreach (ShowBudget bud in showBudgetList)
            {
                if (!YearList.Contains(bud.Year))  // 往year中添加元素
                    YearList.Add(bud.Year);
                if (!MonthList.Contains(bud.Month))
                    MonthList.Add(bud.Month);
            }
        }

        public Dictionary<string,double> getDrawData(int year, int month,string type)
        {
            //List<KeyValuePair<string, double>> lists = new List<KeyValuePair<string, double>>();
            Dictionary<string,double> maps = new Dictionary<string,double>();
            foreach (ShowBudget bud in showBudgetList)
            {
                if (bud.InOutName != type)  // 对于收入的项直接过滤掉
                {
                    continue;
                }
                
                if (bud.Year != year || bud.Month != month)  // 时间不同的就过滤
                {
                    continue;
                }

                if (maps.ContainsKey(bud.TypeName))
                {
                    maps[bud.TypeName] += bud.Money;
                }
                else
                {
                    maps.Add(bud.TypeName, bud.Money);
                }
            }
            return maps;
        }
    }
}
