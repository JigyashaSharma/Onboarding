﻿using System;
using System.Collections.Generic;

namespace Onboarding.Server.Models;

public partial class Store
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
