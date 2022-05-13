using DesingPatterns;
using System;
using DesingPatterns.Criacional.Singleton;
static class Program
{
    static void Main()
    {
        Encomendas encomendas = new Encomendas();

        encomendas.NovaEncomenda("Pedro kaleb");
    }
}