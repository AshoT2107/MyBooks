using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Repository;
using System.Data;
using System.Security.Claims;

namespace OnlineStore.Controllers;

public class BookController : Controller
{
    private readonly IRepositoryManager _repository;

    public BookController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)); // get the ID of the current user
        var books = await _repository.Book.GetAll(false)
            .Where(b => b.UserAccountId == userId) // add a filter to only include books that belong to the current user
            .Include(b => b.Category)
            .ToListAsync();
        return View(books);
    }
    [Authorize]
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await  _repository.Book.GetAll(false).Include(b => b.Category).Where(x=>x.Id.Equals(id)).FirstOrDefaultAsync();

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }
    [Authorize]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false).ToList(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            book.UserAccountId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)); // set the ID of the current user as the book's owner
            await _repository.Book.NewBook(book);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false).ToList(), "Id", "Name", book.CategoryId);
        return View(book);
    }

    [Authorize]
    public async Task<IActionResult> Edit(Guid id)
    {
        var book = await _repository.Book.GetById(id,true);
        if (book == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false).ToList(), "Id", "Name", book.CategoryId);
        return View(book);
    }
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Book book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repository.Book.EditBook(book);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await _repository.Book.GetById(book.Id, true)) is null)
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
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false), "Id", "Name", book.CategoryId);
        return View(book);
    }
    [Authorize]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _repository.Book.GetAll(false).Include(b => b.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var book = await _repository.Book.GetById(id,false);
        await _repository.Book.DeleteBook(book);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
