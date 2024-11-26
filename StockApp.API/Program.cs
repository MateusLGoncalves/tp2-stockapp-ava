using StockApp.Infra.IoC;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona autentica��o e cookies
        builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", options =>
            {
                options.LoginPath = "/api/auth/login"; // Rota para redirecionar em caso de login necess�rio
                options.AccessDeniedPath = "/api/auth/denied";
            });

        // Adiciona autoriza��o com pol�tica baseada em claims
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("CanManageProducts", policy =>
                policy.RequireClaim("Permission", "CanManageProducts"));
        });

        // Add services to the container.
        builder.Services.AddInfrastructureAPI(builder.Configuration);

        builder.Services.AddControllers();

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

        app.UseRouting();

        app.UseAuthorization();

        app.UseAuthentication();

        app.MapControllers();

        app.Run();
    }
}