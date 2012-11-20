using System;
using System.Dynamic;
using System.IO;
using ConsoleApplication1.HostingContext;

namespace ConsoleApplication1 {
    public class Program {
        public static void Main() {
            const string ScriptSourceResourceName = "Scripts.script.rb";
            var extension = Path.GetExtension(ScriptSourceResourceName);
            var context = HostingContextFactory.Create(extension);
            InitializeContext(context);
            var source = GetResourceText(ScriptSourceResourceName);
            context.Execute(source);
        }

        public class WrapperObject {
            readonly Action<object> funcField;
            public WrapperObject (Action<object> funcArg) 	{
                funcField = funcArg;
	        }

            public void func(object obj) {
                funcField(obj);
            }
        }

        static void InitializeContext(IHostingContext context) {
            context.SetObject("value", "GetDev");
            context.SetObject("obj", new WrapperObject(Func));
            context.SetFunction<object>("func", Func);
        }

        static void Func(object value) {
            Console.WriteLine(value);
        }

        static string GetResourceText(string resourceName) {
            var type = typeof(Program);
            using(var stream = type.Assembly.GetManifestResourceStream(type, resourceName))
            using(var reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }
    }
}
