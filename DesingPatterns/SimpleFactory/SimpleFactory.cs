using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.SimpleFactory
{
    public enum TipoPizza
    {
        calabreza = 1,
        marguerita  = 2
    }

    public interface IPizza
    {
        void PrepararPizza();
    }

    public class Calabreza : IPizza
    {
        public void PrepararPizza()
        {
            Console.WriteLine("Calabreza preparada...");   
        }
    }

    public class Marguerita : IPizza
    {
        public void PrepararPizza()
        {
            Console.WriteLine("Marguerita preparada...");
        }
    }

    public class PizzaFactory
    {
        public static IPizza CriarPizza(TipoPizza tipo)
        {
            switch (tipo)
            {
                case TipoPizza.calabreza:
                    return new Calabreza();
                case TipoPizza.marguerita:
                    return new Marguerita();
                default:
                    throw new Exception("Tipo invalido!");
            }
        }
    }
}
