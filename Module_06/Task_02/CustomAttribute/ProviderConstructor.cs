namespace CustomProgram
{
    public static class ProviderConstructor
    {
        private const string instanceType = "Provider";
        public static Dictionary<string, object> ReturnProviders()
        {
            Dictionary<string, object> providers = new();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.Contains(instanceType))
                .ToList();

            foreach (var assembly in assemblies)
            {
                foreach (var assemblyExportedType in assembly.ExportedTypes)
                {
                    var provider = CreateProviderInstance(assemblyExportedType);
                    providers.Add(provider.GetType().Name, provider);
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
