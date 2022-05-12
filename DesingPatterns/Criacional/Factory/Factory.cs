using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.Factory
{
    public enum CarroModelo
    {
        ModelX = 1,
        ModelY = 2,
        Panamera = 3,
        Cayenne = 4,
    }

    //Interface de carro
    public interface ICarroF
    {
        void GetCarro();
    }
    //Tesla classes concreta
    public class TeslaModelX : ICarroF
    {
        public void GetCarro()
        {
            Console.WriteLine("Model X");
        }
    }
    public class TeslaModelY : ICarroF
    {
        public void GetCarro()
        {
            Console.WriteLine("Model Y");
        }
    }

    //Porsche classes concretas
    public class PorschePanamera : ICarroF
    {
        public void GetCarro()
        {
            Console.WriteLine("Panamera");
        }
    }
    public class PorscheCayenne : ICarroF
    {
        public void GetCarro()
        {
            Console.WriteLine("Cayenne");
        }
    }
    //Factory para criar factory de carro
    public interface ICarrofFactory
    {
        ICarroF GetCarro(CarroModelo modelo);
    }
    /*
    Factory´s designadas para cada marca em que o objetivo e retornar 
    outros objetos dentro delas mesmas 
    ou seja:
        carro:geral
            ↳ marca:Tesla
                  ↳ modelo:X ou Y 
    */
    class PorsheFactory : ICarrofFactory
    {
        public ICarroF GetCarro(CarroModelo modelo)
        {
            switch (modelo)
            {
                case CarroModelo.Panamera:
                    return new PorschePanamera();
                case CarroModelo.Cayenne:
                    return new PorscheCayenne();
                default:
                    throw new Exception("Modelo invalido");
            }
        }
    }

    class TeslaFactory : ICarrofFactory
    {
        public ICarroF GetCarro(CarroModelo modelo)
        {
            switch (modelo)
            {
                case CarroModelo.ModelY:
                    return new TeslaModelY();
                case CarroModelo.ModelX:
                    return new TeslaModelX();
                default:
                    throw new Exception("Modelo invalido");
            }
        }
    }

    /*
    Factory assim como todos os patterns criacionais ele tem como objetivo
    criar objetos sem ter um grande excesso de  Instaciamentos 

    Pontos positivos
    - Tem um maior controle sobre as classes podendo retornar tanto um tipo quanto uma subclasse
    - Evita forte acoplamente entre classes
    - Facilita a manutenção do codigo
    - Esconde a logica de instanciamento dos objetos

    Instanciando objetos usando um simple factory
    ICarrofFactory CarroFactory = new PorsheFactory();
    ICarroF carro = CarroFactory.GetCarro(CarroModelo.Cayenne);
    carro.GetCarro();
    */
}
