using Bogus;
using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class GerenciadorDeOfertasGetMaxDiscount
    {

        [Fact]
        //Destiny São Paulo discount 40 price = 80
        public void ReturnsOfferWhenDestinySaoPauloAndDiscount40()
        {
            //arrange
            var fakerPeriod = new Faker<Period>().CustomInstantiator(f =>
            {
                DateTime initialDate = f.Date.Soon();
                return new Period(initialDate, initialDate.AddDays(30));
            });
            var route = new Route("Curitiba", "São Paulo");

            var fakerOffer = new Faker<TripOffer>()
                .CustomInstantiator(f => new TripOffer(route, fakerPeriod.Generate(), 100 * f.Random.Int(1, 100)))
                .RuleFor(o => o.Discount, f => 40)
                .RuleFor(o => o.Active, f => true);

            var chosenOffer = new TripOffer(route, fakerPeriod.Generate(), 80){ Discount = 40 , Active = true};
            var inactiveOffer = new TripOffer(route, fakerPeriod.Generate(), 70) { Discount = 40, Active = false };
            var TripOfferList = fakerOffer.Generate(200);
            TripOfferList.Add(chosenOffer);
            TripOfferList.Add(inactiveOffer);    
            var manager = new GerenciadorDeOfertas(TripOfferList);
            Func<TripOffer, bool> filter = o => o.Route.Destiny.Equals("São Paulo");
            var expectedPrice = 40;

            //act
            var offer = manager.ReturnsMaxDiscount(filter);

            //assert
            Assert.NotNull(offer);
            Assert.Equal(expectedPrice, offer.Price, 0.0001);
        }
    }
}
