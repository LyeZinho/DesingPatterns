using DesingPatterns;
using System;
using DesingPatterns.Criacional.Prototype;
static class Program
{
    static void Main()
    {
        AcordoDeSoftware acordo = new AcordoDeSoftware("Empresa Nome");
        acordo.PrintAcordo();

        Console.WriteLine("\n\n");
        IAcordo clone = acordo.CopiaRaza();
        clone.PrintAcordo();
    }
}