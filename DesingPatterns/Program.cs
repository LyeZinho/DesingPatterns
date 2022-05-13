using DesingPatterns;
using System;
//using DesingPatterns.Criacional.Singleton;
using DesingPatterns.Estrutural.Adapter;
static class Program
{
    static void Main()
    {
        ITarget adapter = new AlunosAdapter();

        AlunosEsola alunos = new AlunosEsola();

        adapter.ProcessarMensalidade(alunos.listaAlunos);
    }
}