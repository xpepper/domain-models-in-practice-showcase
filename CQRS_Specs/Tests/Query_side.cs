using NUnit.Framework;

namespace CQRS_Demo.Tests
{
    // These are domain-driven tests about the query side of your system
    // Ideally only written in Given / When_queried / Then_expect_result using Events and Queries/responses
    public class Query_side : Test_base
    {
        [Test]
        public void A_free_seat_can_be_reserved()
        {
            Given(
                Screening_has_been_planned(Screening_1(), December_2nd_2020(), Cinema_1()),
                Seat_has_been_reserved(Screening_1(), Seat_A1(), Marco()),
                Seat_has_been_reserved(Screening_1(), Seat_A2(), Marco()) );

            When_Query(
                My_reservations(Marco()) );

            Then_expect_response(
                Reservations(
                    Reservation(Screening_1(), Seat_A1()),
                    Reservation(Screening_1(), Seat_A2())) );
        }
    }

}