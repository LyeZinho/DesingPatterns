using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace DesingPatterns.Estrutural.Bridge
{
    /*
    Modelo de dominio
    Classe funcionarios ou seja a classe para 
    qual sera calculado o salario
     */
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public double Incentivo { get; set; }
        public double SalarioTotal { get; set; }
        public string Departamento { get; set; }
    }

    /*
    Interface que representa o bridge
    
     */
    public interface IGeraArquivo
    {
        /*
         Define como os arquivos serao gerados
        não possui implementação
        Define um metodo 
        Recebe um objeto Funcionario
        Salva o arquivo no formato especificado
         */
        void SalvarArquivo(Funcionario funcionario);
    }

    /*
     Implentação para gerar arquivo em formato json
    recebe funcionario e gera um json
     */
    public class GeraJson : IGeraArquivo
    {
        private string nomeArquivo = "SalarioFuncionaro.json";
            
        public void SalvarArquivo(Funcionario funcionario)
        {
            var SeFuncionario = JsonSerializer.Serialize(funcionario);

            File.WriteAllText(nomeArquivo, SeFuncionario);

            Console.WriteLine("Gerado salario com sucesso para o funcionario: " + funcionario.Nome);
        }
    }

    /*
     Implentação para gerar arquivo em formato xml
    recebe funcionario e gera um xml
     */
    public class GeraXml : IGeraArquivo
    {
        private string nomeArquivo = "SalarioFuncionaro.xml";
        private XmlSerializer serializer = new XmlSerializer(typeof(Funcionario));
        private FileStream? fileStream;

        public void SalvarArquivo(Funcionario funcionario)
        {
            fileStream = new FileStream(nomeArquivo, FileMode.Create);
            serializer.Serialize(fileStream, funcionario);
            Console.WriteLine("Gerado salario com sucesso para o funcionario: " + funcionario.Nome);
            fileStream.Close();
        }
    }

    //Classe abstrata
    public class AbstractionGeraArquivo
    {
        //--------------------------------------------
        /*
        Nota: usa injecao de dependencia
        Mais sobre:
        Injeção de dependencia: https://www.youtube.com/watch?v=evhskJG1kvY
        Injeção de dependencia: https://medium.com/@eduardolanfredi/injeção-de-dependência-ff0372a1672
        S.O.L.I.D: https://www.youtube.com/watch?v=mkx0CdWiPRA
        
        
         O construtor recebe um objeto IGeraArquivo
        que é injetado dentro de geraArquivo
         */
        protected IGeraArquivo geraArquivo;
        
        public AbstractionGeraArquivo(IGeraArquivo geraArquivo)
        {
            this.geraArquivo = geraArquivo;
        }
        //--------------------------------------------

        public void SalvarArquivo(Funcionario funcionario)
        {
            /*
             Recebe um objeto Funcionario
            e usando a variavel geraArquivo
            chama o metodo SalvarArquivo passando funcionario como parametro
             */
            geraArquivo.SalvarArquivo(funcionario);
        }
    }

    public class CalculaSalario : AbstractionGeraArquivo
    {
        /*
         Recebe uma instancia de IGeraArquivo em runtime
        e passa para a classe base 
        
        na classe base recebe a instancia e sobreescreve o metodo
        SalvarArquivo para gerar o arquivo com o formato especificado
         */
        public CalculaSalario(IGeraArquivo geraArquivo) : base(geraArquivo)
        {

        }

        /*
         Recebe um objeto Funcionario logo após calcula o salario total
        e usando a instancia que foi recebido de AbstractionGeraArquivo 
        ele gera o arquivo com o formato especificado
         */
        void ProcessaSalarios(Funcionario funcionario)
        {
            funcionario.SalarioTotal = funcionario.Salario + funcionario.Incentivo;

            Console.WriteLine("Salario total funcionario: " + funcionario.SalarioTotal);

            geraArquivo.SalvarArquivo(funcionario);
        }
    }
}

/*
O Bridge é um padrão de projeto estrutural que permite que você divida 
uma classe grande ou um conjunto de classes intimamente ligadas em duas 
hierarquias separadas—abstração e implementação—que podem ser desenvolvidas 
independentemente umas das outras.

Vantagens:

- Estimula um codigo fracamente acoplado

- Aumenta a capacidade de manutenção e reutilização do codigo
  e reduz a duplicação de codigo.

- Ajuda a promover o pricipio aberto fechado.

- Facilita a extensibilidade.

Desvantagens:

- Aumenta a complexidade do codigo pela criação de uma hierarquia de 
  classes complexas.


Exemplo de execução comentado*:

//Cria um objeto calcula salario do tipo CalculaSalario
//Passa como parametro uma instansia do tipo GeraJson que implementa a interface IGeraArquivo
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
*/




