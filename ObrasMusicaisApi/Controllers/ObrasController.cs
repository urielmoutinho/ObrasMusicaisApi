using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ObrasMusicaisApi.Repos;

namespace ObrasMusicaisApi.Controllers;

public class ObrasController : Controller
{
    private readonly IObrasRepo obrasRepo;
    public ObrasController(IObrasRepo obrasRepo)
    {
        this.obrasRepo = obrasRepo;

    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var obra = await obrasRepo.GetAsync();

        var model = new 
    }
}
