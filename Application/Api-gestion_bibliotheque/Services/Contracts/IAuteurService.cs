using Api_gestion_bibliotheque.Entities;

namespace Api_gestion_bibliotheque.Services.Contracts
{
    public interface IAuteurService
    {
        /// <summary>
        /// Obtenir l'auteur par son identifiant
        /// </summary>
        /// <param name="Id">identifiant</param>
        /// <returns></returns>
        Task<Auteur> GetAuteurByIdAsync(string Id);

        /// <summary>
        /// Création d'un auteur
        /// </summary>
        /// <param name="auteurToCreate"></param>
        /// <returns></returns>
        Task<Auteur> CreateAuteur(Auteur auteurToCreate);
    }
}
