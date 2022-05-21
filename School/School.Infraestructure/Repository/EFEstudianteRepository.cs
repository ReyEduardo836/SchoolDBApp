using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infraestructure.Repository
{
    public class EFEstudianteRepository : IEstudianteRepository
    {
        ISchoolContext schoolContext;

        public EFEstudianteRepository(ISchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }
        public int Create(Estudiante t)
        {
            try
            {
                schoolContext.Estudiantes.Add(t);
                return schoolContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                schoolContext.Estudiantes.Remove(t);
                return schoolContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> FindByCarnet(string carnet)
        {
            try
            {
                return schoolContext.Estudiantes.Where(x => x.Carnet.Contains(carnet)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindById(int id)
        {
            if (id <= 0) throw new Exception("El id no puede ser igual o menor que 0");

            try
            {
                return schoolContext.Estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> GetAll()
        {
            try
            {
                return schoolContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Estudiante t)
        {
            Estudiante estudiante = FindByCarnet(t.Carnet).FirstOrDefault();
            if (estudiante == null)
            {
                throw new Exception("No existe ningun estudiante con ese ID");
            }

            //estudiante.Nombres = t.Nombres;
            //estudiante.Apellidos = t.Apellidos;
            estudiante.Phone = t.Phone;
            estudiante.Direccion = t.Direccion;
            estudiante.Correo = t.Correo;
            try
            {
                schoolContext.Estudiantes.Update(estudiante);
                return schoolContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
