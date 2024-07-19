using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV1.Gerencidor;
public class GerenciadorDeOfertas
{
    private List<TripOffer> TripOffer = new List<TripOffer>();

    public GerenciadorDeOfertas(List<TripOffer> TripOffer)
    {
        this.TripOffer = TripOffer;
    }

    public void RegisterOffer()
    {
        Console.WriteLine("-- Cadastro de ofertas --");
        Console.WriteLine("Informe a cidade de origem: ");
        string origin = Console.ReadLine();

        Console.WriteLine("Informe a cidade de destino: ");
        string destiny = Console.ReadLine();

        Console.WriteLine("Informe a data de ida (DD/MM/AAAA): ");
        DateTime departure;
        if (!DateTime.TryParse(Console.ReadLine(), out departure))
        {
            Console.WriteLine("Data de ida inválida.");
            return;
        }

        Console.WriteLine("Informe a data de volta (DD/MM/AAAA): ");
        DateTime arrival;
        if (!DateTime.TryParse(Console.ReadLine(), out arrival))
        {
            Console.WriteLine("Data de volta inválida.");
            return;
        }

        Console.WriteLine("Informe o preço: ");
        double price;
        if (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Formato de preço inválido.");
            return;
        }

        TripOffer registeredOffer = new TripOffer(new Route(origin, destiny), new Period(departure, arrival), price);
        AdicionarOfertaNaLista(registeredOffer);

        Console.WriteLine("\nOferta cadastrada com sucesso.");
    }

    public bool AdicionarOfertaNaLista(TripOffer registeredOffer)
    {
        if (registeredOffer != null)
        {
            TripOffer.Add(registeredOffer);
            return true;
        }
        return false;

    }

    public TripOffer? ReturnsMaxDiscount(Func<TripOffer,bool> filter) => TripOffer
        .Where(filter)
        .Where(o => o.Active)
        .OrderBy(o => o.Price)
        .FirstOrDefault();


    public void CarregarOfertas()
    {
        AdicionarOfertaNaLista(new TripOffer(new Route("São Paulo", "Curitiba"), new Period(new DateTime(2024, 1, 15), new DateTime(2024, 1, 20)), 500));
        AdicionarOfertaNaLista(new TripOffer(new Route("Recife", "Rio de Janeiro"), new Period(new DateTime(2024, 2, 10), new DateTime(2024, 2, 15)), 700));
        AdicionarOfertaNaLista(new TripOffer(new Route("Acre", "Brasília"), new Period(new DateTime(2024, 3, 5), new DateTime(2024, 3, 10)), 600));
    }

    public void ExibirTodasAsOfertas()
    {
        Console.WriteLine("\nTodas as ofertas cadastradas: ");
        foreach (var oferta in TripOffer)
        {
            Console.WriteLine(oferta);
        }
    }
}
