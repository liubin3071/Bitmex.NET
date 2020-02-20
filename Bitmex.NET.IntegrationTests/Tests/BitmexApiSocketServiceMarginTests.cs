﻿using Bitmex.NET.Dtos;
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
    public class BitmexApiSocketServiceMarginTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_margin()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<MarginDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.MarginResponseReceived += (sender, args) =>
                {
                    dtos = args.Response.Data;
                    dataReceived.Set();
                };

                var subscription = new SubscriptionRequest(SubscriptionType.margin);

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
        }
    }
}