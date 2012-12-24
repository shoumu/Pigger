using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManager dm;
        DBHelper helper;
        List<LoadGroup> groups;

        public MainWindow()
        {
            InitializeComponent();

            initialize();
            dm = new DataManager();
            helper = new DBHelper();

            if (helper.DataBaseTest() == 0)  // 不正常
            {
                MessageBox.Show("数据库没有配置好，请检查，程序将关闭！！！");
                this.Close();
            }
        }

        private void initialize()
        {
            groups = new List<LoadGroup>();
            groups.Add(new LoadGroup(0, "管理员"));
            groups.Add(new LoadGroup(1, "一般用户"));
            group.ItemsSource = groups;
            group.DisplayMemberPath = "Name";
            group.SelectedValuePath = "Id";
            group.SelectedIndex = 1;  // 默认登陆的时候显示的是一般用户
        } 

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            //this.Close();
        }


        private void logon_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(group.SelectedValue.ToString());
            if (!input_Correctly())
            {
                return;
            }
            else
            {
                if (user_Check())
                { 
                    // 进入新的界面
                    int g = Convert.ToInt32(group.SelectedValue);
                    if(g == 0)
                    {
                        AdministratorMainWin admin = new AdministratorMainWin(username.Text);
                        admin.Show();
                    }
                    else if (g == 1)
                    {
                        UserMainWin user = new UserMainWin(username.Text);
                        user.Show();
                    }
                    else
                        MessageBox.Show("发生了未知错误，程序关系！！！");
                    this.Close();
                }
                    
            }
            return;
        }

        // 检查用户输入是否完全
        private bool input_Correctly()
        { 
            
            if(username.Text == "" || passwd.Password == "" )
            {
                MessageBox.Show("输入不完整，请重新输入");
                return false;
            }
            return true ;
        }

        // 检验用户名密码之类的
        private bool user_Check()
        {
            string name = username.Text;
            string pwd = passwd.Password;
            int g = Convert.ToInt32(group.SelectedValue);

            int temp = helper.logonResult(name, pwd, g);
            switch (temp) 
            {
                case 0: MessageBox.Show("不存在的用户名！！！"); return false;
                case 1: MessageBox.Show("所选用户组中不存在该用户！！！"); return false;
                case 2: MessageBox.Show("密码不正确！！！"); return false;
                case 3: return true;
                default: return false;
            }
        }

    }

}
