using NUnit.Framework;

namespace CQRS_Demo.Tests
{
    // These are domain-driven tests that test the interoperation of your command and query side
    // Because the Events don't matter from the outside, we do not have to test for them
    public class Full_system_tests : Test_base
    {
        [Test]
        public void A_customer_can_reserve_additional_seats_and_see_their_full_reservations()
        {
            Given(
                Screening_has_been_planned(Screening_1(), December_2nd_2020(), Cinema_1()),
                Seat_has_been_reserved(Screening_1(), Seat_A1(), Marco()),
                Seat_has_been_reserved(Screening_1(), Seat_A3(), Tina()));

            When(
                Reserve_seat(Screening_1(), Seat_A2(), Marco()));

            When_Query(
                My_reservations(Marco()) );

            Then_expect_response(
                Reservations(
                    Reservation(Screening_1(), Seat_A1()),
                    Reservation(Screening_1(), Seat_A2())) );
        }
    }

}