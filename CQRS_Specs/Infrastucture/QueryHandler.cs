using System;
using System.Collections.Generic;
using CQRS_Demo.Domain;
using CQRS_Demo.Domain.Queries;
using CQRS_Demo.Domain.Readmodels;

namespace CQRS_Demo.Infrastucture
{

    // This Queryhandler instantiates all readmodels only once, and never updates them live
    // This behaviour will follow in the coming days
    public class QueryHandler
    {
        public List<object> History;
        public Action<object> Respond;

        public QueryHandler(List<object> history, Action<object> respond)
        {
            History = history;
            Respond = respond;
        }

        public void handle(object query)
        {
            if (query is My_reservations q) 
            {
                var readmodel = new Customer_reservations(History);
                Respond(new ReservationInfo(readmodel.Reservations[q.Customer]));
                // Did I just forget to check if the customer actually exist?
                // Well, there would never be a query with an illegal customer, right? :D:D:D
            }
        }


    }
}