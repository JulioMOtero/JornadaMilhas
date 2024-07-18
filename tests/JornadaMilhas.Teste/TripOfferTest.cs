using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Teste
{
    public class TripOfferTest
    {
        [Fact]
        public void TestingValidOffer()
        {
            //arrange
            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1),new DateTime(2024, 2, 5));
            double price = 100.0;
            var validation = true;
            //act
            TripOffer oferta = new TripOffer(route, period, price);
            //assert
            Assert.Equal(validation,oferta.IsValid);
        }
        [Fact]
        public void TestingValidOfferNullRoute()
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
    }
}
