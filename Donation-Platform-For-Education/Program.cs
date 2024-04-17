
using Donation_Platform_For_Education.Application;
using Donation_Platform_For_Education.Infarstructure;

namespace Donation_Platform_For_Education
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            // Add services to the container.



            builder.Services.AddControllers();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(configuration);






            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
