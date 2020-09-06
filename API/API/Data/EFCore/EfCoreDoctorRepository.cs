using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.EFCore
{
    public class EfCoreDoctorRepository : EfCoreRepository<Doctor, HospitalContext>
    {
        public EfCoreDoctorRepository(HospitalContext context) : base(context) { }
    }
}
