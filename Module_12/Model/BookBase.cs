using System.Collections.Generic;

namespace Model
{
    public abstract class BookBase : Document
    {
        public long ISBN { get; set; }
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
    }
}
