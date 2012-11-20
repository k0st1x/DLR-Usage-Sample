using System;
using System.Collections.Generic;

namespace ConsoleApplication1.HostingContext {
    class HostingContextFactory {
        static readonly IDictionary<string, Func<IHostingContext>> HostingContextCtors = new Dictionary<string, Func<IHostingContext>> {
            { ".py", () => new PythonHostingContext() },
            { ".rb", () => new RubyHostingContext() },
            //{ ".js", () => new JSHostingContext() }
        };

        public static IHostingContext Create(string extension) {
            return HostingContextCtors[extension]();
        }
    }
}
