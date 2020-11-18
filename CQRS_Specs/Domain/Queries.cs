using System;

namespace CQRS_Demo.Domain.Queries
{
    public struct My_reservations
    {
        public readonly Guid Customer;

        public My_reservations(Guid customer)
        {
            Customer = customer;
        }
    }
}
