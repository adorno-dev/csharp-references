using System;
using Newtonsoft.Json.Linq;

namespace CSharp.Features
{   
    public class IndexInitializers
    {
        public Pointer Point { get; set; }

		public JObject ToJson() => new JObject() { ["X"] = Point.X, ["Y"] = Point.Y };
    }
}