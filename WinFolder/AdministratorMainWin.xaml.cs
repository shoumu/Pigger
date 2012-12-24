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

namespace Pigger
{
    /// <summary>
    /// AdministratorMainWin.xaml 的交互逻辑
    /// </summary>
    public partial class AdministratorMainWin : Window
    {

        DBHelper helper;
        List<User> users;
        List<LoadGroup> groups;
        string currentUser;
        bool modify = false;

        public AdministratorMainWin(string name)
        {
            InitializeComponent();
            currentUser = name;
            initialize();
        }

        // 初始化函数，这里主要是不想要在构造函数中完成过多的工作才另外写出来的
        private void initialize()
        {
            helper = new DBHelper();
            groups = new List<LoadGroup>();
            
            // 设置group的数据绑定
            groups.Add(new LoadGroup(0, "管理员"));
            groups.Add(new LoadGroup(1, "一般用户"));
            group.ItemsSource = groups;
            group.DisplayMemberPath = "Name";
            group.SelectedValuePath = "Id";

            // 显示初始的用户列表
            listUsers();
            showUserInfo(currentUser);
        }

        // 在listbox中显示出所有的用户
        private void listUsers()
        {
            users = helper.getAllUsers(); // 获取所有的用户
            foreach (User user in users)
            {
                userlist.Items.Add(user.UserName);
            }
        }

        // 在右侧详细信息地方显示一个用户的详细信息
        private void showUserInfo(string name)
        {
            User usr = null ;
            foreach (User user in users) {
                if (user.UserName == name)
                    usr = user;
            }
            username.Text = usr.UserName;
            passwd.Text = usr.Password;
            realname.Text = usr.RealName;
            job.Text = usr.Job;
            group.SelectedIndex = usr.Group;
        }

        // 修改用户信息
        private void chang_Click(object sender, RoutedEventArgs e)
        {
            //username.IsEnabled = true; // 默认用户名不能够修改
            passwd.IsEnabled = true;
            changepwd.IsEnabled = true;
            realname.IsEnabled = true;
            job.IsEnabled = true;
            group.IsEnabled = true;
            modify = true;
        }

        // 退出用户管理界面
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        // 保存修改的用户信息
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (modify)  // 如果更改了用户信息
            {
                User user = new User();
                if (passwd.Text != changepwd.Text)
                {
                    MessageBox.Show("输入的密码有错，请检查！！！");
                    return;
                }
                user.UserName = username.Text;
                user.Password = passwd.Text;
                user.RealName = realname.Text;
                user.Job = job.Text;
                user.Group = Convert.ToInt32(group.SelectedValue);   // 这一项还有待改变
                if (helper.changeUserInfo(user) == 1)
                {
                    MessageBox.Show("修改成功！！！");
                }
                else
                {
                    MessageBox.Show("修改失败！！！");
                }
            }
            return;
        }

        // 删除用户选项
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("删除用户将删除所有与之对应的数据，继续？", "确定", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;
            string name = userlist.SelectedItem.ToString();
            if (helper.deleteUser(name) == 1)
            {
                MessageBox.Show("删除用户成功！！！");
                userlist.Items.RemoveAt(userlist.SelectedIndex);
            }
            else
            {
                MessageBox.Show("删除失败！！！");
            }
            return;
        }

        // 用户列表中的选项改变的事件处理程序
        private void userlist_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (userlist.SelectedItem == null)
                showUserInfo(currentUser);
            else
                showUserInfo(userlist.SelectedItem.ToString());   
        }

    }
}
