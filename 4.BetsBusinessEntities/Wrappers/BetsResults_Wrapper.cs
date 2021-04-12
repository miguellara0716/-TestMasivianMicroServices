using System;
using System.Collections.Generic;
using System.Text;

namespace _4.BetsBusinessEntities.Wrappers
{
    public class BetsResults_Wrapper
    {
        public long IdRoullete { get; set; }
        public long ResultRoulette { get; set; }
        public ICollection<Winners_Wrapper> Winners { get; set; }
    }
}
