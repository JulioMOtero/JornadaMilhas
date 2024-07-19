using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class Period: Valid
{
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }

    public Period(DateTime initialDate, DateTime finalDate)
    {
        InitialDate = initialDate;
        FinalDate = finalDate;
        Validate();
    }

    protected override void Validate()
    {
        if (InitialDate > FinalDate)
        {
            Errors.RegisterError("Erro: Data de ida não pode ser maior que a data de volta.");
        }

        
    }
}
