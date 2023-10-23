using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prestige_Wheels.Data;
using Prestige_Wheels.Data.Entities;
using Prestige_Wheels.Models.Manufacturers;

namespace Prestige_Wheels.Controllers
{
    #region Data and Constructors

    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ManufacturersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions 

        public async Task<IActionResult> Index()
        {
           List<Manufacturer> manufacturers = await _context
                                                        .Manufacturers
                                                        .ToListAsync();
            var manuVM = _mapper.Map<List<ManufacturersViewModel>>(manufacturers);
            return View(manuVM);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var manufacturer = await _context
                                         .Manufacturers
                                         .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            var manuVM = _mapper.Map<ManufacturersViewModel>(manufacturer);
            return View(manuVM);
        }


        public IActionResult Create()
        {
            var manuVM = new ManufacturersViewModel(); 
            return View(manuVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ManufacturersViewModel manufacturersVM)
        {
            if (ModelState.IsValid)
            {
                var manufacturers = _mapper.Map<Manufacturer>(manufacturersVM);
                _context.Add(manufacturers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturersVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            var manuVM = _mapper.Map<ManufacturersViewModel>(manufacturer);
            return View(manuVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManufacturersViewModel manufacturerVM)
        {
            if (id != manufacturerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var manufacturers = _mapper.Map<Manufacturer>(manufacturerVM);
                    _context.Update(manufacturers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturerVM.Id)) 
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturerVM);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manufacturers == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manufacturers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Manufacturers'  is null.");
            }
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods
        private bool ManufacturerExists(int id)
        {
            return (_context.Manufacturers?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
