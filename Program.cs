using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

// Registrar os Repositories
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();