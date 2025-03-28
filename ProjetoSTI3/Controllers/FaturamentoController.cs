using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoSTI3.Models.ValueObjects;
using ProjetoSTI3.Services;
using ProjetoSTI3.Services.Interface;
using System.Text;

namespace ProjetoSTI3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaturamentoController
    {
        private readonly IPedidoService _pedidoService;

        string apiUrl = "https://sti3-faturamento.azurewebsites.net/api/vendas";

        public FaturamentoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet(Name = "Pedidos para Faturar")]
        public IEnumerable<FaturamentoVO> GetFaturamento()
        {
            var listaPedidos = _pedidoService.GetPedidos();
            return listaPedidos;
        }

        [HttpPost(Name = "Faturamento")]
        public async Task<HttpResponseMessage> Get(FaturamentoVO faturamento)
        {
            HttpResponseMessage response = null;
            string json = JsonConvert.SerializeObject(faturamento);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                content.Headers.Add("email", "thiago.artuni@hotmail.com.br");

                response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Requisição enviada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Falha ao enviar a requisição. Código de status: " + response.StatusCode);
                }
            }

            _pedidoService.AlterarStatusPedido(faturamento.Identificador);
            return response;
        }
    }
}
