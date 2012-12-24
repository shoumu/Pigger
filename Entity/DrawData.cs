using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{
    // 这个类用来处理所有的和画图有关的数据
    class DrawData
    {
        string currentUser;  // 当前用户
        Commons common;
        List<ShowAccount> showAccountList;
        public List<string> YearList {get;set;}
        public List<string> MonthList { get; set; }

        // 初始化
        public DrawData(string str) 
        {
            currentUser = str;
            common = new Commons(currentUser);
            showAccountList = common.ShowAccountList;
            initialize();
        }

        public void initialize()
        {
            YearList = new List<string>();
            MonthList = new List<string>();
            foreach (ShowAccount acc in showAccountList)
            {
                string[] temp = acc.Date.Split('-');
                if (!YearList.Contains(temp[0]))  // 往year中添加元素
                    YearList.Add(temp[0]);
                if (!MonthList.Contains(temp[1]))
                    MonthList.Add(temp[1]);
            }
        }

        public Dictionary<string,double> getDrawData(string year, string month,string type)
        {
            //List<KeyValuePair<string, double>> lists = new List<KeyValuePair<string, double>>();
            Dictionary<string,double> maps = new Dictionary<string,double>();
            foreach (ShowAccount acc in showAccountList)
            {
                if (acc.InOutName != type)  // 对于收入的项直接过滤掉
                {
                    continue;
                }
                string[] temp = acc.Date.Split('-'); // 将时间分割之后用来显示
                if (temp[0] != year || temp[1] != month)  // 时间不同的就过滤
                {
                    continue;
                }

                if (maps.ContainsKey(acc.AccountTypeName))
                {
                    maps[acc.AccountTypeName] += acc.Money;
                }
                else
                {
                    maps.Add(acc.AccountTypeName, acc.Money);
                }
            }
            return maps;
        }

        
    }
}
