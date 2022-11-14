namespace CustomAttribute
{
    public static class ProviderFinder
    {
        private const string InstanceType = "Provider";

        public static Dictionary<string, object> ReturnProviders()
        {
            Dictionary<string, object> providers = new();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.Contains(InstanceType))
                .ToList();

            foreach (var assembly in assemblies)
            {
                foreach (var assemblyExportedType in assembly.ExportedTypes)
                {
                    var provider = CreateProviderInstance(assemblyExportedType);
                    if (provider != null)
                    {
                        providers.Add(provider.GetType().Name, provider);
                    }
                }
            }

            return providers;
        }
        private static object CreateProviderInstance(Type providerType)
        {
            var instanceType = Type.GetType(providerType.AssemblyQualifiedName);

            return Activator.CreateInstance(instanceType);
        }
    }
}
