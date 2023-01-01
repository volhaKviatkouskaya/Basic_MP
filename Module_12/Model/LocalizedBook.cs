using System.Text;

namespace Model
{
    public class LocalizedBook : Book
    {
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");

            var authors = string.Empty;
            foreach (var item in Authors)
            {
                authors = string.Concat(authors, $"{item} ");
            }

            sb.AppendLine($"Authors: {authors}");
            sb.AppendLine($"Date Published: {DatePublished}");
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Number Of Pages: {NumberOfPages}");
            sb.AppendLine($"Publisher: {Publisher}");
            sb.AppendLine($"Country Of Localization: {CountryOfLocalization}");

            return sb.ToString();
        }
    }
}
