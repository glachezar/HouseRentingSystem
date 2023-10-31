namespace HouseRentingSystem.Web.Infrastructure.Extentions
{
    using Microsoft.Extensions.DependencyInjection;

    using Data.Services;
    using Data.Services.Interfaces;
    using System.Reflection;

    public static class WebApplicationBuilderExtentions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assambly is taken from the type of random service implementation provided.
        /// </summary>
        /// <param name="serviceType">Type of random service implementation.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type inplementationType in serviceTypes)
            {
                Type? interfaceType = inplementationType.GetInterface($"I{inplementationType.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface is provided for the service with the name: {inplementationType.Name}");
                }

                services.AddScoped(interfaceType, inplementationType);
            }

        }
    }
}