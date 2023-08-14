using Microsoft.AspNetCore.Mvc.Rendering;

namespace ObrasMusicaisApi.Models.ViewModels;

public class EditObrasRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Genero { get; set; }

    //mostrar todos os titulares no db
    public IEnumerable<SelectListItem> Titulares { get; set; }
    public string[] SelectedTitulares { get; set; } = Array.Empty<string>();
}
