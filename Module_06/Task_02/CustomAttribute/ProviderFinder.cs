using System.IO;
using System.Reflection;

namespace CustomAttribute
{
    public static class ProviderFinder
    {
        public static Dictionary<string, IProvider> ReturnProviders(string pathString)
        {
            Dictionary<string, IProvider> providers = new();
            var directoryFiles = ReturnDirectoryFiles(pathString);

            foreach (var file in directoryFiles)
            {
                var pluginAssembly = LoadPlugin(file);
                var provider = CreateProvider(pluginAssembly);

                providers.Add(provider.GetType().Name, provider);
            }

            return providers;
        }

        private static IProvider CreateProvider(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IProvider).IsAssignableFrom(type))
                {
                    var result = Activator.CreateInstance(type) as IProvider;
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        private static Assembly LoadPlugin(string pluginLocation)
        {
            ProviderLoadContext loadContext = new(pluginLocation);
            var plugin = loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));

            return plugin;
        }

        private static List<string> ReturnDirectoryFiles(string shortPath)
        {
            var root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(ProviderFinder).Assembly.Location)))))));

            var pluginLocation = Path.GetFullPath(Path.Combine(root, shortPath.Replace('\\', Path.DirectorySeparatorChar)));
            var directoryFiles = Directory.GetFiles(pluginLocation).ToList();

            return directoryFiles;
        }
    }
}
