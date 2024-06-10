using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Niche
{
    public int NicheId { get; set; }

    public int AreaId { get; set; }

    public string? NicheName { get; set; }

    public string Status { get; set; } = null!;

    public string? NicheDescription { get; set; }

    public int? Buyer { get; set; }

    public int? Receiver { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<NicheReservation> NicheReservations { get; set; } = new List<NicheReservation>();

    public virtual ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<VisitRegistration> VisitRegistrations { get; set; } = new List<VisitRegistration>();
}
