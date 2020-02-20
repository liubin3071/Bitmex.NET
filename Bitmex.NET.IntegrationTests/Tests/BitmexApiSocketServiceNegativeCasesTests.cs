using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using Unity;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceNegativeCasesTests : IntegrationTestsClass<IBitmexApiSocketService>
    {
        private IBitmexAuthorization _bitmexAuthorization;

        [TestInitialize]
        public override void TestInitialize()
        {
            _bitmexAuthorization = Substitute.For<IBitmexAuthorization>();
            var container = new UnityContainer();
            container.AddNewExtension<BitmexNetUnityExtension>();
            container.RegisterInstance<IBitmexAuthorization>(_bitmexAuthorization);

            Sut = container.Resolve<IBitmexApiSocketService>();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            var key = config.GetValue<string>("Key");
            var secret = config.GetValue<string>("Secret");
            var env = config.GetValue<string>("Environment");
            _bitmexAuthorization.BitmexEnvironment.Returns(Enum.Parse(typeof(BitmexEnvironment), env));
            _bitmexAuthorization.Key.Returns(key);
            _bitmexAuthorization.Secret.Returns(secret);
        }

        [TestMethod]
        public void should_raise_an_exception_if_authorization_failed_due_to_key()
        {
            try
            {
                var wrongKey = Guid.NewGuid().ToString("N");
                _bitmexAuthorization.Key.Returns(wrongKey);

                // act
                Sut.Connect();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
            // assert
            catch (BitmexSocketAuthorizationException)
            {
                return;
            }

            Assert.Fail("BitmexSocketAuthorizationException should be thrown");
        }

        [TestMethod]
        public void should_raise_an_exception_if_authorization_failed_due_to_secret()
        {
            try
            {
                var wrongSign = Guid.NewGuid().ToString("N");
                _bitmexAuthorization.Secret.Returns(wrongSign);

                // act
                Sut.Connect();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Fail("connection limit reached");
            }
            // assert
            catch (BitmexSocketAuthorizationException)
            {
                return;
            }

            Assert.Fail("BitmexSocketAuthorizationException should be thrown");
        }
    }
}