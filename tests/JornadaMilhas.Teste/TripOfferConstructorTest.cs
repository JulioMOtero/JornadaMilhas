using JornadaMilhasV1.Modelos;
using JornadaMilhasV1.Validador;

namespace JornadaMilhas.Teste
{
    public class TripOfferConstructorTest
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OriginTest", "DestinyTest", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void ReturnsValidationAccordingToInputData(string origin, string destiny, string initialDate, string finalDate, double price, bool validation)
        {
            //arrange
            Route route = new Route(origin, destiny);
            Period period = new Period(DateTime.Parse(initialDate), DateTime.Parse(finalDate));

            //act
            TripOffer offer = new TripOffer(route, period, price);

            //assert
            Assert.Equal(validation, offer.IsValid);
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

        [Theory]
        [InlineData("OriginTest", "DestinyTest", "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OriginTest", "DestinyTest", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void ReturnsInvalidPriceErrorMessageWhenPriceIsLessThanZero(string origin, string destiny, string initialDate, string finalDate, double price, bool validation)
        {
            //arrage
            Route route = new Route(origin, destiny);
            Period period = new Period(DateTime.Parse(initialDate), DateTime.Parse(finalDate));

            //act
            TripOffer offer = new TripOffer(route, period, price);

            //assert
            Assert.Equal(validation, offer.IsValid);
        }

        [Fact]
        public void ReturnsAllErrorsMessagesFromValidateWhenPeriodAndPriceAreInvalid()
        {
            //arrange
            int expectedNumberOfErrors=3;
            Route route = null;
            Period period = new Period(new DateTime(2024, 6, 1), new DateTime(2024, 5, 10));
            double price = -10;

            //act
            TripOffer offer = new TripOffer(route, period,price);

            //assert
            Assert.Equal(expectedNumberOfErrors,offer.Errors.Count());

        }
    }
}
