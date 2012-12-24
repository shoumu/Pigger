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
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : Page
    {
        string usrname;  // 这个真是一个麻烦的事啊
        DBHelper helper;
        bool modify = false; // 表示是否在更改用户资料

        public UserInfo(string name)
        {
            InitializeComponent();
            usrname = name;
            initialize();  // 调用初始话函数
        }

        // 初始化的一些工作，这里稍显麻烦了一些
        public void initialize()
        {
            helper = new DBHelper();
            showUserInfo();
        }
        
        // 更改用户的信息
        private void change_Click(object sender, RoutedEventArgs e)
        {
            //username.IsEnabled = true;  //用户名不能够更改
            passwd.IsEnabled = true;
            repeatpwd.IsEnabled = true;
            realname.IsEnabled = true;
            job.IsEnabled = true;
            modify = true;
        }

        // 显示用户的信息
        private void showUserInfo()
        {
            User user = helper.getSingleUserInfo(usrname);
            username.Text = user.UserName;
            passwd.Text = user.Password;
            realname.Text = user.RealName;
            job.Text = user.Job;
            group.Text = "一般用户";
        }


        // 保存用户修改的信息
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (modify)  // 如果更改了用户信息
            {
                User user = new User();
                if (passwd.Text != repeatpwd.Text)
                {
                    MessageBox.Show("输入的密码有错，请检查！！！");
                    return;
                }
                user.UserName = username.Text;
                user.Password = passwd.Text;
                user.RealName = realname.Text;
                user.Job = job.Text;
                user.Group = 1;   // 一般用户不能够更在自己的用户组，所以这个地方就少了很多工作了。
                if (helper.changeUserInfo(user) == 1)
                {
                    MessageBox.Show("修改成功！！！");
                    username.IsEnabled = false;
                    passwd.IsEnabled = false;
                    realname.IsEnabled = false;
                    repeatpwd.IsEnabled = false;
                    job.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("修改失败！！！");
                }
            }
            return;
        }



    }
}
