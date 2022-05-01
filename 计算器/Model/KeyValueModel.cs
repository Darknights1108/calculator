using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算器.modules
{
    public class KeyValueModel
    {
        public string Key { get; set; }
        public long Value { get; set; }

        public new string ToString()
        {
            return this.Value.ToString() + this.Key;
        }
    }
}
