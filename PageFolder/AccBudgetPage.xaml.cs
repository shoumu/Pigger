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
    /// AccBudgetPage.xaml 的交互逻辑
    /// </summary>
    public partial class AccBudgetPage : Page
    {
        string currentUser;
        Entity.DrawData accData;
        Entity.BudgetDrawData budData;


        public AccBudgetPage(string usr)
        {
            InitializeComponent();
            currentUser = usr;

            accData = new Entity.DrawData(currentUser);
            budData = new Entity.BudgetDrawData(currentUser);

            initialize();

            string[] temp = DateTime.Now.ToShortDateString().Split('-');
            spend.ItemsSource = accData.getDrawData(temp[0], temp[1], "支出");
            budspend.ItemsSource = budData.getDrawData(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), "支出");
        }

        public void initialize()
        {
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

        }

        // 确认
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            string yearValue = year.Text;
            string monthValue = month.Text;

            if (yearValue == "" || monthValue == "")  // 判断是否时间和月份都填写
            {
                MessageBox.Show("请选择年份和月份！！！");
                return;
            }

            Dictionary<string, double> temp = accData.getDrawData(yearValue, monthValue, "支出");
            Dictionary<string, double> temp1 = budData.getDrawData(Convert.ToInt32(yearValue), Convert.ToInt32(monthValue), "支出");
            if (temp.Count == 0 && temp1.Count == 0)  // 表示没有相关的数据
            {
                MessageBox.Show("不存在相关的数据！！！");
            }
            else
            {
                //this.DataContext = temp;
                spend.ItemsSource = temp;
                budspend.ItemsSource = temp1;
            }
        }
    }
}
