using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pigger.PageFolder
{
    /// <summary>
    /// ReportPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReportPage : Page
    {
        string currentUser; // 当前用户
        Entity.DrawData accData;   // 账目信息
        Entity.BudgetDrawData budData; // 预算信息

        double budinValue = 0.0;
        double budoutValue = 0.0;
        double accinValue = 0.0;
        double accoutValue = 0.0;



        // 初始化
        public ReportPage(string usr)
        {
            InitializeComponent();
            currentUser = usr;

            accData = new Entity.DrawData(currentUser);
            budData = new Entity.BudgetDrawData(currentUser);

            initialize();
        }

        public void initialize()
        { 
            // 结算日期
            date.Content = DateTime.Now.ToShortDateString();

            // 年份的绑定
            List<string> yearListTemp1 = accData.YearList;
            List<int> yearListTemp2 = budData.YearList;
            foreach (int i in yearListTemp2)
            {
                string m = Convert.ToString(i);
                if (yearListTemp1.Contains(m)) // 如果第一个中已经包含了
                    continue;
                else
                    yearListTemp1.Add(m);
            }
            year.ItemsSource = yearListTemp1;  // 绑定年份数据

            // 月份的绑定
            List<string> monthListTemp1 = accData.MonthList;
            List<int> monthListTemp2 = budData.MonthList;
            foreach (int i in monthListTemp2)
            {
                string m = Convert.ToString(i);
                if (monthListTemp1.Contains(m)) // 如果第一个中已经包含了
                    continue;
                else
                    monthListTemp1.Add(m);
            }

            month.ItemsSource = monthListTemp1;  // 绑定月份数据



            // 初始显示的是当月的情况
            string[] temp = DateTime.Now.ToShortDateString().Split('-');


            budinValue = getBudgetData(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), "收入");
            budoutValue = getBudgetData(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), "支出");
            accinValue = getAccountData(temp[0], temp[1], "收入");
            accoutValue = getAccountData(temp[0], temp[1], "支出");

            budin.Content = budinValue;
            budout.Content = budoutValue;
            accin.Content = accinValue;
            accout.Content = accoutValue;
            remain.Content = accinValue - accoutValue;

        }

        public double getBudgetData(int year,int month,string type)
        {
            Dictionary<string, double> temp = budData.getDrawData(year, month, type);
            double money = 0.0;
            foreach (KeyValuePair<string, double> tmp in temp)
            {
                money += tmp.Value;
            }
            return money;
        }

        public double getAccountData(string year, string month, string type)
        {
            Dictionary<string, double> temp = accData.getDrawData(year, month, type);
            double money = 0.0;
            foreach (KeyValuePair<string, double> tmp in temp)
            {
                money += tmp.Value;
            }
            return money;
        }

        // 查看以前的月份的记录
        private void see_Click(object sender, RoutedEventArgs e)
        {
            string yearValue = year.Text;
            string monthValue = month.Text;

            if (yearValue == "" || monthValue == "")
            {
                MessageBox.Show("选择的数据不完全！！！");
                return;
            }
            else
            {
                budinValue = getBudgetData(Convert.ToInt32(yearValue), Convert.ToInt32(monthValue), "收入");
                budoutValue = getBudgetData(Convert.ToInt32(yearValue), Convert.ToInt32(monthValue), "支出");
                accinValue = getAccountData(yearValue, monthValue, "收入");
                accoutValue = getAccountData(yearValue, monthValue, "支出");

                budin.Content = budinValue;
                budout.Content = budoutValue;
                accin.Content = accinValue;
                accout.Content = accoutValue;
                remain.Content = accinValue - accoutValue;
            }         
        }
    }
}
