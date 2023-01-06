using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable.Model
{
    internal record Message
    {
        public string AddText { get; set; }
        public string RemoveText { get; set; }
    }
}
