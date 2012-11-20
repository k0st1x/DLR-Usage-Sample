using System;
using Microsoft.Scripting.Hosting;

namespace ConsoleApplication1.HostingContext {
    class DlrHostingContext : IHostingContext {
        readonly ScriptEngine scriptEngine;
        readonly ScriptScope scope;

        public DlrHostingContext(ScriptEngine scriptEngine) {
            this.scriptEngine = scriptEngine;
            scope = scriptEngine.CreateScope();
        }

        public void Execute(string script) {
            scriptEngine.Execute(script, scope);
        }

        public void SetObject(string name, object value) {
            scope.SetVariable(name, value);
        }

        public void SetFunction<T>(string name, Action<T> func) {
            SetObject(name, func);
        }
    }
}
