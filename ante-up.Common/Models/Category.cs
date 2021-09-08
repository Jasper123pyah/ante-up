using System;
using System.Collections.Generic;

namespace ante_up.Common.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Tag { get; set; }
        public List<Game> Games { get; set; }
    }
}