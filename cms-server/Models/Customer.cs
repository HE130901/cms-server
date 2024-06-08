﻿using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string CitizenId { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Deceased> Deceaseds { get; set; } = new List<Deceased>();

    public virtual ICollection<NicheReservation> NicheReservations { get; set; } = new List<NicheReservation>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<VisitRegistration> VisitRegistrations { get; set; } = new List<VisitRegistration>();
}
