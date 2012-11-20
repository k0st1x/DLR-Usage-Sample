namespace ConsoleApplication1.HostingContext {
    interface IHostingContext {
        object this[string name] { get; set; }
        void Execute(string script);
    }
}
