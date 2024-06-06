namespace cms_server.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public List<Section> Sections { get; set; }
    }
}
