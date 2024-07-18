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


        [Fact]
        public void ReturnMaxDiscountWHenDiscountBiggerThenPRice()
        {
            //arrange

            Route route = new Route("OriginTest", "DestinyTest");
            Period period = new Period(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double originalPrice = 100.0;
            double discount = 120.00;
            double PriceWithDiscount = 30.00;

            TripOffer offer = new TripOffer(route, period, originalPrice);

            //act
            //uses the discount to apply it on the price
            offer.Discount = discount;

            //assert

            Assert.Equal(PriceWithDiscount, offer.Price);

        }
    }
}
