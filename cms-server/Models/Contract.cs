using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int CustomerId { get; set; }

    public int NicheId { get; set; }

    public int RecipientId { get; set; }

    public int StaffId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Niche Niche { get; set; } = null!;

    public virtual Recipient Recipient { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
