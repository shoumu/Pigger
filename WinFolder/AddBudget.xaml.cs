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

namespace Pigger.WinFolder
{
    /// <summary>
    /// AddBudget.xaml 的交互逻辑
    /// </summary>
    public partial class AddBudget : Window
    {
        string currentUser;
        Entity.Commons common;
        DBHelper helper;  // 和数据库打交道

        public AddBudget(string name)
        {
            InitializeComponent();
            currentUser = name;
            helper = new DBHelper();
            initialize();
        }

        public void initialize()
        { 
            // 初始化
            common = new Entity.Commons(currentUser);

            // 部分数据绑定
            inout.DisplayMemberPath = "Name";
            inout.SelectedValuePath = "Id";
            inout.ItemsSource = common.InOutList;

            accType.DisplayMemberPath = "TypeName";
            accType.SelectedValuePath = "Id";
            accType.ItemsSource = common.AccountTypeList;

            // 默认情况下只能够做将来5年的预算
            List<int> years = new List<int>();
            string[] temp = DateTime.Now.ToShortDateString().Split('-');
            int yearm = Convert.ToInt32(temp[0]);
            for (int i = 0; i < 5; i++, yearm++) {
                years.Add(yearm);
            }
            year.ItemsSource = years;

            // 添加月份
            List<int> months = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(i);
            }
            month.ItemsSource = months;

        }

        // 取消添加的预算
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // 添加按钮
        private void add_Click(object sender, RoutedEventArgs e)
        {
            // 判断数据是否填写完整
            if (year.Text == "" || month.Text == "" || accType.Text == "" || inout.Text == "" || money.Text == "")
            {
                MessageBox.Show("填入数据不完整！！！");
                return;
            }

            int yearValue;
            int monthValue;
            int inoutValue;
            int accTypeValue;
            double moneyValue;

            try
            {
                yearValue = Convert.ToInt32(year.Text);
                monthValue = Convert.ToInt32(month.Text);
                inoutValue = Convert.ToInt32(inout.SelectedValue);
                accTypeValue = Convert.ToInt32(accType.SelectedValue);
                moneyValue = Convert.ToDouble(money.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("填入的数据存在异常，请重新填写！！！");
                return;
            }

            string[] temp = DateTime.Now.ToShortDateString().Split('-'); // 时间上的判断
            if (yearValue == Convert.ToInt32(temp[0])) {
                if (monthValue < Convert.ToInt32(temp[1]))
                {
                    MessageBox.Show("只能做当月或者以后月份的预算！！！");
                    return;
                }
            }

            int usrid = helper.getUserId(currentUser);
            Entity.Budget budget = new Entity.Budget(usrid, yearValue, monthValue, inoutValue, accTypeValue, moneyValue);

            if (helper.addBudget(budget) == 1)
            {
                MessageBox.Show("插入成功！！！");
                this.Close();
            }
            else
            {
                MessageBox.Show("插入失败！！！");
                this.Close();
            }
            

        }
    }
}
