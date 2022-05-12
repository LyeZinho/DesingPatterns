using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.Prototype
{
    public interface IAcordo
    {
        public IAcordo CopiaRaza();
        void PrintAcordo();
    }
    
    public class AcordoDoc
    {
        public string? ClausulaDev { get; set; }
        public string? ClausulaPosEntrega { get; set; }
        public string? RecisaoDoProjeto { get; set; }
    }

    public class ClausulaDeAcordo
    {
        public AcordoDoc GetClausulaDeAcordo()
        {
            AcordoDoc doc = new AcordoDoc();

            doc.ClausulaDev = "Atividades do desenvolvedor deve ser completa por Milestones";
            doc.ClausulaPosEntrega = "Deve ser dado 1 ano de suporte após entrega";
            doc.RecisaoDoProjeto = "O cliente pode rescindir o projeto a qualquer momento";

            return doc;
        }
    }

    public class AcordoDeSoftware : IAcordo
    {
        public string? NomeDoVendedor { get; set; }
        AcordoDoc doc = new AcordoDoc();

        //Chamada para "Construtor"
        public AcordoDeSoftware(string nomeDoVendedor)
        {
            NomeDoVendedor = nomeDoVendedor;

            ClausulaDeAcordo Adoc = new ClausulaDeAcordo();
            doc = Adoc.GetClausulaDeAcordo();
        }

        //Clonagem do objeto
        public IAcordo CopiaRaza()
        {
            return (IAcordo)this.MemberwiseClone();
        }
        
        //Print de said
        public void PrintAcordo()
        {
            Console.WriteLine("Acordo de software para o vendedor: {0}", NomeDoVendedor);
            Console.WriteLine("Clausula de Desenvolvimento: {0}", doc.ClausulaDev);
            Console.WriteLine("Clausula de entrega: {0}", doc.ClausulaPosEntrega);
            Console.WriteLine("Clausula de dev: {0}", doc.ClausulaDev);
        }
    }
}

/*

Prototype:

O prototype especifica todos os objetos que serão criados 
usando uma instancia prototipo e copiando a mesma

Porque usar o prototype?

- O prototype e usado quando a criacao de novos objetos pode ser 
  custoso em questão de operações e pode emitir um peso relevante
  em termos de consumo de memoria

AcordoDeSoftware acordo = new AcordoDeSoftware("Empresa Nome");
acordo.PrintAcordo();

Console.WriteLine("\n\n");
IAcordo clone = acordo.CopiaRaza();
clone.PrintAcordo(); 
*/
