using GestionCours.Models;

namespace GestionCours.Services;

public interface IEtudiantService
{
    Task<IEnumerable<Course>> GetCoursEtudiantAsync(int etudiantId);
    Task<IEnumerable<Absence>> GetAbsencesEtudiantAsync(int etudiantId);
}
