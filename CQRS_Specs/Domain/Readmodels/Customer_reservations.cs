using System;
using System.Collections.Generic;
using CQRS_Demo.Domain.Events;

namespace CQRS_Demo.Domain.Readmodels
{
    public class Customer_reservations
    {
        public Dictionary<Guid, List<Reservation>> Reservations;

        public Customer_reservations(IEnumerable<object> history)
        {
            Reservations = new Dictionary<Guid, List<Reservation>>();
            foreach (dynamic e in history)
            {
                Apply(e);
            }
        }

        private void Apply(object e) { }
        private void Apply(Seat_has_been_reserved e)
        {
            if (!Reservations.ContainsKey(e.Customer))
            {
                Reservations.Add(e.Customer, new List<Reservation>());
            }
            Reservations[e.Customer].Add(new Reservation(e.Screening, e.Seat));
        }

    }
}
