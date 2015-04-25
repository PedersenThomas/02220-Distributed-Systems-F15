using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class VectorClock
    {
        public Dictionary<string, int> Processors { get; set; }

        public VectorClock()
        {
            Processors = new Dictionary<string, int>();
        }

        public int this[string index]
        {
            get
            {
                if (!Processors.ContainsKey(index))
                {
                    Processors[index] = 0;
                }
                return Processors[index];
            }
            set { this.Processors[index] = value; }
        }

        public override string ToString()
        {
            return String.Format("VectorClock: {0}", String.Join(",", Processors.Select(kv => String.Format("({0} -> {1})",kv.Key, kv.Value))));
        }
    }
}
