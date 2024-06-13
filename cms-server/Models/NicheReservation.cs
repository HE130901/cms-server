using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class NicheReservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int NicheId { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? ConfirmationDate { get; set; }

    public string? Status { get; set; }

    public int? ConfirmedBy { get; set; }

    public virtual Staff? ConfirmedByNavigation { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Niche Niche { get; set; } = null!;
}
