using System.Threading.Tasks;
using Crud.Domain;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using Crud.WebApi.Dto;

namespace Crud.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICrud _repo;

        private readonly IMapper _mapper;
        public UsuarioController(ICrud repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuario = await _repo.GetAllUsuario();
                var result = _mapper.Map<IEnumerable<UsuarioDto>>(usuario);
                return Ok(result);
            }
            catch(System.Exception)
            {
                return this.StatusCode(400, "Deu erro");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllId(int id)
        {
            try
            {
                var usuario = await _repo.GetUsuario(id);
                var result = _mapper.Map<UsuarioDto>(usuario);  
                return Ok(result);
            }
            catch(System.Exception)
            {
                return this.StatusCode(400, "Deu erro");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto model)
        {
            try
            {  
                var usuario = _mapper.Map<Usuario>(model);
               _repo.Add(usuario);
               if(await _repo.Save())
               {
                   return Ok();
               } 
            }
            catch(System.Exception)
            {
                return this.StatusCode(400, "Deu erro");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , UsuarioDto model)
        {
            try
            {
                var resultado = await _repo.GetUsuario(id); 
                _mapper.Map(model ,resultado);
                _repo.Update(resultado);

                if(await _repo.Save())
                {
                    return Ok();
                }

            }
            catch(System.Exception)
            {
                return this.StatusCode(400, "Deu erro");
            }

            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var usuario = await _repo.GetUsuario(id); 
                _repo.Delete(usuario);
                if(await _repo.Save())
                {
                    return Ok();
                }
            }
            catch(System.Exception){
                return this.StatusCode(400, "Deu erro");
            }
            return BadRequest();
        }
    }
}