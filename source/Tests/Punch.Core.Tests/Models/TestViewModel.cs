using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Punch.Core.Tests
{
    public class TestViewModel
    {
        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public bool Bool { get; set; }

        public List<string> List { get; set; }

        public TestViewModel SubModel { get; set; }

        public Action Click { get; set; }

        [JsonIgnore]
        public Expression<Func<string>> Concatenation
        {
            get
            {
                return () => "#" + A + B + C;
            }
        }
    }
}
