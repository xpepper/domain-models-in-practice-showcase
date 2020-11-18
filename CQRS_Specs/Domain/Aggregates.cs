using System;
using System.Collections.Generic;
using CQRS_Demo.Domain.Events;

namespace CQRS_Demo.Domain
{
    // The Aggregate that protects the invariants around reserving seats
    // Ensures transactional consistent and domain-correct behaviour for all involved classes
    // In a real life implementation you wouldn't store this in an Aggregate.cs,
    // but put it in domain specific files and folders.
    public class Screening_reservations
    {
        private readonly Action<object> _publish;
        private Screening_reservations_state _state;
        public Screening_reservations(Screening_reservations_state state, Action<object> publish)
        {
            _publish = publish;
            _state = state;
        }

        public void reserve(Guid screening, Guid seat, Guid customer)
        {
            if (seat_already_reserved(screening, seat))
                _publish(new Seat_cannot_be_reserved(screening, seat));
            else
                _publish(new Seat_has_been_reserved(screening, seat, customer));
        }

        private bool seat_already_reserved(Guid screening, Guid seat) => _state.Screenings[screening].Contains(seat);
    }


    public class Screening_reservations_state
    {
        public Dictionary<Guid, List<Guid>> Screenings;

        public Screening_reservations_state(IEnumerable<object> events)
        {
            foreach (dynamic e in events)
            {
                Apply(e);
            }
        }

        private void Apply(object e) {}
        private void Apply(Screening_has_been_planned e) => Screenings = new Dictionary<Guid, List<Guid>> {{e.Screening, new List<Guid>()}};
        private void Apply(Seat_has_been_reserved e) => Screenings[e.Screening].Add(e.Seat);
    }
}
