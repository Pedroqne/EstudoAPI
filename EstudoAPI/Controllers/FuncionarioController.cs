using EstudoAPI.Models;
using EstudoAPI.Service.FuncionarioService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }




        [Authorize]
        [HttpGet]       
        public async Task<ActionResult<ServiceResponse<Funcionario>>> GetFuncionario() 
        {
            return Ok( await _funcionarioService.GetFuncionario());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> GetByUd(int id)
        {
            return Ok(await _funcionarioService.GetFuncionarioById(id));
        }

        [HttpPost] 
        public async Task<ActionResult<ServiceResponse<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario)
        {
            return Ok(await _funcionarioService.CreateFuncionario(novoFuncionario));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> DeleteFuncionario(int id)
        {
            return Ok(await _funcionarioService.DeleteFuncionario(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> UpdateFuncionario(Funcionario editarFuncionario)
        {
            return Ok(await _funcionarioService.UpdateFuncionario(editarFuncionario));
        }

        [HttpPut("inativa/{id:int}")]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> UpdateFuncionario(int id)
        {
            return Ok(await _funcionarioService.InvalidaFuncionario(id));
        }
    }
}
