using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Criacional.BuilderExemplo
{
    public class ContaBancariaBuilder
    {
        private string _nomecliente = "";
        private string _numconta = "";
        private double _saldo = 0;
        private string _agencia = "";
        private string _tipoconta = "";
        private int _nif = 0;
        private int _iban = 0;


        public ContaBancariaBuilder ContaComNumeroConta(string numconta)
        {
            this._numconta = numconta;
            return this;
        }

        public ContaBancariaBuilder ContaComCredenciais(string nomecliente, int nif)
        {
            this._nomecliente = nomecliente;
            this._nif = nif;
            return this;
        }

        public ContaBancariaBuilder ContaComSaldo(double saldo)
        {
            this._saldo = saldo;
            return this;
        }

        public ContaBancariaBuilder ContaComAgencia(string agencia)
        {
            this._agencia = agencia;
            return this;
        }

        public ContaBancariaBuilder ContaComTipoConta(string tipoconta)
        {
            this._tipoconta = tipoconta;
            return this;
        }

        public ContaBancariaBuilder ContaComIban(int iban)
        {
            this._iban = iban;
            return this;
        }

        private bool Validacao()
        {
            return !string.IsNullOrEmpty(this._numconta) && 
                !string.IsNullOrEmpty(this._nomecliente) && 
                !string.IsNullOrEmpty(this._tipoconta) 
                && this._nif > 0 && this._iban > 0;
        }
        
        public ContaBancariaBuilder Build()
        {
            return Validacao() ? this :
                throw new Exception("Conta não pode ser criada verifique os dados");
        }

        public void MostrarDados()
        {
            Console.WriteLine("Nome do cliente: " + this._nomecliente);
            Console.WriteLine("Número da conta: " + this._numconta);
            Console.WriteLine("Saldo: " + this._saldo);
            Console.WriteLine("Agencia: " + this._agencia);
            Console.WriteLine("Tipo de conta: " + this._tipoconta);
            Console.WriteLine("NIF: " + this._nif);
            Console.WriteLine("IBAN: " + this._iban);
        }
    }
}

/*
O builder tem como objetivo separar a criação de um objeto complexo
de sua representação fazendo com que o processo de construção possa 
criar diferentes representações

Pontos positivos:

 - Um builder pode criar diferentes representações de um mesmo objeto
   usando o mesmo codigo de criação

 - Um builder pode criar um objeto complexo com varios objetos simples
   usando uma abordagem passo a passo

 - Permite realizar encadeamento de metodos (Method Chaining)

Quando usar?

- Quando voçe possui multiplos construtores e deseja expandir a classe

- Para evitar construtores com multiplos parametros

ContaBancariaBuilder contaBuilder = new ContaBancariaBuilder().
    ContaComCredenciais("nome", 123).
    ContaComSaldo(100).
    ContaComIban(123).
    ContaComAgencia("123").
    ContaComNumeroConta("123").
    ContaComTipoConta("123").
    Build();

contaBuilder.MostrarDados();
 
*/