using API.Data.EFCore;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : HospitalController<Patient, EfCorePatientRepository>
    {
        private readonly EfCorePatientRepository patientRepository;

        public PatientController(EfCorePatientRepository patientRepository) : base(patientRepository) => this.patientRepository = patientRepository;

        /// <summary>
        /// Get patients assigned to specific doctor
        /// </summary>
        /// <param name="id">doctor id</param>
        /// <returns></returns>
        [HttpGet("DoctorsPatients/{id}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetDoctorsPatientsAsync(long id)
            => await patientRepository.GetDoctorsPatientsAsync(id).ConfigureAwait(false);
    }
}
