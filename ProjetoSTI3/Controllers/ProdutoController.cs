using Microsoft.AspNetCore.Mvc;
using ProjetoSTI3.Models;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet(Name = "Produto")]
    public IEnumerable<Produto> Get()
    {
        IEnumerable<Produto> lista = _produtoService.GetProdutos();
        return lista.ToArray();
    }
}
