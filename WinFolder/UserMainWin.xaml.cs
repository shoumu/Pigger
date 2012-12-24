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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Pigger
{
    /// <summary>
    /// UserMainWin.xaml 的交互逻辑
    /// </summary>
    public partial class UserMainWin : Window
    {
        string usrname;  // 当前用户的用户名


        public UserMainWin(string name)
        {
            InitializeComponent();
            usrname = name;
            PageFolder.UserInfo uinfo = new PageFolder.UserInfo(usrname);
            this.frame.Navigate(uinfo);
        }

        // 显示用户信息
        private void userinfo_Click(object sender, RoutedEventArgs e)
        {
            //this.frame.Source = new Uri("/PageFolder/UserInfo.xaml", UriKind.Relative);
            PageFolder.UserInfo uinfo = new PageFolder.UserInfo(usrname);
            this.frame.Navigate(uinfo);
        }

        // 显示所有账目类型信息
        private void acctype_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.AccountTypePage acc = new PageFolder.AccountTypePage();
            frame.Navigate(acc);
        }

        // 显示所有账目信息
        private void allAccount_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.AccountPage page = new PageFolder.AccountPage(usrname);
            this.frame.Navigate(page);
        }

        // 添加账目
        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            WinFolder.AddAccount addacc = new WinFolder.AddAccount(usrname);
            addacc.Show();
        }

        // 添加预算
        private void addBudget_Click(object sender, RoutedEventArgs e)
        {
            WinFolder.AddBudget addbud = new WinFolder.AddBudget(usrname);
            addbud.Show();
        }

        // 显示所有的预算界面
        private void allBudget_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.BudgetPage page = new PageFolder.BudgetPage(usrname);
            frame.Navigate(page);
        }

        // 支出的柱状图
        private void spend_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.SpendPage page = new PageFolder.SpendPage(usrname);
            frame.Navigate(page);
        }

        // 收入的柱状图
        private void make_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.MakePage page = new PageFolder.MakePage(usrname);
            frame.Navigate(page);
        }

        // 支出的实际与预算对比
        private void accbud_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.AccBudgetPage page = new PageFolder.AccBudgetPage(usrname);
            frame.Navigate(page);
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            PageFolder.ReportPage page = new PageFolder.ReportPage(usrname);
            frame.Navigate(page);
        }
    }
}
