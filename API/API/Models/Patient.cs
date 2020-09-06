using API.Data;
using API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Patient : IEntity
    {
        public long Id { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [Pesel]
        public string Pesel { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public long DoctorID { get; set; }

        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
