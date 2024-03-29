﻿using Easy.Hosts.Core.Domain.Model;

namespace Easy.Hosts.Core.Domain
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public virtual OrderService? OrderService { get; set; }
    }
}
