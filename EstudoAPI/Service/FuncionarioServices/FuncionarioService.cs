using EstudoAPI.Context;
using EstudoAPI.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EstudoAPI.Service.FuncionarioService
{


    public class FuncionarioService : IFuncionarioService
    {
        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Insira os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                
                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if(funcionario == null)
                {
                    serviceResponse.Mensagem = "Funcioário não foi encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Mensagem = "Funcionário deletado com sucesso!";

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> GetFuncionario()
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Funcionario>> GetFuncionarioById(int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();
            try
            {
                serviceResponse.Dados = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (serviceResponse.Dados is null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado!";
                    serviceResponse.Sucesso = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> InvalidaFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                var funcionario = _context.Funcionarios.FirstOrDefault(y => y.Id == id);

                if (funcionario is null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                serviceResponse.Mensagem = "Funcionário inativado!";

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(Funcionario editarFuncionario)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                if (editarFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado!";
                    serviceResponse.Sucesso=false;

                    return serviceResponse;
                }

                serviceResponse.Mensagem = "Funcionário alterado com sucesso!";


                _context.Funcionarios.Update(editarFuncionario);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
