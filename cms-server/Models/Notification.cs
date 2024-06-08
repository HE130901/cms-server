using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int CustomerId { get; set; }

    public int? ContractId { get; set; }

    public int? ServiceOrderId { get; set; }

    public int? VisitId { get; set; }

    public DateOnly NotificationDate { get; set; }

    public string Message { get; set; } = null!;

    public virtual Contract? Contract { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ServiceOrder? ServiceOrder { get; set; }

    public virtual VisitRegistration? Visit { get; set; }
}
