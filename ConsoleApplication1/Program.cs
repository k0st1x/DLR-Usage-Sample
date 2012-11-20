using System.IO;
using ConsoleApplication1.HostingContext;

namespace ConsoleApplication1 {
    public class Program {
        public static void Main() {
            const string ScriptSourceResourceName = "Scripts.script.js";
            var extension = Path.GetExtension(ScriptSourceResourceName);
            var context = HostingContextFactory.Create(extension);
            InitializeContext(context);
            var source = GetResourceText(ScriptSourceResourceName);
            context.Execute(source);
        }

        static void InitializeContext(IHostingContext context) {
            context["value"] = "GetDev.NET";
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
