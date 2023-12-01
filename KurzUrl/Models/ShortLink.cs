namespace KurzUrl.Models
{
    public class ShortLink
    {
        public required String Id {  get; set; }
        public required String OriginalUrl {  get; set; }
        public required String ShortUrl { get; set; }
        public required Int16 Clicks { get; set; }

    }
}
