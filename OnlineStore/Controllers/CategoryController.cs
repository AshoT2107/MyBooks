using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DTO;
using OnlineStore.Models;
using OnlineStore.Repository;
using System.Data;

namespace OnlineStore.Controllers;

public class CategoryController : Controller
{
    private readonly IRepositoryManager _repository;

    public CategoryController(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        var categories = _repository.Category!.GetAll(false).
            Select(category => new CategoryListingModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            });

        var model = new CategoryIndexModel
        {
            CategoryList = categories.ToList()
        };

        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }

    // POST: Category/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl")] Category category)
    {
        if (ModelState.IsValid)
        {
            await _repository.Category.NewCategory(category);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var category = await _repository.Category.GetById(id,true);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repository.Category.EditCategory(category);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await _repository.Category.GetById(category.Id, true)) is null)
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
        return View(category);
    }
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _repository.Category.GetById(id, true);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var category = await _repository.Category.GetById(id,true);
        await _repository.Category.DeleteCategory(category);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
