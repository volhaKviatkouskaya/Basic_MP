namespace CustomAttribute
{
    public interface IProvider
    {
        public string GetValue(string key);
        public void SetValue(string key, string value);
        public void SaveChanges(string key, string value);
    }
}
