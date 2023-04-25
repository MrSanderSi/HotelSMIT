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
	public class HotelRoomsController : Controller
	{
		private readonly DataContext _context;

		public HotelRoomsController(DataContext context)
		{
			_context = context;
		}

		// GET: HotelRooms
		public async Task<IActionResult> Index()
		{
			return _context.HotelRoom != null ?
						View(await _context.HotelRoom.ToListAsync()) :
						Problem("Entity set 'DataContext.HotelRoom'  is null.");
		}

		// GET: HotelRooms/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.HotelRoom == null)
			{
				return NotFound();
			}

			var hotelRoom = await _context.HotelRoom
				.FirstOrDefaultAsync(m => m.Id == id);
			if (hotelRoom == null)
			{
				return NotFound();
			}

			return View(hotelRoom);
		}

		// GET: HotelRooms/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: HotelRooms/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,RoomNumber,BedCount,Price,Enabled")] HotelRoom hotelRoom)
		{
			if (ModelState.IsValid)
			{
				_context.Add(hotelRoom);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(hotelRoom);
		}

		// GET: HotelRooms/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.HotelRoom == null)
			{
				return NotFound();
			}

			var hotelRoom = await _context.HotelRoom.FindAsync(id);
			if (hotelRoom == null)
			{
				return NotFound();
			}
			return View(hotelRoom);
		}

		// POST: HotelRooms/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,RoomNumber,BedCount,Price,Enabled")] HotelRoom hotelRoom)
		{
			if (id != hotelRoom.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(hotelRoom);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!HotelRoomExists(hotelRoom.Id))
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
			return View(hotelRoom);
		}

		// GET: HotelRooms/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.HotelRoom == null)
			{
				return NotFound();
			}

			var hotelRoom = await _context.HotelRoom
				.FirstOrDefaultAsync(m => m.Id == id);
			if (hotelRoom == null)
			{
				return NotFound();
			}

			return View(hotelRoom);
		}

		// POST: HotelRooms/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.HotelRoom == null)
			{
				return Problem("Entity set 'DataContext.HotelRoom'  is null.");
			}
			var hotelRoom = await _context.HotelRoom.FindAsync(id);
			if (hotelRoom != null)
			{
				_context.HotelRoom.Remove(hotelRoom);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool HotelRoomExists(int id)
		{
			return (_context.HotelRoom?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
