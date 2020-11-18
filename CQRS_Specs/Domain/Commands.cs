using System;

namespace CQRS_Demo.Domain.Commands
{
    public struct Reserve_seat
    {
        public Guid Screening;
        public Guid Seat;
        public Guid Customer;

        public Reserve_seat(Guid screening, Guid seat, Guid customer)
        {
            Screening = screening;
            Seat = seat;
            Customer = customer;
        }
    }
}
