using GestionCours.Data;
using GestionCours.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCours.Services;

public class EtudiantService : IEtudiantService
{
    private readonly ApplicationDbContext _context;

    public EtudiantService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer les cours suivis par l'étudiant
    public async Task<IEnumerable<Course>> GetCoursEtudiantAsync(int etudiantId)
    {
        return await _context.Courses
            .Where(c => c.Classes.Any(cl => cl.Etudiants.Any(e => e.Id == etudiantId)))
            .Include(c => c.Module)
            .Include(c => c.Professeur)
            .ToListAsync();
    }

    // Récupérer les absences de l'étudiant
    public async Task<IEnumerable<Absence>> GetAbsencesEtudiantAsync(int etudiantId)
    {
        return await _context.Absences
            .Where(a => a.EtudiantId == etudiantId)
            .Include(a => a.Cours)
            .ThenInclude(c => c.Module)
            .ToListAsync();
    }

    Task<IEnumerable<Course>> IEtudiantService.GetCoursEtudiantAsync(int etudiantId)
    {
        throw new NotImplementedException();
    }

}
