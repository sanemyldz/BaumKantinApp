using BaumKantin.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaumKantin.Core
{
    public enum UserType:Byte
    {
        Admin,
        Intern,
        Worker
    }
    public class Customer: BaseEntity
    {
        public int? IdentityId { get; set; }
        
        [Required]
        public UserType UserTypeEnum { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual Room? Room  { get; set; }
        
        public int? RoomId  { get; set; }

        public virtual ImageModel? ImageModel  { get; set; }

        public int? ImageId { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
