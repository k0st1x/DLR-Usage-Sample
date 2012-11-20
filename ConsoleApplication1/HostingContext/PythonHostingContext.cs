using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace ConsoleApplication1.HostingContext {
    class PythonHostingContext : DlrHostingContextBase {
        protected override dynamic CreateScriptEngine() {
            return Python.CreateEngine();
        }
    }
}
