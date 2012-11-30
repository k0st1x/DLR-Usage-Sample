using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PyHosting {
    class Program {
        static void Main(string[] args) {
            var runtimeSetup = Python.CreateRuntimeSetup(new Dictionary<string, object>());
            runtimeSetup.DebugMode = true;
            
            var runtime = new ScriptRuntime(runtimeSetup);

            var scope = runtime.CreateScope(new Dictionary<string, object> {
                { "name" , "Batman" }
            });

            var engine = runtime.GetEngine("py");
            var scriptSource = engine.CreateScriptSourceFromFile("script.py");
            var compiledCode = scriptSource.Compile();
            
            compiledCode.Execute(scope);
        }
    }
}
