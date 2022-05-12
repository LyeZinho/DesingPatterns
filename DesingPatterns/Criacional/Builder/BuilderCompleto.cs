using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.BuilderCompleto
{
    //Classe base
    public class ContaBancaria
    {
        public string _nome { get; set; }
        public int _numeroConta { get; set; }
        public string _agencia { get; set; }
        public double _saldo { get; set; }
        public string _tipo { get; set; }
        public int _iban { get; set; }
        public double _taxamanutencao { get; set; }

        public ContaBancaria()
        {
            _nome = "";
            _numeroConta = 0;
            _agencia = "";
            _saldo = 0;
            _tipo = "";
            _iban = 0;
            _taxamanutencao = 0;
        }
        
    }

    //Interface
    public interface IContaBancariaBuilder
    {
        void SetCredenciais(string nome, int numeroConta);
        void SetSaldo(double saldo);
        void SetInfo(string tipo, string agencia);
        void SetIban(int iban);
        void SetTaxaManutencao(double taxa);
        ContaBancaria GetConta();
    }
    
    //Builders
    public class ContaBancariaBuilder : IContaBancariaBuilder
    {
        private ContaBancaria _contaBancaria = new ContaBancaria();

        public void SetCredenciais(string nome, int numeroConta)
        {
            _contaBancaria._nome = nome;
            _contaBancaria._numeroConta = numeroConta;
        }


        public void SetInfo(string tipo, string agencia)
        {
            _contaBancaria._tipo = tipo;
            _contaBancaria._agencia = agencia;
        }

        public void SetSaldo(double saldo)
        {
            _contaBancaria._saldo = saldo;
        }

        public void SetIban(int iban)
        {
            _contaBancaria._iban = iban;
        }

        public void SetTaxaManutencao(double taxa)
        {
            _contaBancaria._taxamanutencao = taxa;
        }

        public ContaBancaria GetConta()
        {
            return _contaBancaria;
        }
        
    }
    public class ContaPoupancaBuilder : IContaBancariaBuilder
    {
        private ContaBancaria _contaBancaria = new ContaBancaria();

        public void SetCredenciais(string nome, int numeroConta)
        {
            _contaBancaria._nome = nome;
            _contaBancaria._numeroConta = numeroConta;
        }


        public void SetInfo(string tipo, string agencia)
        {
            _contaBancaria._tipo = tipo;
            _contaBancaria._agencia = agencia;
        }

        public void SetSaldo(double saldo)
        {
            _contaBancaria._saldo = saldo;
        }

        public void SetIban(int iban)
        {
            _contaBancaria._iban = iban;
        }
        
        public void SetTaxaManutencao(double taxa)
        {
            return;
        }

        public ContaBancaria GetConta()
        {
            return _contaBancaria;
        }
    }
    public class BuildeConfig
    {
        /*
        Base de configuração para definição de um padrão de construção de objetos.
        Nota: como este padrão e baseado nos dados inseridos
        pode se criar diferentes representações de um mesmo objeto
        usando um mesmo codigo.
        */
        public ContaBancaria ContaCorrente(IContaBancariaBuilder builder)
        {
            builder.SetCredenciais("nome", 123456789);
            builder.SetTaxaManutencao(2.2);
            builder.SetInfo("corrente", "ag122");
            builder.SetIban(123123);
            builder.SetSaldo(900);

            return builder.GetConta();
        }

        public ContaBancaria ContaPoupanca(IContaBancariaBuilder builder)
        {
            builder.SetCredenciais("nome", 123456789);
            builder.SetInfo("corrente", "ag122");
            builder.SetIban(123123);
            builder.SetSaldo(900);

            return builder.GetConta();
        }
    }

    /*
        IContaBancariaBuilder builder = new ContaBancariaBuilder();
        BuildeConfig contaconfig = new BuildeConfig();

        dynamic conta = contaconfig.ContaCorrente(builder);

        Console.WriteLine($"Conta: {conta._numeroConta}");
        Console.WriteLine($"Saldo: {conta._saldo}"); 
    */
}
