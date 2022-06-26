using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasGrupo2API.Business.Domain.Models;
using FinanzasGrupo2API.Business.Domain.Repositories;
using FinanzasGrupo2API.Publications.Domain.Models;
using FinanzasGrupo2API.Publications.Domain.Repositories;
using FinanzasGrupo2API.Publications.Domain.Services;
using FinanzasGrupo2API.Publications.Domain.Services.Communication;
using FinanzasGrupo2API.Publications.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Publications.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByTypeAsync(int type)
        {
            var publications = await _publicationRepository.ListAsync();
            
            var filter = publications.Where(c => c.PublicationType == type).ToArray();
            
            return filter;
        }

        public async Task<Publication> GetById(int id)
        {
            return await _publicationRepository.FindByIdAsync(id);
        }

        public async Task<PublicationResponse> SaveAsync(SavePublicationResource publicationResource)
        {
            var publication = _mapper.Map<SavePublicationResource, Publication>(publicationResource);

            try
            {

                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                _publicationRepository.Update(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occured while saving the publication: {e.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication Not Found");
            existingPublication.Title = publication.Title;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while updating the publication: {e.Message}");
            }
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while deleting publication:{e.Message}");
            }
        }
    }
}