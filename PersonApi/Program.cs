using PersonTable.Banco;
using PersonTable.Modelo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var dal = new Dal<Person>(new PersonContext());
    return dal.Listar();
});

app.Run();
