using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUD.Models
{
    public class PropertiesUser
    {
        public int ID_User { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }
        [Range(0, 1, ErrorMessage = "Status must be between 0 or 1")]
        public string Status { get; set; }
    }
}