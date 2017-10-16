using System;

namespace CSharp.Features
{
    public class NameOfOperator
    {
        public Pointer Point { get; set; }

        public Pointer Add(Pointer other)
        {
            if (other == null)
                // throw new ArgumentNullException("pointer");
                throw new ArgumentException(nameof(other));
            
            return null;
        }
    }
}