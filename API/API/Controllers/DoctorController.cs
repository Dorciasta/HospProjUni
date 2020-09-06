using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Data.EFCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorController : HospitalController<Doctor, EfCoreDoctorRepository>
    {
        public DoctorController(EfCoreDoctorRepository repository) : base(repository) { }
    }
}
