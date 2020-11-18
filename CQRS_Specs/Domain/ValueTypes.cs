using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS_Demo.Domain
{
    public struct Reservation
    {
        public Guid Screening;
        public Guid Seat;

        public Reservation(Guid screening, Guid seat)
        {
            Screening = screening;
            Seat = seat;
        }
    }

    public readonly struct ReservationInfo
    {
        public readonly List<Reservation> Reservations;

        public ReservationInfo(IEnumerable<Reservation> reservations)
        {
            Reservations = reservations.ToList();
        }

        // I am sorry... I am soooo sorry ;)
        public bool Equals(ReservationInfo other)
        {
            if (Reservations.Count.Equals(other.Reservations.Count))
            {
                return Reservations.All(_ => other.Reservations.Contains(_));
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is ReservationInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Reservations != null ? Reservations.GetHashCode() : 0);
        }
    }


}
