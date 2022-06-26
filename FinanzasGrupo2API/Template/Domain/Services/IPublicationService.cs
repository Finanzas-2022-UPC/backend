using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasGrupo2API.Publications.Domain.Models;
using FinanzasGrupo2API.Publications.Domain.Services.Communication;
using FinanzasGrupo2API.Publications.Resources;

namespace FinanzasGrupo2API.Publications.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        
        Task<IEnumerable<Publication>> ListByTypeAsync(int type);
        
        Task<Publication> GetById(int id);

        Task<PublicationResponse> SaveAsync(SavePublicationResource publication);

        Task<PublicationResponse> UpdateAsync(int id, Publication publication);

        Task<PublicationResponse> DeleteAsync(int id);
    }
}