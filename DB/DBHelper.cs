using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pigger
{
    class DBHelper
    {
        private readonly string connString = @"server=(local);Integrated Security=true;database=Pigger;uid=sa;pwd=sa";
        private SqlConnection conn;

        // 建立连接
        public DBHelper()
        {
            conn = new SqlConnection(connString);
        }

        // 测试数据库是否正常
        public int DataBaseTest()
        {
            try
            {
                string cmdText = "select * from Users";
                executeNonQuery(cmdText);
                
            }
            catch (Exception)
            {
                return 0;//表示不正常
            }

            return 1; // 表示正常
        }

        // 查询返回的结果的数量
        public int resultNums(string cmdText)
        {
            int result = 0;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result++;
            }
            conn.Close();
            return result;
        }

        public int logonResult(string name,string pwd,int g)
        {
            string cmdText = "select * from Users where user_name = '" + name + "'";
            int result;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (Convert.ToInt32(reader["user_group"]) != g)
                    result = 1;  // 表示用户组不正确
                else {
                    string temp = Convert.ToString(reader["passwd"]);
                    if (temp != pwd)
                        result = 2;  // 密码不正确
                    else
                        result = 3; // 全部匹配
                }
            }
            else
            {
                result = 0; // 表示不存在该用户名
            }
            conn.Close();
            return result;
        }

        // 获取所有的用户信息
        public List<User> getAllUsers()
        {
            List<User> users = new List<User>();
            string cmdText = "select * from Users";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(Convert.ToString(reader["user_name"]), Convert.ToString(reader["passwd"]),
                    Convert.ToString(reader["real_name"]),Convert.ToString(reader["job"]), 
                    Convert.ToInt32(reader["user_group"]));
                users.Add(user);
            }
            conn.Close();
            return users;  // 返回用户的信息
        }

        // 写入修改的用户的信息
        public int changeUserInfo(User user)
        {
            int temp = 0;
            string cmdText = "update Users set passwd = '" + user.Password + "',real_name = '" +
                user.RealName + "', job = '" + user.Job + "', user_group =" + user.Group +
                "where user_name = '" + user.UserName + "'";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            temp = cmd.ExecuteNonQuery();  // 返回更改的行数
            conn.Close();
            return temp;
        }

        // 获取一个用户的账目信息
        public List<Entity.Account> getAllAccount(string name)
        {
            return null;
        }


        // 获取一个账户的账目的能够显示的信息
        public List<Entity.ShowAccount> getAllShowAccount(string name)
        { 
            string cmdText = "select Account.account_date,Account.in_out,AccountType.type_name,Account.account_money,Account.content from Account,AccountType " +
                        "where Account.type_id = AccountType.type_id and Account.user_id = " + getUserId(name);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity.ShowAccount> lists = new List<Entity.ShowAccount>();
            while (reader.Read())
            {
                string temp = Convert.ToString(reader["account_date"]);
                string[] tmp = temp.Split(' ');
                
                int t = Convert.ToInt32(reader["in_out"]);
                string str = null;
                if(t == 0)
                {
                    str = "收入";
                }
                else if(t == 1)
                {
                    str = "支出";
                }
                Entity.ShowAccount acc = new Entity.ShowAccount(tmp[0], str, Convert.ToString(reader["type_name"]),
                    Convert.ToDouble(reader["account_money"]), Convert.ToString(reader["content"]));


                lists.Add(acc);
            }
            conn.Close();
            return lists;
        }

        // 插入预算
        public int addBudget(Entity.Budget budget)
        {
            string cmdText = "insert into Budget(user_id,year,month,in_out,type_id,budget_money) values(" + budget.UserId +
                "," + budget.Year + "," + budget.Month + "," + budget.InOut + "," + budget.TypeId + "," + budget.Money + ")";
            return executeNonQuery(cmdText);
        }

        // 获得所有的预算
        public List<Entity.ShowBudget> getAllShowBudget(string name)
        {
            List<Entity.ShowBudget> lists = new List<Entity.ShowBudget>();
            string cmdText = "select budget_id,year,month,in_out,type_name,budget_money from Budget,AccountType where Budget.type_id = AccountType.type_id and Budget.user_id = " + getUserId(name);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int t = Convert.ToInt32(reader["in_out"]);
                string str = null;
                if (t == 0)
                {
                    str = "收入";
                }
                else if (t == 1)
                {
                    str = "支出";
                }
                Entity.ShowBudget acc = new Entity.ShowBudget(Convert.ToInt32(reader["budget_id"]), Convert.ToInt32(reader["year"]),
                    Convert.ToInt32(reader["month"]), str, Convert.ToString(reader["type_name"]), Convert.ToDouble(reader["budget_money"]));

                lists.Add(acc);
            }
            conn.Close();
            return lists;
        }

        // 获取所有预算中所有的账目类型
        public List<Entity.AccountType> getInBudgetTypeList(string name)
        {
            List<Entity.AccountType> types = new List<Entity.AccountType>();
            string cmdText = "select type_id,type_name from AccountType where type_id in (select type_id from Budget where user_id = (select user_id from Users where user_name = '" + name + "'))";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Entity.AccountType type = new Entity.AccountType(Convert.ToInt32(reader["type_id"]),
                    Convert.ToString(reader["type_name"]));
                types.Add(type);
            }
            conn.Close();
            return types;
        }

        public User getSingleUserInfo(string name)
        {
            string cmdText = "select * from Users where user_name = '" + name + "'";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User(Convert.ToString(reader["user_name"]), Convert.ToString(reader["passwd"]),
                    Convert.ToString(reader["real_name"]), Convert.ToString(reader["job"]),
                    Convert.ToInt32(reader["user_group"]));
            conn.Close();
            return user;
        }

        // 删除用户
        public int deleteUser(string name)
        {
            int temp = 0;
            string cmdText = "delete from Users where user_name = '" + name + "'";
            // 删除所有的该用户的记得账目的信息
            string cmdText2 = "delete from Account where user_id = " + getUserId(name);
            executeNonQuery(cmdText2);  

            // 然后删除和用户有关的信息
            temp = executeNonQuery(cmdText);
            return temp;
        }

        // 得到所有的和账目类型名有关的信息
        public List<Entity.AccountType> getAllAccountypes()
        {
            List<Entity.AccountType> types = new List<Entity.AccountType>();

            string cmdText = "select * from AccountType";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Entity.AccountType type = new Entity.AccountType(Convert.ToInt32(reader["type_id"]),
                    Convert.ToString(reader["type_name"]));
                types.Add(type);
            }
            conn.Close();
            return types;
        }

        // 得到一个用户自己登记过的用户账目信息
        public List<Entity.AccountType> getInAccTypeList(string name)
        {
            List<Entity.AccountType> types = new List<Entity.AccountType>();
            string cmdText = "select type_id,type_name from AccountType where type_id in (select type_id from Account where user_id = (select user_id from Users where user_name = '" + name + "'))";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader() ;
            while (reader.Read())
            {
                Entity.AccountType type = new Entity.AccountType(Convert.ToInt32(reader["type_id"]),
                    Convert.ToString(reader["type_name"]));
                types.Add(type);
            }
            conn.Close();
            return types;
        }

        // 添加账目类型
        public int addAccountType(string name)
        { 
            string cmdText = "insert into AccountType(type_name) values('" + name + "')";
            return executeNonQuery(cmdText);
        }

        public int executeNonQuery(string cmdText)
        {
            int value = 0;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            value = cmd.ExecuteNonQuery();
            conn.Close();
            return value;
        }

        public SqlDataReader executeReader(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            return reader;
        }

        // 获取一个用户名对应的Id
        public int getUserId(string name)
        { 
            string cmdText = "select user_id from Users where user_name = '"+ name +"'";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int value =  Convert.ToInt32(reader["user_id"]);
            conn.Close();
            return value;
        }

        // 插入一条账目信息
        public int addAccountData(Entity.Account acc)
        {
            string cmdText = "insert into Account(user_id,type_id,in_out,account_money,content,account_date)" +
                "values(" + acc.UserId + "," + acc.AccountType + "," + acc.InOut + "," + acc.Money + ",'" +
                acc.Content + "','" + acc.Date.ToShortDateString() + "')";
            return executeNonQuery(cmdText);
        }


        // 获取数据集合
        public DataSet executeDataSet(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        // 获得表中的一行
        public DataTable executeDataTable(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public int getMaxID(string cmdText)
        {
            int value;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.IsDBNull(0))
                value = -1;  // 取得当前id的号，后面便于插入
            else
                value = reader.GetInt32(0);
            conn.Close();
            return value;
        }

    }
}
