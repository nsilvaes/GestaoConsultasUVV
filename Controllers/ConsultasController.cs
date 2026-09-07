using System.Security.Claims;
using GestaoConsultasUVV.Data;
using GestaoConsultasUVV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoConsultasUVV.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int usuarioId = ObterUsuarioId();

            var consultas = await _context.Consultas
                .Where(c => c.UsuarioId == usuarioId)
                .OrderBy(c => c.DataHora)
                .ToListAsync();

            return View(consultas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Consulta
            {
                DataHora = DateTime.Now.AddDays(1)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consulta consulta)
        {
            ModelState.Remove("Usuario");
            ModelState.Remove("UsuarioId");

            if (!ModelState.IsValid)
                return View(consulta);

            consulta.UsuarioId = ObterUsuarioId();

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Consulta cadastrada com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(c =>
                    c.Id == id &&
                    c.UsuarioId == usuarioId);

            if (consulta == null)
                return NotFound();

            return View(consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Consulta consulta)
        {
            if (id != consulta.Id)
                return NotFound();

            ModelState.Remove("Usuario");
            ModelState.Remove("UsuarioId");

            if (!ModelState.IsValid)
                return View(consulta);

            int usuarioId = ObterUsuarioId();

            var consultaBanco = await _context.Consultas
                .FirstOrDefaultAsync(c =>
                    c.Id == id &&
                    c.UsuarioId == usuarioId);

            if (consultaBanco == null)
                return NotFound();

            consultaBanco.Especialidade = consulta.Especialidade;
            consultaBanco.DataHora = consulta.DataHora;
            consultaBanco.Descricao = consulta.Descricao;

            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Consulta atualizada com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(c =>
                    c.Id == id &&
                    c.UsuarioId == usuarioId);

            if (consulta == null)
                return NotFound();

            return View(consulta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioId = ObterUsuarioId();

            var consulta = await _context.Consultas
                .FirstOrDefaultAsync(c =>
                    c.Id == id &&
                    c.UsuarioId == usuarioId);

            if (consulta == null)
                return NotFound();

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Consulta excluída com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        private int ObterUsuarioId()
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return int.Parse(id!);
        }
    }
}