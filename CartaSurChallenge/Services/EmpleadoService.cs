using CartaSurChallenge.Entities;
using CartaSurChallenge.Models;
using CartaSurChallenge.Repository;
using Microsoft.EntityFrameworkCore;

namespace CartaSurChallenge.Services
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadosModel>> GetEmpleados();
        Task GuardarEmpleado(EmpleadosModel empleadosModel);
    }
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IAsyncRepository<Empleado> _empleadoRepository;
        public EmpleadoService(IAsyncRepository<Empleado> empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<List<EmpleadosModel>> GetEmpleados()
        {
            var empleados = await _empleadoRepository.GetSet().ToListAsync();
            return empleados.Select(e => new EmpleadosModel
            {
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Activo = e.Activo
            }).ToList();
        }

        public async Task GuardarEmpleado(EmpleadosModel empleadosModel)
        {
            await _empleadoRepository.AddAsync(
                new Empleado
                {
                    Activo = true,
                    Nombre = empleadosModel.Nombre,
                    Apellido = empleadosModel.Apellido,
                    SucursalId = 1
                }
            );
        }
    }
}
