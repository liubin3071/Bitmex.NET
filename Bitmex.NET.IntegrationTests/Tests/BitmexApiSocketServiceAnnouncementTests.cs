using Bitmex.NET.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bitmex.NET.Models.Socket;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceAnnouncementTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_funding()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<AnnouncementDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.AnnouncementResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.announcement);

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                // assert
                // no exception raised
                connected.Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }
    }
}