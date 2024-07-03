using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using LoginAPI.Controllers;
using LoginAPI.Interface;
using LoginAPI.Services;

namespace LoginAPI
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            service.AddAWSService<IAmazonDynamoDB>();
            service.AddScoped<IDynamoDBContext, DynamoDBContext>();

            service.AddTransient<IRegisterService, RegisterService>();
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;  // This sets Swagger UI at the app's root (http://localhost:<port>/)
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            

        }

    }
}
