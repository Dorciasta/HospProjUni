using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data.EFCore
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<API.Models.Doctor> Doctors { get; set; }
        public DbSet<API.Models.Patient> Patients { get; set; }
    }
}
