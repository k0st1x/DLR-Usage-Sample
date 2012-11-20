using IronJS.Hosting;

namespace ConsoleApplication1.HostingContext {
    class JSHostingContext : IHostingContext {
        readonly CSharp.Context context = new CSharp.Context();

        public object this[string name] {
            get { return context.GetGlobal(name); }
            set { context.SetGlobal(name, value); }
        }

        public void Execute(string script) {
            context.Execute(script);
        }
    }
}
