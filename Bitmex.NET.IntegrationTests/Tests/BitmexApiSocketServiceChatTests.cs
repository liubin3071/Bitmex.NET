using Bitmex.NET.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using CoinGroup.Market.Bitmex.Models.Websockets.Requests;
using Unity;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceChatTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_chat()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<ChatDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.ChatResponseReceived += (sender, args) =>
                {
                    if (args.Response.Data.Any())
                    {
                        dtos = args.Response.Data;
                        dataReceived.Set();
                    }
                };

                var subscription = new SubscriptionRequest(SubscriptionType.chat);

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                //Send Chat Message to for testing
                SendChatMessage();
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

        private void SendChatMessage()
        {
            var bitmexRestApi = Container.Resolve<IBitmexApiService>();
            var @params = new ChatPOSTRequestParams()
            {
                Message = "Long Live Bitmex.NET",
                //English channel
                ChannelID = 1,
            };
            var result = bitmexRestApi.Execute(BitmexApiUrls.Chat.PostChat, @params).Result.Result;
        }
    }
}