using System;

namespace WpfApplication1.HostingContext {
    public interface IHostingContext {
        string Name { get; }
        string SampleCode { get; }

        void SetObject(string name, object value);
        void SetFunction<T1, T2, T3>(string name, Action<T1, T2, T3> func);
        void SetFunction<T1, T2, T3, T4>(string name, Action<T1, T2, T3, T4> func);
        void Execute(string script);

        event EventHandler BeforeExecute;
    }
}
