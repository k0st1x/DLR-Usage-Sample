using System.IO;

namespace WpfApplication1.Helpers {
    public class ResourceHelper {
        public static string GetResource<T>(string name) {
            var type  = typeof(T);
            using(var stream = type.Assembly.GetManifestResourceStream(type, name))
            using(var reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }
    }
}
