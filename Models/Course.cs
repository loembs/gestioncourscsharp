using System.ComponentModel.DataAnnotations;
using GestionCours.Validator;

namespace GestionCours.Models;

public class Course
{
    public int Id { get; set; }
    public string Libelle { get; set; }
    public string? heuredebut { get; set; }
    public string? heurefin { get; set; }

    // Relation
    public Etudiant? Etudiant { get; set; }
    public int? EtudiantId { get; set; }


}
