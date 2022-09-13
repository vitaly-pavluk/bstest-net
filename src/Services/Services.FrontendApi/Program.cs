using Services.FrontendApi.Services;

var builder = WebApplication.CreateBuilder(args);


// configure http header propagation
builder.Services.AddHeaderPropagation
(
    opt=>
    {
        opt.Headers.Add("kubernetes-route-as");
        opt.Headers.Add("Postman-Token");
    }
);
builder.Logging.AddConsole();

// configure HttpClient 
builder.Services.AddHttpClient<WorkTaskBackendService>((sp,c)=>
{
    c.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>().GetConnectionString("BackendTaskApi"));

}).AddHeaderPropagation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


   

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseHeaderPropagation();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
