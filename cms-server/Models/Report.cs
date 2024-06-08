using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportType { get; set; } = null!;

    public DateOnly GeneratedDate { get; set; }

    public string? Content { get; set; }
}
