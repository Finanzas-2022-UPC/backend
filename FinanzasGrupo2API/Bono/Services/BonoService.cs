using AutoMapper;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Domain.Repositories;
using FinanzasGrupo2API.Bonos.Domain.Services;
using FinanzasGrupo2API.Bonos.Domain.Services.Communication;
using FinanzasGrupo2API.Bonos.Resources;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Bonos.Services
{
    public class BonoService : IBonoService
    {
        private readonly IBonoRepository _bonoRepository;
        private readonly IProyectoRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BonoService(IBonoRepository bonoRepository, IProyectoRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bonoRepository = bonoRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Bono>> ListAsync()
        {
            return await _bonoRepository.ListAsync();
        }

        public async Task<Bono> GetById(int id)
        {
            return await _bonoRepository.FindByIdAsync(id);
        }

        public async Task<BonoResponse> SaveAsync(SaveBonoResource bonoResource)
        {
            var bono = _mapper.Map<SaveBonoResource, Bono>(bonoResource);

            var existingProject = await _projectRepository.FindByIdAsync(bonoResource.proyectos_id);
            if (existingProject == null)
                return new BonoResponse("Project Not Found");
            bono.proyecto = existingProject;

            try
            {

                await _bonoRepository.AddAsync(bono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(bono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occured while saving the bono: {e.Message}");
            }
        }

        public async Task<BonoResponse> UpdateAsync(int id, Bono bono)
        {
            var existingBono = await _bonoRepository.FindByIdAsync(id);
            if (existingBono == null)
                return new BonoResponse("Bono Not Found");

            existingBono.valor_nominal = bono.valor_nominal;
            existingBono.valor_comercial = bono.valor_comercial;
            existingBono.tasa_cupon = bono.tasa_cupon;
            existingBono.frecuencia_pago = bono.frecuencia_pago;
            existingBono.metodo_pago = bono.metodo_pago;
            existingBono.periodos = bono.periodos;
            existingBono.tea = bono.tea;
            existingBono.prima = bono.prima;
            existingBono.estructuracion = bono.estructuracion;
            existingBono.colocacion = bono.colocacion;
            existingBono.flotacion = bono.flotacion;
            existingBono.cavali = bono.cavali;
            existingBono.gastos_adicionales = bono.gastos_adicionales;
            existingBono.inflacion = bono.inflacion;
            existingBono.impuesto_renta = bono.impuesto_renta;
            existingBono.moneda = bono.moneda;


            try
            {
                _bonoRepository.Update(existingBono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(existingBono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occurred while updating the bono: {e.Message}");
            }
        }

        public async Task<BonoResponse> DeleteAsync(int id)
        {
            var existingBono = await _bonoRepository.FindByIdAsync(id);

            if (existingBono == null)
                return new BonoResponse("Bono not found");
            try
            {
                _bonoRepository.Remove(existingBono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(existingBono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occurred while deleting bono:{e.Message}");
            }
        }
    }
}