using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger.Entity
{
    /*
     * 这个类主要是用来表示收入或者支出的类型
     **/
    class AccountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public AccountType()
        { }

        public AccountType(string name)
        {
            TypeName = name;
        }

        public AccountType(int id, string name)
        {
            Id = id;
            TypeName = name;
        }
    }
}
