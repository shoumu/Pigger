using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Pigger
{
    class DataManager
    {
        DBHelper helper;

        public DataManager()
        {
            helper = new DBHelper();
        }

        // 得到查询返回有多少个结果
        public int usernameRegistered(string str)
        {
            int result = 0;
            string cmdText = "select * from Users where user_name = '" + str + "'";
            result = helper.resultNums(cmdText);
            return result;
        }

        // 加入所有的插入操作
        public void insertAccountType(string accountName)
        {
            string cmdText = string.Format("insert into AccountType values('{0}')", accountName);
            helper.executeNonQuery(cmdText);
        }

        public int insertUsers(string userName, string realNanme, string passwd, string job, int group)
        {
            string cmdText = string.Format("insert into Users(user_name,real_name,passwd,job,user_group) values('{0}','{1}','{2}','{3}',{4})",
                userName, realNanme, passwd, job, group); // 插入的时候，都是默认的一般用户
            return helper.executeNonQuery(cmdText);
        }

        public void insertBudget(int year, int month, int in_out, int type_id, float money)
        {
            string cmdText = string.Format("insert into Budget values({0},{1},{2},{3},{4})",
                year, month, in_out, type_id, money);
            helper.executeNonQuery(cmdText);
        }

        public void insertAccount(int user, int type_id, int in_out, float money, string content, DateTime time)
        {
            string cmdText = string.Format("insert into Account values({0},{1},{2},{3},'{4}','{5}')",
                user, type_id, in_out, money, content, time.Date.ToShortDateString());
            helper.executeNonQuery(cmdText);
        }

        // 现在加入删除操作
        public void deleteUser(int id)  // 通过编号删除
        {
            string cmdText = string.Format("delete from Users where user_id = {0}", id); // 删除一个用户的时候，默认删除这个用户所有的使用记录
            string cmdText1 = string.Format("delete from Account where user_id = {0}", id);
            helper.executeNonQuery(cmdText1);
            helper.executeNonQuery(cmdText);
        }

        public void deleteUser(string name)
        {
            string cmdText = string.Format("delete from Users where user_name = '{0}'", name);
            helper.executeNonQuery(cmdText);
        }

        public void deleteAccount(int id)
        {
            string cmdText = string.Format("delete from Account where account_id = {0}", id);
            helper.executeNonQuery(cmdText);
        }

        public void deleteBudget(int id)
        {
            string cmdText = string.Format("delete from Budget where budget_id = {0}", id);
            helper.executeNonQuery(cmdText);
        }

        public void deleteAccountType(int id)
        {
            string cmdText = string.Format("delete from AccountType where type_id = {0}", id);
            helper.executeNonQuery(cmdText);
        }

        public void deleteAccountType(string name)
        {
            string cmdText = string.Format("delete from AccountType where type_name = '{0}'", name);
            helper.executeNonQuery(cmdText);
        }


        // 下面加入修改操作
        public void updateAccountType(int id, string name)
        {
            string cmdText = string.Format("update AccountType set type_name = '{0}' where type_id = {1}", name, id);
            helper.executeNonQuery(cmdText);
        }

        public void updateUser(string name, string passwd, string realName, string job, int group)  // 默认用户名不能够更改
        {
            string cmdText = string.Format("update Users set real_name = '{0}',passwd = '{1}',job = '{2}',user_group={3} where user_name = '{4}'",
                realName, passwd, job, group, name);
            helper.executeNonQuery(cmdText);
        }

        // 对于预算只能够保存更改的金额类型
        public void updateBudget(int id, int type, float money)
        {
            string cmdText = string.Format("update Budget set type_id = {0},budget_money = {1} where budget_id = {2}",
                type, money, id);
            helper.executeNonQuery(cmdText);
        }

        public void updateAccount(int id, int type_id, int in_out, float money, string content, DateTime date)
        {
            string cmdText = string.Format("update Account set type_id = {0},in_out = {1},account_money = {2},content='{3}',account_date = '{4}' where account_id = {5}",
                type_id, in_out, money, content, date.Date.ToShortDateString(), id);
            helper.executeNonQuery(cmdText);
        }
    }
}
