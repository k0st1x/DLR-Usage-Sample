using System;
using System.Collections.Generic;
using IronPython.Hosting;
using IronRuby;

namespace ConsoleApplication1.HostingContext {
    class HostingContextFactory {
        static readonly IDictionary<string, Func<IHostingContext>> HostingContextCtors = new Dictionary<string, Func<IHostingContext>> {
            { ".py", () => new DlrHostingContext(Python.CreateEngine()) },
            { ".rb", () => new DlrHostingContext(Ruby.CreateEngine()) },
            { ".js", () => new JSHostingContext() }
        };

        public static IHostingContext Create(string extension) {
            return HostingContextCtors[extension]();
        }
    }
}
