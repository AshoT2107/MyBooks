using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Repository;
using System.Data;

namespace OnlineStore.Controllers;

public class BookController : Controller
{
    private readonly IRepositoryManager _repository;

    public BookController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _repository.Book.GetAll(false).Include(b => b.Category).ToListAsync();
        return View(books);
    }
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
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false).ToList(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            await _repository.Book.NewBook(book);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = new SelectList(_repository.Category.GetAll(false).ToList(), "Id", "Name", book.CategoryId);
        return View(book);
    }
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var book = await _repository.Book.GetById(id,false);
        await _repository.Book.DeleteBook(book);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
