using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prestige_Wheels.Data;
using Prestige_Wheels.Data.Entities;
using Prestige_Wheels.Models.Cars;

namespace Prestige_Wheels.Controllers
{
    public class CarsController : Controller

        #region Data and Constructors
   
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            #endregion
    }
        #region Actions
            public async Task<IActionResult> Index()
        {
            List<Car> cars = await _context
                              .Cars
                              .ToListAsync();

            var carsVM = _mapper.Map<List<Car>, List<CarViewModel>>(cars);

            return View(carsVM);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context
                               .Cars
                               .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
         var carVM = _mapper.Map<CarViewModel>(car);
            return View(carVM);
        }


        public IActionResult Create()
        {
            var carVM = new CarViewModel();
            return View(carVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<Car>(carVM);
                _context.Add(car);
                await _context
                          .SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         
            return View(carVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var carVM = _mapper.Map<CarViewModel>(car);
            return View(carVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel carVM)
        {
            if (id != carVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var car = _mapper.Map<Car>(carVM);
                    _context.Update(car);
                    await _context
                              .SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(carVM.Id))
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
            return View(carVM);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Private Methods
        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
