using System.Collections.Generic;
using System.Linq;
using CQRS_Demo.Infrastucture;
using FluentAssertions;
using NUnit.Framework;

namespace CQRS_Demo.Tests
{
    public partial class Test_base
    {
        private List<object> _history;
        private List<object> _published_events;

        [SetUp]
        public void Setup()
        {
            _history = new List<object>();
            _published_events = new List<object>();
        }


        protected void Given(params object[] events) => _history = events.ToList();

        protected void When(object command)
        {
            var handler = new Commandhandler(_history, e => _published_events.Add(e));
            handler.handle(command);
        }

        protected void Then_expect(params object[] expected_events) => _published_events.Should().Equal(expected_events);
    }


}
