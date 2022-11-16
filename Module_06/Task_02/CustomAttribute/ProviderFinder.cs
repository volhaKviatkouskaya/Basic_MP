using System.Reflection;

namespace CustomAttribute
{
    public static class ProviderFinder
    {
        public static Dictionary<string, IProvider> ReturnProviders(string[] pathString)
        {
            Dictionary<string, IProvider> providers = new();

            foreach (var pluginPath in pathString)
            {
                var pluginAssembly = LoadPlugin(pluginPath);

                var provider = CreateProvider(pluginAssembly);
                if (provider != null)
                {
                    providers.Add(provider.GetType().Name, (IProvider)provider);
                }
            }

            return providers;
        }

        public static IProvider CreateProvider(Assembly assembly)
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

        public static Assembly LoadPlugin(string path)
        {
            string root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(ProviderFinder).Assembly.Location)))))));

            var pluginLocation = Path.GetFullPath(Path.Combine(root, path.Replace('\\', Path.DirectorySeparatorChar)));

            Console.WriteLine($"Loading providers from: {pluginLocation}");

            ProviderLoadContext loadContext = new(pluginLocation);

            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }
    }
}
