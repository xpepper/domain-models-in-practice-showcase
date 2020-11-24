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
        private Customer_reservations _readmodel;
        public QueryHandler(Customer_reservations customer_reservations_readmodel, List<object> history, Action<object> respond)
        {
            History = history;
            Respond = respond;
            _readmodel = customer_reservations_readmodel; // For this demo we just inject one readmodel. In production you'd want to register all readmodels in here.
        }

        public void handle(object query)
        {
            
            if (query is My_reservations q) 
            {
                Respond(new ReservationInfo(_readmodel.Reservations[q.Customer]));
                // Did I just forget to check if the customer actually exist?
                // Well, there would never be a query with an illegal customer, right? :D:D:D
            }
        }


    }
}