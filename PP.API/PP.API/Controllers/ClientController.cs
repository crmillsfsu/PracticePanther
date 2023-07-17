using Microsoft.AspNetCore.Mvc;
using PP.API.EC;
using PP.Library.DTO;
using PP.Library.Models;
using PP.Library.Utilities;

namespace PP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClientDTO> Get()
        {
            return new ClientEC().Search();
        }

        [HttpGet("/{id}")]
        public ClientDTO? GetId(int id)
        {
            return new ClientEC().Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public ClientDTO? Delete(int id)
        {
            return new ClientEC().Delete(id);
        }

        [HttpPost]
        public ClientDTO AddOrUpdate([FromBody]ClientDTO client)
        {
            return new ClientEC().AddOrUpdate(client);
        }

        [HttpPost]
        public IEnumerable<ClientDTO> Search([FromBody]QueryMessage query)
        {
            return new ClientEC().Search(query.Query);
        }
    }
}
