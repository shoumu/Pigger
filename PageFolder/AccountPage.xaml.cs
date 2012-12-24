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
    /// AccountPage.xaml 的交互逻辑
    /// </summary>
    public partial class AccountPage : Page
    {
        List<Entity.ShowAccount> listShow;
        DBHelper helper;
        string currentUser;
        Entity.Commons common;

        public AccountPage(string str)
        {
            InitializeComponent();
            currentUser = str;
            initialize();
        }

        public void initialize()
        {
            helper = new DBHelper();
            listShow = new List<Entity.ShowAccount>();
            common = new Entity.Commons(currentUser);
            listShow = helper.getAllShowAccount(currentUser);
            accountlist.ItemsSource = listShow;

            // 为收支类型绑定数据
            inoutType.DisplayMemberPath = "Name";
            inoutType.SelectedValuePath = "Id";
            inoutType.ItemsSource = common.InOutList;

            // 这里显示的是用户具有的AccoutType的类型
            accType.DisplayMemberPath = "TypeName";
            accType.SelectedValuePath = "Id";
            accType.ItemsSource = common.InAccTypeList;

            year.ItemsSource = common.YearList;
            month.ItemsSource = common.MonthList;
            day.ItemsSource = common.DayList;
        }

        // 过滤掉一些选择的信息
        private void filter_Click(object sender, RoutedEventArgs e)
        {
            string inoutTypeValue = inoutType.Text;
            string accTypeValue = accType.Text;
            string yearValue = year.Text;
            string monthValue = month.Text;
            string dayValue = day.Text;

            List<Entity.ShowAccount> temp = common.getFinalShowAccountList(inoutTypeValue, accTypeValue, yearValue, monthValue, dayValue);
            if (temp.Count == 0)
            {
                MessageBox.Show("没有匹配条目！！！");
                accountlist.ItemsSource = new List<Entity.ShowAccount>();
            }
            else
                accountlist.ItemsSource = temp;
        }
    }

}
