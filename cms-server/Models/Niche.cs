namespace cms_server.Models
{
    public class Niche
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int SectionId { get; set; }
        public DateTime? BookedUntil { get; set; }
    }
}
