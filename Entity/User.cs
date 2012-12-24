using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger
{
    /*
     * 这个类用来保存用户的一般信息 
     */
    class User
    {
        public string UserName { set; get; }    // 用户名
        public string Password { get; set; }    // 密码
        public string RealName { get; set; }    // 真实姓名
        public string Job { get; set; }         // 工作
        public int Group { get; set; }          // 用户组

        public User()
        { }

        public User(string name, string passwd, string realname, string job, int group)
        {
            UserName = name;
            Password = passwd;
            RealName = realname;
            Job = job;
            Group = group;
        }
    }
}
