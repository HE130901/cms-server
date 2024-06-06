namespace cms_server.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorId { get; set; }
        public List<Niche> Niches { get; set; }
    }
}
