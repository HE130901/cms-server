namespace cms_server.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Floor> Floors { get; set; }
    }
}
