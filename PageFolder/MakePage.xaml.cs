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
    /// MakePage.xaml 的交互逻辑
    /// </summary>
    public partial class MakePage : Page
    {
        string currentUser;
        Entity.DrawData data;

        // 初始化
        public MakePage(string str)
        {
            InitializeComponent();
            currentUser = str;
            data = new Entity.DrawData(currentUser);

            string[] temp = DateTime.Now.ToShortDateString().Split('-');
            

            BindingData(temp[0],temp[1]);
            year.ItemsSource = data.YearList;
            month.ItemsSource = data.MonthList;
        }

        // 给绘图的绑定数据
        public void BindingData(string year,string month)
        {
            this.DataContext = data.getDrawData(year,month,"收入");
        }

        // 点击查看的时候显示
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            string yearValue = year.Text;
            string monthValue = month.Text;

            if (yearValue == "" || monthValue == "")  // 判断是否时间和月份都填写
            {
                MessageBox.Show("请选择年份和月份！！！");
                return;
            }

            Dictionary<string, double> temp = data.getDrawData(yearValue, monthValue,"收入");
            if (temp.Count == 0)  // 表示没有相关的数据
            {
                MessageBox.Show("不存在相关的数据！！！");
            }
            else
            {
                this.DataContext = temp;
            }

        }
    }
}
