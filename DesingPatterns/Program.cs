using DesingPatterns;
using System;
using DesingPatterns.SimpleFactory;

static class Program
{
    static void Main()
    {
        IPizza pizza = PizzaFactory.CriarPizza(TipoPizza.marguerita);
        pizza.PrepararPizza();
    }
}