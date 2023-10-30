using System;
using System.IO;
class Program
{
    struct Nascimento
    {
        public int ano;
        public int mes;
    }
    struct BaseDeDados
    {
        public int codigo;
        public int leite;
        public int alim;
        public Nascimento nasc;
        public char abate;
    }

    static void LerBaseDeDados(List<BaseDeDados> Dados)
    {
        BaseDeDados baseDeDados = new BaseDeDados();

        Console.WriteLine("Informe o código da cabeça do gado: ");
        baseDeDados.codigo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe número de litros de leite produzido por semana: ");
        baseDeDados.leite = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe quantidade de alimento ingerida por semana (em quilos):");
        baseDeDados.alim = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe data de nascimento (mês e ano) respectivamente: ");
        baseDeDados.nasc.mes = Convert.ToInt32(Console.ReadLine());
        baseDeDados.nasc.ano = Convert.ToInt32(Console.ReadLine());

        if((baseDeDados.nasc.ano > 5) || (baseDeDados.leite < 40))
        {
            Console.WriteLine("Informe o abate com N(não) ou S (sim): ");
            baseDeDados.abate = Convert.ToChar(Console.ReadLine());
        }
    }

    static void Menu()
    {
        Console.WriteLine("1-Retornar a quantidade total de leite produzida por semana na fazenda.");
        Console.WriteLine("2-Retornar a quantidade total de alimento consumido por semana na fazenda.");
        Console.WriteLine("3-Listar os animais que devem ir para o abate.");
        Console.WriteLine("4-Salvar dados em arquivo e carregar dados.");
        Console.WriteLine("0-Sair.");
        int op = 
    }
}