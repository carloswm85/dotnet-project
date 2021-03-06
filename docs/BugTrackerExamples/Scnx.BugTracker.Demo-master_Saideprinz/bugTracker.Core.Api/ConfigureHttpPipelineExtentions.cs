using System.Collections.Generic;
using bugTracker.Core.Common;
using bugTracker.Core.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OwaspHeaders.Core;
using OwaspHeaders.Core.Enums;
using OwaspHeaders.Core.Extensions;
using OwaspHeaders.Core.Models;

namespace bugTracker.Core
{
    /// <summary>
    /// This class is based on some of the suggestions bty K. Scott Allen in
    /// his NDC 2017 talk https://www.youtube.com/watch?v=6Fi5dRVxOvc
    /// </summary>
    public static class ConfigureHttpPipelineExtentions
    {
        private static string CorsPolicyName => new CorsConfiguration().GetCorsPolicyName();
        
        public static void UseCustomisedMvc(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static void UseCorsPolicy(this IApplicationBuilder applicationBuilder, string corsPolicyName = null)
        {
            applicationBuilder.UseCors(corsPolicyName ?? CorsPolicyName);
        }

        // public static int EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder,
        //     bool autoMigrateDatabase)
        // {
        //     // seed the database using an extension method
        //     using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
        //         .CreateScope())
        //     {
        //         var context = serviceScope.ServiceProvider.GetService<BugContext>();
        //         if (autoMigrateDatabase)
        //         {
        //             //context.Database.Migrate();
        //         }
        //         //return context.EnsureSeedData();
        //     }
        // }

        /// <summary>
        /// Used to tell the <see cref="IApplicationBuilder"/> to use Swagger and the Swagger UI
        /// </summary>
        /// <param name="applicationBuilder">
        /// The <see cref="IApplicationBuilder"/> which is used in the Http Pipeline
        /// </param>
        /// <param name="swaggerUrl">The URL for the Swagger endpoint</param>
        /// <param name="swaggerDescription">The description for the Swagger endpoint</param>
        public static void UseSwagger(this IApplicationBuilder applicationBuilder,
            string swaggerUrl, string swaggerDescription)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            applicationBuilder.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying
            // the Swagger JSON endpoint.
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerUrl, swaggerDescription);
            });
        }

        /// <summary>
        /// Used to include the <see cref="SecureHeadersMiddleware"/> middleware and set up the
        /// <see cref="SecureHeadersMiddlewareConfiguration"/> for it.
        /// </summary>
        /// <param name="applicationBuilder">
        /// The <see cref="IApplicationBuilder"/> which is used in the Http Pipeline
        /// </param>
        /// <param name="blockAndUpgradeInsecure">
        /// OPTIONAL: Used to enable/disable blocking and upgrading odf all requests
        /// when not in developement
        /// </param>
        public static void UseSecureHeaders(this IApplicationBuilder applicationBuilder, bool blockAndUpgradeInsecure = true)
        {
            var config = SecureHeadersMiddlewareBuilder
                .CreateBuilder()
                .UseHsts()
                .UseXFrameOptions()
                .UseXSSProtection()
                .UseContentTypeOptions()
                .UseContentSecurityPolicy(blockAllMixedContent:blockAndUpgradeInsecure, upgradeInsecureRequests: blockAndUpgradeInsecure)
                .UsePermittedCrossDomainPolicies()
                .UseReferrerPolicy()
                .Build();

            config.ContentSecurityPolicyConfiguration.ScriptSrc = new List<ContenSecurityPolicyElement>()
            {
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "self"
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-gw/4FeYphgTzu5mo/iOEEHUjrRJsQ/F6lgqdtSc23GU="
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-7I8kfi1IZHgnTNHryKWWH/oZV9dIkctQ77ABbgrpy6w="
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-3kf2chgLlsbYoTHVrm7JlIF6/529E3h6TGATiBxN4kU="
                },
                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-j4Lx1FqFgvYDBEjW7NQaEY7/HhCi8WVsLWkqC4+wJ3w="
                },

                new ContenSecurityPolicyElement
                {
                    CommandType = CspCommandType.Directive,
                    DirectiveOrUri = "sha256-imr81cRqVZ10hwXR/UYsT/lF6pwgRUdP9jjyUiuDxQU="
                }
            };
            
            applicationBuilder.UseSecureHeadersMiddleware(config);
        }
    }
}