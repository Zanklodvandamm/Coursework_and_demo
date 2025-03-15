using System;
using System.Collections.Generic;

namespace DemoWPF.Models;

public partial class Materialtype
{
    public int MaterialTypeId { get; set; }

    public string MaterialTypeName { get; set; } = null!;

    public decimal DefectPercentage { get; set; }
}
