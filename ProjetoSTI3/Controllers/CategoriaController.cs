using Microsoft.AspNetCore.Mvc;
using ProjetoSTI3.Models;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<CategoriaController> _logger;
    private readonly ICategoriaService _categoriaService;
    public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
    {
        _logger = logger;
        _categoriaService = categoriaService;
    }

    [HttpGet(Name = "Categoria")]
    public IEnumerable<Categoria> Get()
    {
        IEnumerable<Categoria> lista = _categoriaService.GetCategorias();

        return lista.ToArray(); 
    }
}
