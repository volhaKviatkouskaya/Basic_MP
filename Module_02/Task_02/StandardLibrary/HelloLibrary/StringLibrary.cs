namespace HelloLibrary
{
    public static class StringLibrary
    {
        public static string ConcatenateString(string userName)
        {
            var output = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                var currentTime = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
                output = $"{currentTime} Hello, {userName}!";
            }

            return output;
        }
    }
}