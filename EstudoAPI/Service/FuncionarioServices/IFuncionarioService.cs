using EstudoAPI.Models;

namespace EstudoAPI.Service.FuncionarioService
{
    public interface IFuncionarioService
    {
        Task<ServiceResponse<List<Funcionario>>> GetFuncionario();

        Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario);

        Task<ServiceResponse<Funcionario>> GetFuncionarioById(int id);

        Task<ServiceResponse<List<Funcionario>>> UpdateFuncionario(Funcionario editarFuncionario);

        Task<ServiceResponse<List<Funcionario>>> DeleteFuncionario(int id);

        Task<ServiceResponse<List<Funcionario>>> InvalidaFuncionario(int id);



    }
}
