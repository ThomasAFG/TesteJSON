using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWkhtmltopdf();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


/*app.MapWhen(context => {
        var url = context.Request.Path.Value;
        return (context.Request.Host.Host != "localhost") && !context.Request.IsHttps;
    },
    subapp => subapp.UseHttpsRedirection());*/


app.UseDefaultFiles();

app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
