using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSMIT.Data;
using HotelSMIT.Data.Models;

namespace HotelSMIT.Controllers
{
	public class BookedRoomsController : Controller
	{
		private readonly DataContext _context;

		public BookedRoomsController(DataContext context)
		{
			_context = context;
		}

		// GET: BookedRooms
		public async Task<IActionResult> Index()
		{
			  return _context.BookedRoom != null ? 
						  View(await _context.BookedRoom.ToListAsync()) :
						  Problem("Entity set 'DataContext.BookedRoom'  is null.");
		}

		// GET: BookedRooms/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.BookedRoom == null)
			{
				return NotFound();
			}

			var bookedRoom = await _context.BookedRoom
				.FirstOrDefaultAsync(m => m.Id == id);
			if (bookedRoom == null)
			{
				return NotFound();
			}

			return View(bookedRoom);
		}

		// GET: BookedRooms/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: BookedRooms/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate")] BookedRoom bookedRoom)
		{
			if (ModelState.IsValid)
			{
				_context.Add(bookedRoom);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(bookedRoom);
		}

		// GET: BookedRooms/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.BookedRoom == null)
			{
				return NotFound();
			}

			var bookedRoom = await _context.BookedRoom.FindAsync(id);
			if (bookedRoom == null)
			{
				return NotFound();
			}
			return View(bookedRoom);
		}

		// POST: BookedRooms/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate")] BookedRoom bookedRoom)
		{
			if (id != bookedRoom.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(bookedRoom);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BookedRoomExists(bookedRoom.Id))
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
			return View(bookedRoom);
		}

		// GET: BookedRooms/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.BookedRoom == null)
			{
				return NotFound();
			}

			var bookedRoom = await _context.BookedRoom
				.FirstOrDefaultAsync(m => m.Id == id);
			if (bookedRoom == null)
			{
				return NotFound();
			}

			return View(bookedRoom);
		}

		// POST: BookedRooms/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.BookedRoom == null)
			{
				return Problem("Entity set 'DataContext.BookedRoom'  is null.");
			}
			var bookedRoom = await _context.BookedRoom.FindAsync(id);
			if (bookedRoom != null)
			{
				_context.BookedRoom.Remove(bookedRoom);
			}
			
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool BookedRoomExists(int id)
		{
		  return (_context.BookedRoom?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
