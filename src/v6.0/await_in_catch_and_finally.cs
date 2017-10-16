using System;
using System.Threading.Tasks;

namespace CSharp.Features
{
    class AwaitInCatchAndFinally
    {
        public async Task<bool> DoTask()
        {
			try { }
			catch (Exception e) when (e.HResult.Equals(10)) { await Task.Run<bool>(() => { return true; }); }
			finally { await Task.Run<bool>(() => { return false; }); }
            return false;
        }
    }
}