using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthenticationContext _context;
        public AdminController(AuthenticationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            

            return View(_context.Users.ToList());
        }

        public IActionResult Roles()
        {
            return View(_context.Roles.ToList());
        }

        public IActionResult CreateRole()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Roles));
            }
            return View(role);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(string id, IdentityRole role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Roles));
            }
            return View(role);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Roles));
        }
    }
}