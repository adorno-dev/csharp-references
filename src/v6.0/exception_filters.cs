using System;

namespace CSharp.Features
{
    class ExceptionFilters
    {
        public ExceptionFilters()
        {
			try { }
			catch (Exception e) when (e.HResult.Equals(10)) { } // <--
			finally { }
        }
    }
}