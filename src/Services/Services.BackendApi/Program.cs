var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHeaderPropagation
(
    opt=>
    {
        opt.Headers.Add("kubernetes-route-as");
    }
);

builder.Services.AddHttpClient<WorkTaskStorageService>((sp,c)=>
{
    c.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>().GetConnectionString("StorageTaskApi"));

}).AddHeaderPropagation();

builder.Logging.AddConsole();

var app = builder.Build();

app.UseHeaderPropagation();
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();
app.MapGet("/", async context =>
{
    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync("healthy");
});

app.Run();