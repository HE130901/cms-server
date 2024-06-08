using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Deceased
{
    public int DeceasedId { get; set; }

    public string CitizenId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly DateOfDeath { get; set; }

    public int NicheId { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Niche Niche { get; set; } = null!;

    public virtual NicheReservation? NicheReservation { get; set; }
}
