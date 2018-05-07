using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_and_River
{
    class Member
    {
        public List<string> list { get; set; }

        public bool Exists(List<string> t , string[] name)
        {
            foreach (var element in name)
            {
                if(! t.Exists((x) => x == element) )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
