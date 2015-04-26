using System;
using System.Collections.Generic;
using System.Linq;

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

        public override int GetHashCode()
        {
            if (Processors == null)
            {
                return 0;
            }

            int hash = 19;
            foreach (var foo in Processors)
            {
                hash = hash * 31 + foo.GetHashCode();
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as VectorClock;
            if (other == null)
            {
                return false;
            }
            return Processors.Count == other.Processors.Count && !Processors.Except(other.Processors).Any();
        }

        public override string ToString()
        {
            return String.Format("VectorClock: {0}", String.Join(",", Processors.Select(kv => String.Format("({0} -> {1})",kv.Key, kv.Value))));
        }
    }
}
