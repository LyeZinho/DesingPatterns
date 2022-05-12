using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.AbstractFactory
{
    public enum ModeloCarro
    {
        ModelX = 1,
        ModelY = 2,
        Panamera = 3,
        Cayenne = 4

    }
    public interface IVelocidadeAF
    {
        void GetVelocidade();
    }
    public interface ICarroAF
    {
        void GetMarca();
    }


    //Classes concretas
    public class TeslaModelX : ICarroAF
    {
        public void GetMarca()
        {
            Console.WriteLine("Modelo: Tesla Model X");
        }
    }
    public class TeslaModelY : ICarroAF
    {
        public void GetMarca()
        {
            Console.WriteLine("Modelo: Tesla Model Y");
        }
    }
    //PORSHE
    public class PorshePanamera : ICarroAF
    {
        void ICarroAF.GetMarca()
        {
            Console.WriteLine("Modelo: Porsche Panamera");
        }
    }
    public class PorsheCayenne : ICarroAF
    {
        void ICarroAF.GetMarca()
        {
            Console.WriteLine("Modelo: Porsche Cayenne");
        }
    }
    //Tesla
    public class TeslaModelXVelocidade : IVelocidadeAF
    {
        void IVelocidadeAF.GetVelocidade()
        {
            Console.WriteLine("Velocidade: 120km/h");
        }
    }
    public class TeslaModelYVelocidade : IVelocidadeAF
    {
        void IVelocidadeAF.GetVelocidade()
        {
            Console.WriteLine("Velocidade: 130km/h");
        }
    }
    //PORSHE
    public class PorshePanameraVelocidade : IVelocidadeAF
    {
        void IVelocidadeAF.GetVelocidade()
        {
            Console.WriteLine("Velocidade: 200km/h");
        }
    }
    public class PorsheCayenneVelocidade : IVelocidadeAF
    {
        void IVelocidadeAF.GetVelocidade()
        {
            Console.WriteLine("Velocidade: 300km/h");
        }
    }

    //Interface abstrata
    public interface ICarroFactory
    {
        ICarroAF GetCarro(ModeloCarro modelo);
        IVelocidadeAF GetVelocidade(ModeloCarro modelo);
    }

    
    public class TeslaFactory : ICarroFactory
    {
        public ICarroAF GetCarro(ModeloCarro modelo)
        {
            switch (modelo)
            {
                case ModeloCarro.ModelX:
                    return new TeslaModelX();
                case ModeloCarro.ModelY:
                    return new TeslaModelY();
                default:
                    throw new Exception("Modelo não encontrado");
            }
        }

        public IVelocidadeAF GetVelocidade(ModeloCarro modelo)
        {
            switch (modelo)
            {
                case ModeloCarro.ModelX:
                    return new TeslaModelXVelocidade();
                case ModeloCarro.ModelY:
                    return new TeslaModelYVelocidade();
                default:
                    throw new Exception("Modelo não encontrado");
            }
        }
    }
    public class PorsheFactory : ICarroFactory
    {
        public ICarroAF GetCarro(ModeloCarro modelo)
        {
            switch (modelo)
            {
                case ModeloCarro.Panamera:
                    return new PorshePanamera();
                case ModeloCarro.Cayenne:
                    return new PorsheCayenne();
                default:
                    throw new Exception("Modelo não encontrado");
            }
        }

        public IVelocidadeAF GetVelocidade(ModeloCarro modelo)
        {
            switch (modelo)
            {
                case ModeloCarro.Panamera:
                    return new PorshePanameraVelocidade();
                case ModeloCarro.Cayenne:
                    return new PorsheCayenneVelocidade();
                default:
                    throw new Exception("Modelo não encontrado");
            }
        }
    }


    /*
    Factory´s Abstratas 
    a classe abstrata mostra um pattern em que os objetos estão 
    bem mais relacionados entre si criando uma familia de objetos 
    que estão relacionados entre si sem a nessesidade de especificar 
    as suas classes concretas.

    
    estrutura:
    
    ICarroFactory
                ↳ PorsheFactory
                            ↳ PorschePanamera
    
    ICarroFactory
                ↳ TeslaFactory
                            ↳ TeslaModelX
    
    ICarroFactory carro = new PorsheFactory();
    carro.GetCarro(ModeloCarro.Panamera).GetMarca();
    carro.GetVelocidade(ModeloCarro.Cayenne).GetVelocidade();
    */
}



