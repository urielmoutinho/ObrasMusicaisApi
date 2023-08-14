using Microsoft.AspNetCore.Mvc;
using ObrasMusicaisApi.Models;
using ObrasMusicaisApi.Models.ViewModels;
using ObrasMusicaisApi.Repos;

namespace ObrasMusicaisApi.Controllers;

public class TitularesController : Controller
{
    private readonly ITitularesRepo titularesRepo;

    public TitularesController(ITitularesRepo titularesRepo)
    {
        this.titularesRepo = titularesRepo;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return Ok();
    }

    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> Add(AddTitularesRequest addTitularesRequest)
    {
        ValidateTitularesRequest(addTitularesRequest);
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }

        var titular = new TitularModel
        {
            Nome = addTitularesRequest.Name,
            Nacionalidade = addTitularesRequest.Nacionalidade,
            Categoria = addTitularesRequest.Categoria,

        };
        await titularesRepo.AddAsync(titular);
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("List")]
    public async Task<IActionResult> List()
    {
        var titulares = await titularesRepo.GetAllAsync();
        return Ok(titulares);
    }
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var titulares = await titularesRepo.GetAsync(id);
        if (titulares != null)
        {
            var editTitularesRequest = new EditTitularesRequest
            {
                Id = titulares.Id,
                Nome = titulares.Nome,
                Nacionalidade = titulares.Nacionalidade,
                Categoria = titulares.Categoria
            };
            return Ok(editTitularesRequest);
        }
        return Ok(null);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditTitularesRequest editTitularesRequest)
    {
        var titulares = new EditTitularesRequest
        {
            Id = editTitularesRequest.Id,
            Nacionalidade = editTitularesRequest.Nacionalidade,
            Categoria = editTitularesRequest.Categoria,
            Nome = editTitularesRequest.Nome
        };
        var updatedTitulares = await titularesRepo.UpdateAsync(titulares);
        if (updatedTitulares != null)
        {
            //sucesso
        }
        else
        {
            //show erro
        }
        return RedirectToAction("List");
    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> Delete(EditTitularesRequest editTitularesRequest)
    {
        var deleteTitulares = await titularesRepo.DeleteAsync(editTitularesRequest.Id);

        if (deleteTitulares != null)
        {
            return RedirectToAction("List");

        }
        return RedirectToAction("Edit", new { id = editTitularesRequest.Id });
    }

    private void ValidateTitularesRequest(AddTitularesRequest addTitularesRequest)
    {
        if (addTitularesRequest.Categoria is null || addTitularesRequest.Nacionalidade is null || addTitularesRequest.Name is null)
        {
            ModelState.AddModelError("Preencha os campos!", "A gravação será liberada quando os todos os campos forem preenchidos!");
        }
    }
}

