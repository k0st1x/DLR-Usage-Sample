using System;
using System.Linq;
using Microsoft.Scripting.Hosting;
using WpfApplication1.Helpers;

namespace WpfApplication1.HostingContext {
    class DlrHostingContext : IHostingContext {
        readonly string name;
        readonly string sampleCode;
        readonly ScriptEngine scriptEngine;
        readonly ScriptScope scope;

        public DlrHostingContext(ScriptEngine scriptEngine, string sampleResourceName) {
            this.scriptEngine = scriptEngine;

            this.name = scriptEngine.Setup.Names[1];
            sampleCode = ResourceHelper.GetResource<DlrHostingContext>(sampleResourceName);

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

        public string Name {
            get { return name; }
        }
        
        public string SampleCode {
            get { return sampleCode; }
        }
    }
}
