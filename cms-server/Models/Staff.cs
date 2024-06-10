using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<NicheReservation> NicheReservations { get; set; } = new List<NicheReservation>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<VisitRegistration> VisitRegistrations { get; set; } = new List<VisitRegistration>();
}
