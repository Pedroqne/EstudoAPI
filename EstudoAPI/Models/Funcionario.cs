using EstudoAPI.Enums;

namespace EstudoAPI.Models;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DepartamentEnum Departamento { get; set; }
    public bool Ativo { get; set; }
    public TurnoEnum Turno { get; set; }
    public DateTime DataDeCricao { get; set; }
    public DateTime DataDeAlteracao { get; set; }
}
