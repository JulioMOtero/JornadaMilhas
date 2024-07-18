using JornadaMilhasV1.Modelos;
using JornadaMilhasV1.Validador;

namespace JornadaMilhas.Teste
{
    public class TripOfferConstructorTest
    {
        [Fact]
        public void ReturnsValidOfferWithValidData()
        {
            //arrange
            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1),new DateTime(2024, 2, 5));
            double price = 100.0;
            var validation = true;
            //act
            TripOffer offer = new TripOffer(route, period, price);
            //assert
            Assert.Equal(validation,offer.IsValid);
        }
        [Fact]
        public void ReturnsInvalidRouteOrPeriodErrorMessageWhenRouteIsNull()
        {
            //arrange
            Route route = null;
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = 100.0;

            //act
            TripOffer oferta = new TripOffer(route, period, price);

            //assert
            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Errors.Sumario);
            Assert.False(oferta.IsValid);
        }

        [Fact]
        public void ReturnsInvalidPriceErrorMessageWhenPriceIsLessThanZero()
        {
            //arrage
            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double price = -100.0;

            //act
            TripOffer offer = new TripOffer(route,period,price);

            //assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.",offer.Errors.Sumario);

        }
    }
}
