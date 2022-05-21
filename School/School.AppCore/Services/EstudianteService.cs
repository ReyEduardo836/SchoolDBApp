using School.AppCore.IServices;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.AppCore.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IEstudianteRepository estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }
        public int Create(Estudiante t)
        {
            try
            {
                return estudianteRepository.Create(t);
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
                return estudianteRepository.Delete(t);
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
                return estudianteRepository.FindByCarnet(carnet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindById(int id)
        {
            if (id < 1) return null;
            try
            {
                return estudianteRepository.FindById(id);
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
                return estudianteRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Estudiante t)
        {
            try
            {
                return estudianteRepository.Update(t);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
