﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumKantin.Core.DTOs
{
    public class RoomCustomersDTO
    {
        public string? Number { get; set; }
        public string? Floor { get; set; }
        public ICollection<CustomerDTO>? customerDTOs { get; set; }
    }
}