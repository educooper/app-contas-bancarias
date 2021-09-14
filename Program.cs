using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace DIO.Bank

{
	class Program
    {
		
		static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
		{
		string OpcaoUsuario = ObterOpcaoUsuario();
		
		while (OpcaoUsuario.ToUpper() != "X")
		{
		switch (OpcaoUsuario)
			{
		case "1":
		ListarContas();
		break;
		case "2":
		InserirConta();
		break;
		case "3":
		Transferir();
		break;
		case "4":
		Sacar();
		break;
		case "5":
		Depositar();
		break;
		case "C":
		Console.Clear();
		break;
		
		default:
		throw new ArgumentOutOfRangeException();
			}
	
		OpcaoUsuario = ObterOpcaoUsuario();
		}

Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

	}

private static void Sacar()
{
	Console.Write("Digite o numero da Conta:");
	int indiceConta = int.Parse(Console.ReadLine());
	
	Console.Write("Digite o valor a ser sacado:");
	double valorSaque = double.Parse(Console.ReadLine());

	listContas[indiceConta].Sacar(valorSaque);

}

private static void Depositar()
{
	Console.Write("Digite o numero da Conta:");
	int indiceConta = int.Parse(Console.ReadLine());
	
	Console.Write("Digite o valor a ser depositado:");
	double valorDeposito = double.Parse(Console.ReadLine());

	listContas[indiceConta].Sacar(valorDeposito);

}

private static void Transferir()
{
	Console.Write("Digite o numero da Conta Origem: ");
	int indiceContaOrigem = int.Parse(Console.ReadLine());

	Console.Write("Digite o numero da Conta Destino: ");
	int indiceContaDestino = int.Parse(Console.ReadLine());
	
	Console.Write("Digite o valor a ser Transferido: ");
	double valorTransferencia = double.Parse(Console.ReadLine());

	listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

}
private static void InserirConta()
{
	Console.WriteLine("inserir nova conta");
	
	Console.Write("Digite 1 para conta física ou 2 para conta jurídica: ");
	int entradaTipoConta = int.Parse(Console.ReadLine());
	
	Console.Write("Digite o nome do Cliente: ");
	string entradaNome = Console.ReadLine();	

	Console.Write("Digite a data de Nascimento (dia/mês/ano): ");
	string entradaNasc = Console.ReadLine();
	
        if(Convert.ToDateTime(entradaNasc).AddYears(18) > DateTime.Now)
		{
			Console.Clear();
			Console.WriteLine("Necessário ser maior de 18 anos!");
			Console.WriteLine("=======================================================================");
			return;			
		}

	Console.Write("Digite o Saldo Inicial: ");
	double entradaSaldo = double.Parse(Console.ReadLine());
	
	Console.Write("Digite o crédito: ");
	double entradaCredito = double.Parse(Console.ReadLine());
	
	Conta novaConta = new Conta(
				tipoConta: (TipoConta)entradaTipoConta, 
				saldo: entradaSaldo, 
				credito: entradaCredito, 
				nome: entradaNome,
				nasc:entradaNasc);
	
	listContas.Add(novaConta);

}
	private static void ListarContas()
	{
		Console.WriteLine("Listar Contas");

		if(listContas.Count ==0 )
		{
			Console.WriteLine("Nenhuma Conta Cadastrada.");
			return;
		}

		for(int i = 0;i < listContas.Count; i++)
		{
			Conta conta = listContas[i];
			Console.Write("#{0} - ", i);
			Console.WriteLine(conta);
		}

	} 

private static string ObterOpcaoUsuario()
{
	Console.WriteLine();
	Console.WriteLine("DIO bank ao seu dispor!");
	Console.WriteLine("Informe a opção Desejada:");
	Console.WriteLine("1- Listar Contas");
	Console.WriteLine("2- Inserir nova conta");
	Console.WriteLine("3- Transferir");
	Console.WriteLine("4- Sacar");
	Console.WriteLine("5- Depositar");
	Console.WriteLine("C- Limpar Tela");
	Console.WriteLine("X- Sair");

	string OpcaoUsuario = Console.ReadLine().ToUpper();
	Console.WriteLine();
	return OpcaoUsuario;
		}
	}

}