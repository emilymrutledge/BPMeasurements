using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BPMeasurementsERutledge7809.Data;
using BPMeasurementsERutledge7809.Models;
using System.Diagnostics.Metrics;

namespace BPMeasurementsERutledge7809.Controllers
{
    public class BPMeasurementsController : Controller
    {
        private readonly BPContext _context;

        public BPMeasurementsController(BPContext context)
        {
            _context = context;
        }

        // GET: BPMeasurements
        public async Task<IActionResult> Index()
        {
            var measurements = _context.BPMeasurements.Include(m => m.Position);
            return View(await measurements.ToListAsync());
        }

        // GET: BPMeasurements/Add
        public IActionResult Add()
        {
            ViewBag.PositionID = new SelectList(_context.Positions, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,Systolic,Diastolic,MeasurementDate,PositionID")] BPMeasurement bPMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bPMeasurement);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Measurement added successfully.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.PositionID = new SelectList(_context.Positions, "ID", "Name", bPMeasurement.PositionID);
            return View(bPMeasurement);
        }

        // GET: BPMeasurements/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                if (id == null || _context.BPMeasurements == null)
                    return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurements.FindAsync(id);
            if (bPMeasurement == null)
                return NotFound();
            
            ViewBag.PositionID = new SelectList(_context.Positions, "ID", "Name", bPMeasurement.PositionID);
            return View(bPMeasurement);
        }

        // POST: BPMeasurements/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Systolic,Diastolic,MeasurementDate,PositionID")] BPMeasurement bPMeasurement)
        {
            if (id != bPMeasurement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bPMeasurement);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Measurement updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BPMeasurementExists(bPMeasurement.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewBag.PositionID = new SelectList(_context.Positions, "ID", "Name", bPMeasurement.PositionID);
            return View(bPMeasurement);
        }

        // GET: BPMeasurements/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }

            return View(bPMeasurement);
        }

        // POST: BPMeasurements/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var bPMeasurement = await _context.BPMeasurements.FindAsync(id);
            if (bPMeasurement != null)
            {
                _context.BPMeasurements.Remove(bPMeasurement);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Measurement deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BPMeasurementExists(int id)
        {
            return _context.BPMeasurements.Any(e => e.ID == id);
        }
    }
}
