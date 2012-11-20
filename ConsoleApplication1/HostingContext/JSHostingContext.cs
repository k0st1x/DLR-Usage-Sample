using System;
using IronJS.Hosting;
using IronJS.Native;

namespace ConsoleApplication1.HostingContext {
    class JSHostingContext : IHostingContext {
        readonly CSharp.Context context = new CSharp.Context();

        public void SetObject(string name, object value) {
            context.SetGlobal(name, value);
        }

        public void SetFunction<T>(string name, Action<T> func) {
            context.SetGlobal(name, Utils.CreateFunction(context.Environment, 1, func));
        }

        public void Execute(string script) {
            context.Execute(script);
        }
    }
}
