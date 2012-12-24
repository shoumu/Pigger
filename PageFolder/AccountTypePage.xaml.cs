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
    /// AccountTypePage.xaml 的交互逻辑
    /// </summary>
    public partial class AccountTypePage : Page
    {
        DBHelper helper;
        List<Entity.AccountType> list;

        public AccountTypePage()
        {
            InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            helper = new DBHelper();
            list = helper.getAllAccountypes();
            showAccountTypeInfo();
        }

        // 显示账目类型信息
        private void showAccountTypeInfo()
        {
            acctypelist.ItemsSource = list;
        }

        // 添加按钮
        private void add_Click(object sender, RoutedEventArgs e)
        {
            typename.IsEnabled = true;
        }


        // 取消按钮
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            typename.Text = null;
            typename.IsEnabled = false;
        }

        // 保存按钮
        private void save_Click(object sender, RoutedEventArgs e)
        {
            string name = typename.Text;
            foreach (Entity.AccountType type in list)
            {
                if (type.TypeName == name)  // 已经存在添加的类型
                {
                    MessageBox.Show("添加的类型已经存在，添加失败！！！");
                    typename.Text = null;
                    typename.IsEnabled = false;
                    return;
                }
                else
                {
                    if (helper.addAccountType(name) == 1) // 添加成功
                    {
                        MessageBox.Show("添加成功");
                        typename.Text = null;
                        typename.IsEnabled = false;
                        list = helper.getAllAccountypes();  // 在左侧显示出来
                        acctypelist.ItemsSource = list;
                        return;
                    }
                    else // 添加不成功
                    {
                        MessageBox.Show("添加失败，未知错误！！！");
                        typename.Text = null;
                        typename.IsEnabled = false;
                        return;
                    }
                }
            }
        }
    }

}
