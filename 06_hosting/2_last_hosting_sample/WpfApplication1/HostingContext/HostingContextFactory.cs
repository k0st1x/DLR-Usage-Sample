using System.Collections.Generic;
using IronPython.Hosting;
using IronRuby;

namespace WpfApplication1.HostingContext {
    class HostingContextFactory {
        public static IEnumerable<IHostingContext> CreateHostingContexts(HostingContextConfigurer configurer) {
            var python = new DlrHostingContext(Python.CreateEngine(), "Samples.script.py");
            configurer.Configure(python);
            var ruby = new DlrHostingContext(Ruby.CreateEngine(), "Samples.script.rb");
            configurer.Configure(ruby);
            var js = new JSHostingContext("Samples.script.js");
            configurer.Configure(js);

            return new IHostingContext[] { python, ruby, js };
        }
    }
}
