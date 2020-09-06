using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.EFCore
{
    public class EfCorePatientRepository : EfCoreRepository<Patient, HospitalContext>
    {
        public EfCorePatientRepository(HospitalContext context) : base(context) { }

        /// <summary>
        /// Get patients assigned to specific doctor
        /// </summary>
        /// <param name="id">doctor id</param>
        /// <returns></returns>
        public async Task<List<Patient>> GetDoctorsPatientsAsync(long id)
            => await context.Set<Patient>().Where(x => x.DoctorID == id && !x.IsDeleted).ToListAsync().ConfigureAwait(false);
    }
}
