using PersonTable.Banco;
using PersonTable.Modelo;

Console.WriteLine("Testando");

var novaPessoa = new Person
{
    PersonId = 3002,
    Name = "Pedro",
    Age = 20,
    EstadoCivil = "Solteiro",
    Cpf = "111.222.333-00",
    Cidade = "Teresopolis",
    Estado = "RJ"
};

try
{
    using(var context = new PersonContext())
    {
        var dal = new Dal<Person>(context);
        var lista = dal.Listar();
        foreach (var item in lista)
        {
            Console.WriteLine($"{item.Name} - {item.Cpf}");
        }
    }
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}