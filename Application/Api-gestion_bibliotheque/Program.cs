using Api_gestion_bibliotheque.Configurations;
using Api_gestion_bibliotheque.Services.Contracts;
using Api_gestion_bibliotheque.Services.Implementations;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Récupération des paramètres
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// La configuration pour se connecter à la base de données
var serverAccess = builder.Configuration.GetSection("MongoDbSettings:ConnectionURI").Value;
builder.Services.AddSingleton<IMongoClient>(new MongoClient(serverAccess));

// Ajouter des services
builder.Services.AddScoped<ILivreService, LivreService>();
builder.Services.AddScoped<IAuteurService, AuteurService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Include xml comment on the swagger view
builder.Services.AddSwaggerGen(options => options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Api-gestion_bibliotheque.xml")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(options => options
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
