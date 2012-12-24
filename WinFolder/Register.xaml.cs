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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        DataManager dm;

        public Register()
        {
            InitializeComponent();
            dm = new DataManager();
        }

        // 退出
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // 确认，这里需要完成数据库的操作
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            // 检查输入
            if (!input_Correctly())
            {
                MessageBox.Show("输入存在问题，请重新确认输入！！！");
                return;
            }
            // 用户名是否已经被注册
            if (username_Regerstered()) 
            {
                MessageBox.Show("该用户名已经被注册，请重新设置用户名！！！");
                return;
            }

            int temp = dm.insertUsers(username.Text, realName.Text, passwd.Text, job.Text, 1);
            if (temp == 1)
            {
                MessageBox.Show("注册成功");
                this.Close();
            }
            else 
            {
                MessageBox.Show("出现未知错误，注册失败！！！");
                this.Close();
            }


        }

        // 检查密码输入是否正确
        private bool repeat_Password()
        {
            if (passwd.Text != null && passwd.Text == repeate.Text)
                return true;
            return false;
        }

        // 检查是否已经正确填写了内容
        private bool input_Correctly()
        {
            // 注意这个地方不能够用Text去与null比，否者是一个bug，null表示什么也没有，而""表示空字符串
            if (username.Text != "" && passwd.Text != "" && repeate.Text != "" && realName.Text != "" )  
                return true;
            return false;
        }

        // 检查用户名是否已经注册
        private bool username_Regerstered()
        {
            String name = username.Text;
            String cmdText = @"select * from Users where user_name = '" + name + "'";
            int temp = dm.usernameRegistered(name);
            //MessageBox.Show(temp.ToString());
            if (temp == 0) // 数据库中不存在这样的用户名
                return false;  // 返回false表示该用户名还没有被注册
            else
                return true;  // 用户名已经被注册
        }
    }
}
