using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.Singleton
{
    //Exemplo 1
    public class DbAccess
    {
        private static DbAccess? instance;
        private DbAccess() { }
        public static DbAccess GetInstance()
        {
            if (instance == null)
            {
                instance = new DbAccess();
            }
            return instance;
        }
        public List<dynamic> QueryDBdata()
        {
            List<dynamic> data = new List<dynamic>();
            data.Add(new { Name = "Pedro", Age = "18" });
            data.Add(new { Name = "Paulo", Age = "18" });
            data.Add(new { Name = "Vitor", Age = "20" });
            return data;
        }
    }

    //Exemplo 2
    public class Logger
    {
        private static Logger? instancia;
        private Logger() { }
        public static Logger GetLogger()
        {
            if(instancia == null)
            {
                return new Logger();
            }
            return instancia;
        }
        public void WriteLog(string logdata)
        {
            Console.WriteLine($"Log: {logdata} Horario: {DateTime.Now.ToString(format:"G")}");
        }
    }

    public class Encomendas
    {
        private readonly Logger logger;

        public Encomendas()
        {
            logger = Logger.GetLogger();
        }
        
        public void NovaEncomenda(string nomecliente)
        {
            logger.WriteLog($"Nova encomenda criada cliente: {nomecliente}");            
        }
    }

    /*
    Teste as definições acima:
    
    Encomendas encomendas = new Encomendas();
    encomendas.NovaEncomenda("Pedro kaleb");
    */
}

/*
O singleton e usado quando queremos que uma classe tenha apenas uma instancia.
então ele impede que uma classe tenha mais de uma instancia.

Quando isso pode ser util?

- Quando deseja criar classes que so pode ter uma instancia por questões de seguranca
  ex: Classes de acesso a base de dados.

- Quando deseja criar classes que é acessado em varias partes do programa e não gerencia
  nenhum estada do programa ex: Classes de log.


Isso realmente funciona?
Bem faça seu teste então.

-------------------------------------------------------------------------------------------
DbAccess dbAccess1 = DbAccess.GetInstance();
DbAccess dbAccess2 = DbAccess.GetInstance();

if (dbAccess1 == dbAccess2)
{
   Console.WriteLine("Singleton funcionou as duas variaveis contem instancias iguais.");
}
else
{
   Console.WriteLine("Singleton não funcionou as duas variaveis contem instancias diferentes.");
}
foreach (var item in dbAccess1.QueryDBdata())
{
   Console.WriteLine(item.Name);
   Console.WriteLine(item.Age);
}
-------------------------------------------------------------------------------------------
*/