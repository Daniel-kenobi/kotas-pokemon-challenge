using Appllication.Mediators.Pokemon.Command;
using Appllication.Mediators.Pokemon.Query;
using Appllication.Mediators.PokemonMaster.Command;
using Appllication.Mediators.PokemonMaster.Query;
using Domain.Interfaces.Repository;
using Domain.Mediators.Pokemon.Commmand;
using Domain.Mediators.Pokemon.Query;
using Domain.Mediators.PokemonMaster.Command;
using Domain.Mediators.PokemonMaster.Query;
using Domain.Model;
using Infraestructure.Data;
using Infraestructure.DenpendyInjection;
using Infraestructure.Repository.Pokemon;
using Infraestructure.Repository.PokemonMaster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonWebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);

string dbPath = Path.Join(path, "pokemon.db");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectDependencies();
builder.Services.AddMediatR(x =>
 {
     x.RegisterServicesFromAssemblies(typeof(PokemonMasterController).Assembly, typeof(InsertPokemonMasterCommand).Assembly);
 });

await SeedDatabase.SeedAsync();

builder.Services.AddTransient<IRequestHandler<InsertPokemonMasterCommand, Response<PokemonMaster>>, InsertPokemonMasterCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetRandomPokemonQuery, List<Domain.Model.Pokemon>>, GetRandomPokemonQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetPokemonByIdQuery, Domain.Model.Pokemon>, GetPokemonByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<CapturePokemonCommand>, CapturePokemonCommandHandler>();
builder.Services.AddTransient<IRequestHandler<GetCapturedPokemonsQuery, List<Domain.Model.Pokemon>>, GetCapturedPokemonsQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllPokemonMastersQuery, List<Domain.Model.PokemonMaster>>, GetAllPokemonMastersQueryHandler>();

builder.Services.AddScoped<IRepositoryBase<Domain.Entities.PokemonMaster>, PokemonMasterRepository>();

builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon API V1");
    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
