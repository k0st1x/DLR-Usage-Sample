using Microsoft.Scripting.Hosting;

namespace ConsoleApplication1.HostingContext {
    abstract class DlrHostingContextBase : IHostingContext {
        ScriptEngine scriptEngine;

        protected abstract dynamic CreateScriptEngine();

        ScriptEngine ScriptEngine {
            get {
                if(scriptEngine == null) {
                    scriptEngine = CreateScriptEngine();
                }
                return scriptEngine;
            }
        }

        ScriptScope Globals {
            get { return ScriptEngine.Runtime.Globals; }
        }

        public object this[string name] {
            get { return Globals.GetVariable(name); }
            set { Globals.SetVariable(name, value); }
        }

        public void Execute(string script) {
            ScriptEngine.Execute(script);
        }
    }
}
