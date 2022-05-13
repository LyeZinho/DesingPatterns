using DesingPatterns;
using System;
//using DesingPatterns.Criacional.Singleton;
using DesingPatterns.Estrutural.Bridge;
static class Program
{
    static void Main()
    {
        /*
        Cria um objeto calcula salario do tipo CalculaSalario
        Passa como parametro uma instansia do tipo GeraJson que implementa a interface IGeraArquivo
        */
        CalculaSalario calculaSalario = new CalculaSalario(new GeraJson());

        //Cria um objeto funcionario
        Funcionario funcionario = new Funcionario()
        {
            Cargo = "Desenvolvedor",
            Nome = "Fulano",
            Departamento = "TI",
            Salario = 1000,
            Id = 1,
            Incentivo = 30.0,
        };

        //Chama o metodo CalculaSalario e processa os dados de funcionario
        calculaSalario.SalvarArquivo(funcionario);
    }
}