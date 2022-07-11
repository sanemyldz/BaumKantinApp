using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Transfering objects amoung layers = View models in Web projects. 
//??CustomerDTO içine naviation property alınmalı mı??
namespace BaumKantin.Core.DTOs
{
    public class CustomerDTO:BaseDTO
    {
        public int? IdentityId { get; set; }
        public UserType UserTypeEnum;
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
