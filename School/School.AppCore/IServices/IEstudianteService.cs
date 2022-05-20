using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.AppCore.IServices
{
    public interface IEstudianteService : IService<Estudiante>
    {
        Estudiante FindById(int id);
        List<Estudiante> FindByCarnet(string carnet);
    }
}
