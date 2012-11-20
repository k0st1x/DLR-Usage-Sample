using IronRuby;
using Microsoft.Scripting.Hosting;

namespace ConsoleApplication1.HostingContext {
    class RubyHostingContext : DlrHostingContextBase {
        protected override dynamic CreateScriptEngine() {
            return Ruby.CreateEngine();
        }
    }
}
