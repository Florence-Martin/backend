using Api_gestion_bibliotheque.Entities;

namespace Api_gestion_bibliotheque.Services.Contracts
{
    public interface ILivreService
    {
        /// <summary>
        /// Obtenir le livre par son identifiant
        /// </summary>
        /// <param name="Id">identifiant</param>
        /// <returns></returns>
        Task<Livre> GetLivreByIdAsync(string Id);

        /// <summary>
        /// CRéation d'un livre
        /// </summary>
        /// <param name="livreToCreate"></param>
        /// <returns></returns>
        Task<Livre> CreateLivre(Livre livreToCreate);
    }
}
