using DataProvider;
using DataRepository;
using DataRepository.DataProtection;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Site.App_Start;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(OWinStartup))]
namespace Site.App_Start
{
    public class OWinStartup
    {
        internal static OAuthAuthorizationServerOptions AuthServerOptions;
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        static OWinStartup()
        {
            DataProtectionProvider = new MachineKeyProtectionProvider();
            AuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10800),
                Provider = new SimpleAuthorizationServerProvider(DataProtectionProvider),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(DataProtectionProvider)
            };
        }

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {

            app.SetDataProtectionProvider(DataProtectionProvider);

            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            // Token Generation
            app.UseOAuthAuthorizationServer(AuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

    }
}