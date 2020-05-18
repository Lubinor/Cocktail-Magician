﻿using System;
using System.Collections.Generic;

namespace CocktailMagician.Services.DTOs
{
    public class CityDTO
    {
        public CityDTO()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BarDTO> Bars { get; set; } = new HashSet<BarDTO>();
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
