using Bitmex.NET.Authorization;
using Bitmex.NET.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using Unity;
using Unity.Extension;
using Unity.Lifetime;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace Bitmex.NET.IntegrationTests
{
    public sealed class BitmexNetUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBitmexApiProxy, BitmexApiProxy>();
            Container.RegisterType<IBitmexApiService, BitmexApiService>();
            Container.RegisterType<IBitmexApiSocketService, BitmexApiSocketService>();
            Container.RegisterType<IBitmexApiSocketProxy, BitmexApiSocketProxy>();
            Container.RegisterType<IExpiresTimeProvider, ExpiresTimeProvider>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISignatureProvider, SignatureProvider>(new ContainerControlledLifetimeManager());

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            var key = config.GetValue<string>("Key");
            var secret = config.GetValue<string>("Secret");
            var env = config.GetValue<string>("Environment");
            var bitmexEnvironment = (BitmexEnvironment)Enum.Parse(typeof(BitmexEnvironment), env);

            var authorization = new BitmexAuthorization
            {
                Key = key,
                Secret = secret,
                BitmexEnvironment = bitmexEnvironment,
            };

            Container.RegisterInstance<IBitmexAuthorization>(authorization);
        }
    }
}