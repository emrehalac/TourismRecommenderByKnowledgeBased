var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TourismRecommender.DataAccess.Repositories.IDestinationRepository,
    TourismRecommender.DataAccess.Repositories.InMemoryDestinationRepository>();
builder.Services.AddSingleton<TourismRecommender.Business.Services.IDestinationService,
    TourismRecommender.Business.Services.DestinationManager>();
builder.Services.AddSingleton<TourismRecommenderByKnowledgeBased.Services.RuleEngineService>();
builder.Services.AddHttpClient<TourismRecommenderByKnowledgeBased.Services.GeminiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
