using System.ComponentModel.DataAnnotations;
using GestionCours.Validator;
using Microsoft.VisualBasic;

namespace GestionCours.Models;

public class Absence
{
    public int Id { get; set; }
    public DateFormat date { get; set; }
    public string? heuredebut { get; set; }
    public string? heurefin { get; set; }

    // Relation
    public Etudiant? Etudiant { get; set; }
    public int? EtudiantId { get; set; }



}
