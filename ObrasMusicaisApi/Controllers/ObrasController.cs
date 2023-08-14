using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ObrasMusicaisApi.Repos;
using ObrasMusicaisApi.Models.ViewModels;
using ObrasMusicaisApi.Models;

namespace ObrasMusicaisApi.Controllers;

public class ObrasController : Controller
{
    private readonly IObrasRepo obrasRepo;
    private readonly ITitularesRepo titularesRepo;
    public ObrasController(IObrasRepo obrasRepo, ITitularesRepo titularesRepo)
    {
        this.obrasRepo = obrasRepo;
        this.titularesRepo = titularesRepo;
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var titulares = await titularesRepo.GetAllAsync();

        var result = new AddObrasRequest
        {
            Titulares = titulares.Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() })
        };

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> Add(AddObrasRequest addObrasRequest)
    {
        var obras = new ObraModel
        {
            Nome = addObrasRequest.Nome,
            Genero = addObrasRequest.Genero,
        };
        var selectedTitulares = new List<TitularModel>();
        foreach(var selectedTitularesID in addObrasRequest.SelectedTitulares)
        {
            var selectedTitularesIdAsGuid = Guid.Parse(selectedTitularesID);
            var existingTitular = await titularesRepo.GetAsync(selectedTitularesIdAsGuid);

            if (existingTitular != null)
            {
                selectedTitulares.Add(existingTitular);
            }
        }
        obras.Titulares = selectedTitulares;
        await obrasRepo.AddAsync(obras);
        return Ok(obras);
    }
    [HttpGet]
    [ActionName("List")]
    public async Task<IActionResult> List()
    {
        var obras = await obrasRepo.GetAllAsync();
        return Ok(obras);
    }
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var obras = await obrasRepo.GetAsync(id);
        var titular = await titularesRepo.GetAllAsync();

        if (obras != null)
        {
            var result = new EditObrasRequest
            {
                Id = obras.Id,
                Nome = obras.Nome,
                Genero = obras.Genero,
                Titulares = titular.Select(x => new SelectListItem
                {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                }),
                SelectedTitulares = obras.Titulares.Select(x => x.Id.ToString()).ToArray(),
            };
             return Ok(result);
        }
        return Ok(null);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditObrasRequest editObrasRequest)
    {
        var edit = new ObraModel
        {
            Id = editObrasRequest.Id,
            Nome = editObrasRequest.Nome,
            Genero = editObrasRequest.Genero,
        };
        var selectedTitulares = new List<TitularModel>();

        foreach(var selectedTitularesId in editObrasRequest.SelectedTitulares)
        {
            if(Guid.TryParse(selectedTitularesId, out var titulares))
            {
                var foundTitulares = await titularesRepo.GetAsync(titulares);

                if(foundTitulares != null)
                {
                    selectedTitulares.Add(foundTitulares);
                }
            }
        }
        edit.Titulares = selectedTitulares;

        var updateTitulares = await obrasRepo.UpdateAsync(edit);
        if(updateTitulares != null)
        {
            return RedirectToAction("List");
        }
        return RedirectToAction("Edit");
    }
    [HttpPost]
    [ActionName("Delet")]
    public async Task<IActionResult> Delet(EditObrasRequest editObrasRequest)
    {
        var deletObras = await obrasRepo.DeleteAsync(editObrasRequest.Id);
        if(deletObras != null)
        {
            return RedirectToAction("List");
        }
        return RedirectToAction("Edit", new { id = editObrasRequest.Id });
    }
}
