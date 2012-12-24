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
    /// BudgetPage.xaml 的交互逻辑
    /// </summary>
    public partial class BudgetPage : Page
    {
        string currentUser; // 表示当前的用户
        Entity.Commons common;


        public BudgetPage(string name)
        {
            InitializeComponent();
            currentUser = name;

            initialze();
        }

        public void initialze()
        {
            common = new Entity.Commons(currentUser);
            budgetlist.ItemsSource = common.ShowBudgetList;

            // 为inout绑定数据
            // 为收支类型绑定数据
            inout.DisplayMemberPath = "Name";
            inout.SelectedValuePath = "Id";
            inout.ItemsSource = common.InOutList;

            // 这里显示的是用户具有的AccoutType的类型
            acctypeName.DisplayMemberPath = "TypeName";
            acctypeName.SelectedValuePath = "Id";
            acctypeName.ItemsSource = common.InBudgetTypeList;


            // Year 和 Month
            year.ItemsSource = common.BudYearList;
            month.ItemsSource = common.BudMonthList;
        }

        // 筛选按钮
        private void fileter_Click(object sender, RoutedEventArgs e)
        {
            string inoutValue = inout.Text;
            string acctypeNameValue = acctypeName.Text;
            int yearValue;
            if (year.Text == "")
                yearValue = 0;
            else
                yearValue = Convert.ToInt32(year.Text);
            int monthValue;
            if (month.Text == "")
                monthValue = 0;
            else
                monthValue = Convert.ToInt32(month.Text);

            List<Entity.ShowBudget> temp = common.getFinalShowBudgetList(inoutValue, acctypeNameValue, yearValue, monthValue);

            if (temp.Count == 0)
            {
                MessageBox.Show("没有匹配条目！！！");
                budgetlist.ItemsSource = new List<Entity.ShowAccount>();
            }
            else
                budgetlist.ItemsSource = temp;
        }
    }
}
