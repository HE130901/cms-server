namespace cms_server.DTOs
{
    public class CreateReservationDto
    {
        public string CustomerName { get; set; } = null!;
        public string RecipientFullname { get; set; } = null!;
        public string RecipientCitizenId { get; set; } = null!;
        public DateOnly RecipientDOB { get; set; }
        public string BuyerCitizenId { get; set; } = null!;
        public int RentalPeriod { get; set; }
        public DateOnly ContractDate { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public int AreaId { get; set; }
        public int NicheId { get; set; }
        public string Status { get; set; } = null!;
        public DateOnly ReservationDate { get; set; }
    }
}
