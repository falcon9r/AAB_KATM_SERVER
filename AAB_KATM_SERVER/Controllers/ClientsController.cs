using AAB_KATM_SERVER.DTOs.Clients;
using AAB_KATM_SERVER.Entities;
using AAB_KATM_SERVER.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AAB_KATM_SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            this.mapper = mapper;   
        }

        [HttpGet, Route("{clientId}")]
        public async Task<IActionResult> Get([FromRoute]int clientId)
        {
            Client client = await _clientRepository.GetById(clientId);
            if(client is null)
            {
                return BadRequest("Client does not exist");
            }
            return Ok(client);
        }
        
        [HttpPatch, Route("{clientId}")]
        public async Task<IActionResult> Update([FromRoute] int clientId, ClientUpdateDTO clientUpdateDTO)
        {
            bool result = await _clientRepository.Update(clientId, mapper.Map<Client>(clientUpdateDTO));
            if (result is false)
            {
                return BadRequest("Client does not exist");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDTO)
        {
            await _clientRepository.Create(mapper.Map<Client>(clientDTO));
            return Ok();
        }
    }
}
