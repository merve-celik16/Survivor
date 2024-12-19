﻿namespace Survivor.Data.Entities
{
    public class Category :BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Competitor> Competitors { get; set; }
    }
}
