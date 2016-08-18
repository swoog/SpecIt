using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecIt.Pattern
{
    public class ScenarioPattern : Scenario
    {
        public ScenarioPattern()
            : base(new Kernel())
        {
        }
    }
}
