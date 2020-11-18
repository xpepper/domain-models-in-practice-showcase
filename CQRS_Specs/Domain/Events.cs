using System;

namespace CQRS_Demo.Domain.Events
{
    public struct Seat_has_been_reserved
    {
        public Guid Screening;
        public Guid Seat;
        public Guid Customer;

        public Seat_has_been_reserved(Guid screening, Guid seat, Guid customer)
        {
            Screening = screening;
            Seat = seat;
            Customer = customer;
        }
    }

    public struct Screening_has_been_planned
    {
        public Guid Screening;
        public DateTime Date;
        public Guid Cinema;

        public Screening_has_been_planned(Guid screening, in DateTime date, Guid cinema)
        {
            Screening = screening;
            Date = date;
            Cinema = cinema;
        }
    }

    public struct Seat_cannot_be_reserved
    {
        public Guid Screening;
        public Guid Seat;

        public Seat_cannot_be_reserved(Guid screening, Guid seat)
        {
            Screening = screening;
            Seat = seat;
        }
    }

}
