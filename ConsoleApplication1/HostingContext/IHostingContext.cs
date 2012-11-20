using System;

namespace ConsoleApplication1.HostingContext {
    interface IHostingContext {
        void SetObject(string name, object value);
        void SetFunction<T>(string name, Action<T> func);
        void Execute(string script);
    }
}
