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
    /// AddAccount.xaml 的交互逻辑
    /// </summary>
    public partial class AddAccount : Window
    {
        Entity.Commons common;
        DBHelper helper;
        string currentUser;   // 当前使用者的用户名

        public AddAccount(string str)
        {
            InitializeComponent();
            currentUser = str;
            initialize();
        }


        // 初始化工作
        public void initialize()
        {
            common = new Entity.Commons(currentUser);
            helper = new DBHelper();

            inout.DisplayMemberPath = "Name";
            inout.SelectedValuePath = "Id";
            inout.ItemsSource = common.InOutList;

            acctype.DisplayMemberPath = "TypeName";
            acctype.SelectedValuePath = "Id";
            acctype.ItemsSource = common.AccountTypeList;
        }

        // 取消事件
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // 确定事件
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(time.Text);
            if (inout.Text == "" || acctype.Text == "" || time.Text == "" || money.Text == "" || content.Text == "")
            {
                MessageBox.Show("填写信息不完全，请完善！！！");
                return;
            }

            int inoutValue;
            int acctypeValue;
            string timeValue;
            double moneyValue;
            string contentValue;

            // 可能存在输入数据的错误
            try
            {
                inoutValue = Convert.ToInt32(inout.SelectedValue);
                acctypeValue = Convert.ToInt32(acctype.SelectedValue);
                timeValue = time.Text;
                moneyValue = Convert.ToDouble(money.Text);
                contentValue = Convert.ToString(content.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入数据有错，请检查！！！");
                return;
            }
            string[] tmp = timeValue.Split('-');
            DateTime dat = new DateTime(Int32.Parse(tmp[0]), Int32.Parse(tmp[1]), Int32.Parse(tmp[2]));

            Entity.Account acc = new Entity.Account(helper.getUserId(currentUser), acctypeValue,
                inoutValue, moneyValue, contentValue, dat);
            if (helper.addAccountData(acc) == 1)
            {
                MessageBox.Show("插入成功！！！");
                this.Close();
            }
            else
            {
                MessageBox.Show("插入失败！！！");
            }

        }
    }
}
