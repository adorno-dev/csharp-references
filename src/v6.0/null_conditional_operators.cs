using System;
using Newtonsoft.Json.Linq;

namespace CSharp.Features
{
    class NullConditionalOperators
    {
        private delegate void OnChange(object sender, object args);
        private event OnChange on_change = null;

        public static Pointer FromJson(JObject json)
        {
            if (json != null && json["X"]?.Type == JTokenType.Integer && json["Y"]?.Type == JTokenType.Integer)
                return new Pointer((int)json["X"], (int)json["Y"]);
            return null;
        }

        public void CheckDelegate()
        {
            // if (this.on_change != null)
            //     this.on_change.Invoke(this, null);

            this.on_change?.Invoke(this, null);
        }
    }
}