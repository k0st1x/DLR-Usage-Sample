using System;

namespace WpfApplication1.HostingContext {
    interface IHostingContext {
        string Name { get; }
        string SampleCode { get; }

        void SetObject(string name, object value);
        void SetFunction<T>(string name, Action<T> func);
        void Execute(string script);
    }
}
