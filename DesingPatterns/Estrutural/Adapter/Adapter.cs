using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Estrutural.Adapter
{
    /*
    Pequena explicação:
    como e perceptivel o codigo abaixo e incompativel
    por isso foi aplicado o padrao de projeto Adapter
    o sistema da escola usa como metodo de armazenar
    os dados do aluno um array de string porem o metodo que
    faz o calculo de notas só aceita uma Lista do tipo Aluno (List<Aluno>)
    
    Então um intermediario foi colocado entre a comunicação que é o 
    AlunosAdapter : ITarget 
    ele faz a conversão do array de string para a lista de alunos
    abaixo tem mais explicações
    */
    public class AlunosEsola
    {
        //Lista com os alunos
        public string[,] listaAlunos = new string[3, 4]{
            {"João", "Matemática", "300,2", "20"},
            {"Maria", "Português", "100,0", "10"},
            {"Pedro", "Física", "200,0", "30"}
        };
    }
    
    public class Aluno
    {
        //Classe alunos
        public string Nome { get; set; }
        public string Curso { get; set; }
        public double Mensalidade { get; set; }
        public double Nota { get; set; }

        public Aluno(string nome, string curso, double mensalidade, double nota)
        {
            Nome = nome;
            Curso = curso;
            Mensalidade = mensalidade;
            Nota = nota;
        }
    }

    public interface ITarget
    {
        /*
        Interface para o adapter
        ! nota lembre-se deve sempre programar para uma interface
        e não para as suas implementações
        */
        void ProcessarMensalidade(string[,] alunosArray);
    }

    public class SistemaMensalidade
    {
        /*
        Classe que vai fazer o calculo da mensalidade de cada aluno
        porem ele recebe como parametro uma lista de alunos (List<Aluno> alunos)
        então o adapter faz intermedio entre as duas
        */
        public void CalculaMensalidade(List<Aluno> alunos)
        {
            foreach (var data in alunos)
            {
                Console.WriteLine("Mensalidade do aluno {0} é {1}", data.Nome, data.Mensalidade);
            }
        }
    }

    //Classe que vai adaptar o array de string para a lista de alunos
    public class AlunosAdapter : ITarget
    {
        //Criado uma instancia para realizar o calculo das mensalidades
        SistemaMensalidade sistemaMensalidade = new SistemaMensalidade();

        //Adaptador
        public void ProcessarMensalidade(string[,] alunosArray)
        {
            List<Aluno> alunos = new List<Aluno>();

            string nome = "";
            string curso = "";
            double mensalidade = 0;
            double nota = 0;
            
            for (int i = 0; i < alunosArray.GetLength(0); i++)
            {
                nome = alunosArray[i, 0];
                curso = alunosArray[i, 1];
                mensalidade = Convert.ToDouble(alunosArray[i, 2]);
                nota = Convert.ToDouble(alunosArray[i, 3]);

                alunos.Add(new Aluno(nome, curso, mensalidade, nota));
            }

            sistemaMensalidade.CalculaMensalidade(alunos);
        }
    }

    /*
    Teste:
    
    ITarget adapter = new AlunosAdapter();
    AlunosEsola alunos = new AlunosEsola();
    adapter.ProcessarMensalidade(alunos.listaAlunos);
    */
}

/*
Adapter:

O adapter é um padrão que faz conexão entre duas interfaces diferentes/distintas.
o adapter pode ser usado e nessessario fazer conexão entre duas classes que 
não são compatíveis seja conectar-se com um sistema legado ou com uma interface 
que aceita apenas um certo padrão de dados então o adapter é uma solução que 
faz intermedio entre as duas interfaces/classes.

Objetivos:

- Conectar interface de uma classe com outra.

- Envolver(wrap) uma classe existente com uma nova inerface.

- Inserir um componente legado em um novo sistema permitindo
que sistemas incompatives se comuniquem.

Vantagens:
    
- Aumenta a reutilizaão de codigo.

- Permite usar um codigo entre plataformas diferentes/destintas.

- Permite interação de dois ou mais objetos incompativeis.

Desvantagens:

- A complexidade geral do codigo aumenta porque está inserindo
um novo conjunto de interfaces e classes.

*/
