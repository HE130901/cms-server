namespace cms_server.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CCCD { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public int SectionId { get; set; }
        public int NicheId { get; set; }
        public DateTime BookedAt { get; set; }
    }
}
