using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Demo.PropertySearch.Utils
{
    public static class AssemblyHelper
    {
        private static readonly IDictionary<Assembly, IEnumerable<string>> EmbeddedFiles = new ConcurrentDictionary<Assembly, IEnumerable<string>>();

        public static string GetEmbeddedFile(this Assembly assembly, string filename)
        {
            using (var stream = assembly.GetManifestResourceStream(filename))
            {
                if (stream == null)
                {
                    throw new Exception($"Unable to find embedded resource {filename}");
                }

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return json;
                }
            }
        }

        public static bool EmbeddedFileExists(this Assembly assembly, string filename)
        {
            if (!EmbeddedFiles.ContainsKey(assembly))
            {
                EmbeddedFiles.Add(assembly, assembly.GetManifestResourceNames());
            }

            var @return = EmbeddedFiles[assembly]?.Any(name => name.EqualsCaseInsensitive(filename)) ?? false;

            return @return;
        }
    }
}
