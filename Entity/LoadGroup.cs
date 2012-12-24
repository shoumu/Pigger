using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigger
{
    // ComboBox数据绑定内部类
    public class LoadGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LoadGroup(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
