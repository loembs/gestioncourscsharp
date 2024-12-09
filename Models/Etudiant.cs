using System.ComponentModel.DataAnnotations;
using GestionCours.Validator;

namespace GestionCours.Models;

public class Etudiant
{
    public int Id { get; set; }
    public string Matricule { get; set; }
    public string Nomcomplet { get; set; }
    public string? Adresse { get; set; }

    // Relation
    public virtual ICollection<Absence>? Absences { get; set; }
    public virtual ICollection<Course>? Courses { get; set; }


}
