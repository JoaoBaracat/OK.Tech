﻿namespace OK.Tech.Domain.Entities
{
    public class Product : Entity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //public decimal Price { get; set; }
        //public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
