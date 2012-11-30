using System;
using IronJS.Hosting;
using IronJS.Native;
using WpfApplication1.Helpers;

namespace WpfApplication1.HostingContext {
    class JSHostingContext : IHostingContext {
        readonly CSharp.Context context = new CSharp.Context();
        readonly string sampleCode;

        public event EventHandler BeforeExecute;

        public JSHostingContext(string sampleResourceName) {
            sampleCode = ResourceHelper.GetResource<JSHostingContext>(sampleResourceName);
        }

        public void SetObject(string name, object value) {
            context.SetGlobal(name, value);
        }

        public void SetFunction<T1, T2, T3>(string name, Action<T1, T2, T3> func) {
            context.SetGlobal(name, Utils.CreateFunction(context.Environment, 1, func));
        }

        public void SetFunction<T1, T2, T3, t4>(string name, Action<T1, T2, T3, t4> func) {
            context.SetGlobal(name, Utils.CreateFunction(context.Environment, 1, func));
        }

        public void Execute(string script) {
            if(BeforeExecute != null) {
                BeforeExecute(this, EventArgs.Empty);
            }
            context.Execute(script);
        }

        public string Name {
            get { return "JS"; }
        }

        public string SampleCode {
            get { return sampleCode; }
        }
    }
}
