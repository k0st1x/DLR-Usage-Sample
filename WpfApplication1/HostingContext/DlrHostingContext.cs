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

        public event EventHandler BeforeExecute;

        public DlrHostingContext(ScriptEngine scriptEngine, string sampleResourceName) {
            this.scriptEngine = scriptEngine;

            this.name = scriptEngine.Setup.Names[1];
            sampleCode = ResourceHelper.GetResource<DlrHostingContext>(sampleResourceName);

            scope = scriptEngine.CreateScope();
        }

        public void Execute(string script) {
            if(BeforeExecute != null) {
                BeforeExecute(this, EventArgs.Empty);
            }

            //scriptEngine.Execute(script, scope);
            var scriptSource = scriptEngine.CreateScriptSourceFromString(script);
            var compiledCode = scriptSource.Compile();
            compiledCode.Execute(scope);
        }

        public void SetObject(string name, object value) {
            scope.SetVariable(name, value);
        }

        public void SetFunction<T1, T2, T3>(string name, Action<T1, T2, T3> func) {
            SetObject(name, func);
        }

        public void SetFunction<T1, T2, T3, t4>(string name, Action<T1, T2, T3, t4> func) {
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
