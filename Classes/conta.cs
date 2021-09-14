using System;

namespace DIO.Bank
{
    public class Conta
    {

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        private string Nasc {get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, string nasc)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.Nasc = nasc;
        }

        public bool Sacar(double valorSaque)
        {
            //validacao de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito = -1)){
                Console.WriteLine("Saldo Insuficiente");
                return false;   
            }
        
        this.Saldo -= valorSaque;

        Console.WriteLine("Saldo altual da Conta de {0} é {1}", this.Nome, this.Saldo);

        return true;
        
        }

        public void Depositar(double valorDeposito){

            this.Saldo += valorDeposito; 
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta"  + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Credito + " | ";
            retorno += "Nascimento" + this.Nasc;
            return retorno;

            }

    }

}