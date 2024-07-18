using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Validador;

public abstract class Valid : IValidavel
{
    private readonly Errors errors = new();
    public bool IsValid => errors.Count() == 0;
    public Errors Errors => errors;
    protected abstract void Validate();
}
