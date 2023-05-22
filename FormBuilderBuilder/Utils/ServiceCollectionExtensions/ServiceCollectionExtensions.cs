using FormBuilderBuilder.Services;

namespace FormBuilderBuilder.Utils.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
	public static void RegisterServices(this IServiceCollection services)
	{
		services.AddTransient<BuildPages>();
		services.AddTransient<JSONEdits>();
	}

}
