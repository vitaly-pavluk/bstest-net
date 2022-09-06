using Services.FrontendApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHeaderPropagation
(opt=>
    {
        opt.Headers.Add("kubernetes-route-as");
        opt.Headers.Add("Postman-Token");
    }
);

builder.Services.AddHttpClient<WorkTaskService>((sp,c)=>
{
    c.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>().GetConnectionString("TaskApi"));
}).AddHeaderPropagation();

//builder.Services.AddTransient<WorkTaskService>();


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
