using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Validador;

public class Errors : IEnumerable<Error>
{
    private readonly ICollection<Error> erros = new List<Error>();

    public void RegisterError(string mensage) => erros.Add(new Error(mensage));

    public IEnumerator<Error> GetEnumerator()
    {
        return erros.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return erros.GetEnumerator();
    }

    public string Sumario
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var item in erros)
                sb.AppendLine(item.Mensage);
            return sb.ToString();
        }
    }
}

public record Error(string Mensage);

internal interface IValidavel
{
    // bool Validar();
    bool IsValid { get; }
    Errors Errors { get; }
}
