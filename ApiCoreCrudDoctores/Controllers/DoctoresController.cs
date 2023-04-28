using ApiCoreCrudDoctores.Models;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return await this.repo.GetDoctoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDoctorAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDoctor(Doctor doc)
        {
            await this.repo.InsertarDoctor(doc.IdHospital,doc.IdDoctor,
                doc.Apellido, doc.Especialidad, doc.Salario);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(Doctor doc)
        {
            await this.repo.UpdateDoctor(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Salario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await this.repo.DeleteDoctor(id);
            return Ok();
        }
    }
}
