using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.SimpleFactory
{
    public enum TipoPizza
    {
        calabreza = 1,
        marguerita  = 2
    }

    //Interface para Pizza
    public interface IPizzaSf
    {
        void PrepararPizza();
    }

    //Classes derivadas de pizza
    public class Calabreza : IPizzaSf
    {
        public void PrepararPizza()
        {
            Console.WriteLine("Calabreza preparada...");   
        }
    }

    public class Marguerita : IPizzaSf
    {
        public void PrepararPizza()
        {
            Console.WriteLine("Marguerita preparada...");
        }
    }

    //Factory para o objeto pizza
    public class PizzaFactory
    {
        public static IPizzaSf CriarPizza(TipoPizza tipo)
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

    /*
    Agora todos os lugares que forem nessessario criar uma nova pizza
    não e nesessario criar uma tonelada de operadores new e expor a logica
    de criação para a interface isso tamber reduz o acoplamento das classes e 
    metodos o que deixa o codigo mais expansivel e limpo 

    Pontos positivos
    - Reduz o acoplamento de codigo
    - Facilita na hora de fazer a refatoração
    - Facilita testes unitarios
    - Reduz o acoplamento do codigo
    > Esconde a logica de instanciamento de objetos <

    Como instanciar um objeto usando uma factory
    IPizzaSf pizza = PizzaFactory.CriarPizza(TipoPizza.marguerita);
    pizza.PrepararPizza(); 
    */


}
