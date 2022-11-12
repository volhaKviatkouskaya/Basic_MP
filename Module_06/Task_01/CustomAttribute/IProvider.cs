namespace CustomAttribute
{
    public interface IProvider
    {
        public string GetValue(string key);
        public void SetValue(string key, string value, string provider);
        public void SaveChanges(CustomItem item);
    }
}
