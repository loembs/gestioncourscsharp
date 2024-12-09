using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GestionDette.Models;
using GestionCours.Services;
using GestionCours.Models;

namespace GestionCours.Controllers;
using Microsoft.AspNetCore.Mvc;


public class EtudiantController : Controller
{
    private readonly IEtudiantService _etudiantService;

    public EtudiantController(IEtudiantService etudiantService)
    {
        _etudiantService = etudiantService;
    }

    public async Task<IActionResult> MesCours(int etudiantId)
    {
        var cours = await _etudiantService.GetCoursEtudiantAsync(etudiantId);
        return View(cours);
    }

    public async Task<IActionResult> MesAbsences(int etudiantId)
    {
        var absences = await _etudiantService.GetAbsencesEtudiantAsync(etudiantId);
        return View(absences);
    }
}


