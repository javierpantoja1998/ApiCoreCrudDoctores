using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private DoctoresContext context;

        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        //FUNCION PARA SACAR TODOS LOS DOCTORES
        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();

        }

        //FUNCION PARA LOS DETALLES
        public async Task<Doctor> FindDoctorAsync(int id)
        {
            return await this.context.Doctores
            .FirstOrDefaultAsync(x => x.IdDoctor == id);
        }

        //Funcion para insertar
        public async Task InsertarDoctor
            (int idHospital, int idDoctor,
            string apellido, string especialidad, int salario)
        {
            Doctor doc = new Doctor();
            doc.IdHospital = idHospital;
            doc.IdDoctor = idDoctor;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;
            this.context.Doctores.Add(doc);
            await this.context.SaveChangesAsync();
        }

        //Funcion para Modificar
        public async Task UpdateDoctor(int idDoctor,
            string apellido, string especialidad, int salario)
        {
            Doctor doc = await this.FindDoctorAsync(idDoctor);
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor doc = await this.FindDoctorAsync(id);
            this.context.Doctores.Remove(doc);
            await this.context.SaveChangesAsync();
        }
    }
}
