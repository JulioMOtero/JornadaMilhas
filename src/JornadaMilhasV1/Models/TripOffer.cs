using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class TripOffer : Valid
{
    private double discount;

    public int Id { get; set; }
    public Route Route { get; set; }
    public Period Period { get; set; }
    public double Price { get; set; }
    public const double MaxDiscount = 0.7;
    public bool Active { get; set; } = true;
    public double Discount
    {
        get => discount;
        set
        {
            discount = value;
            if (discount <=  0) { }
            else if (discount >= Price)
            {
                Price *= (1 - MaxDiscount);
            }
            else
            {
                Price -= discount;
            }
        }
    }


    public TripOffer(Route route, Period period, double price)
    {
        Route = route;
        Period = period;
        Price = price;
        Validate();
    }

    public override string ToString()
    {
        return $"Origem: {Route.Origin}, Destino: {Route.Destiny}, Data de Ida: {Period.InitialDate.ToShortDateString()}, Data de Volta: {Period.FinalDate.ToShortDateString()}, Preço: {Price:C}";
    }

    protected override void Validate()
    {
        if (!Period.IsValid)
        {
            Errors.RegisterError(Period.Errors.Sumario);
        }
        if (Route == null || Period == null)
        {
            Errors.RegisterError("A oferta de viagem não possui rota ou período válidos.");
        }
        if (Price <= 0)
        {
            Errors.RegisterError("O preço da oferta de viagem deve ser maior que zero.");
        }
    }
}
