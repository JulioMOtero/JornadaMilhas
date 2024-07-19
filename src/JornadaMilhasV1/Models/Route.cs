using JornadaMilhasV1.Validador;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Modelos;

public class Route : Valid
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destiny { get; set; }

    public Route(string origin, string destiny)
    {
        Origin = origin;
        Destiny = destiny;

    }

    protected override void Validate()
    {
        if ((this.Origin is null) || this.Origin.Equals(string.Empty))
        {
            Errors.RegisterError("A rota não pode possuir uma origem nula ou vazia.");
        }
        else if ((this.Destiny is null) || this.Destiny.Equals(string.Empty))
        {
            Errors.RegisterError("A rota não pode possuir um destino nulo ou vazio.");
        }
    }
}
