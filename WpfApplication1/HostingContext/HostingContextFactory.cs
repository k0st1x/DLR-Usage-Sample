using System.Collections.Generic;
using IronPython.Hosting;
using IronRuby;

namespace WpfApplication1.HostingContext {
    class HostingContextFactory {
        public static IEnumerable<IHostingContext> CreateHostingContexts() {
            return new IHostingContext[] {
                new DlrHostingContext(Python.CreateEngine(), "Samples.script.py"),
                new DlrHostingContext(Ruby.CreateEngine(), "Samples.script.rb"),
                new JSHostingContext("Samples.script.js")
            };
        }
    }
}
