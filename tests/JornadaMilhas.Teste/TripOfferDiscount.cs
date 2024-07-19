using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class TripOfferDiscount
    {
        [Fact]
        public void ReturnPriceWithDiscountWhenApplied()
        {
            //arrange

            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double originalPrice = 100.0;
            double discount = 20.00;
            double PriceWithDiscount = originalPrice - discount;

            TripOffer offer = new TripOffer(route,period,originalPrice);

            //act
            //uses the discount to apply it on the price
            offer.Discount = discount;

            //assert

            Assert.Equal(PriceWithDiscount, offer.Price);

        }


        [Theory]
        [InlineData(120.00, 30.00)]
        [InlineData(100.00, 30.00)]
        public void ReturnMaxDiscountWhenDiscountBiggerOrEqualstoThePrice( double discount, double PriceWithDiscount)
        {
            //arrange
            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double originalPrice = 100.0;
            TripOffer offer = new TripOffer(route, period, originalPrice);

            //act
            //uses the discount to apply it to the price and if the discount is bigger then the price returns with max dicount 
            offer.Discount = discount;

            //assert

            Assert.Equal(PriceWithDiscount, offer.Price,0.001);

        }

        [Fact]
        public void ReturnOriginalPriceWHenDiscountValueIsNegative()
        {
            //arrange

            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double originalPrice = 100.0;
            double discount = -20.00;
            

            TripOffer offer = new TripOffer(route, period, originalPrice);

            //act
            //uses the discount to apply it on the price and if the discount is bigger then the price returns with max dicount 
            offer.Discount = discount;

            //assert

            Assert.Equal(originalPrice, offer.Price, 0.001);

        }
    }
}
