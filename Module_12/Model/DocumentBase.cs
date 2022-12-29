using System;

namespace Model
{
    public class DocumentBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
