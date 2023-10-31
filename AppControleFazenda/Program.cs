using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

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

        baseDeDados.codigo = Dados.Count() + 1;

        Console.WriteLine("Informe número de litros de leite produzido por semana: ");
        baseDeDados.leite = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe quantidade de alimento ingerida por semana (em quilos):");
        baseDeDados.alim = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe data de nascimento (mês e ano): \nMês: ");
        baseDeDados.nasc.mes = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ano: ");
        baseDeDados.nasc.ano = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        if((baseDeDados.nasc.ano > 5) || (baseDeDados.leite < 40))
        {
 
            baseDeDados.abate = 'S';
        }
        else
        {
            baseDeDados.abate = 'N';
        }
    }
    static void QtdLeiteSemana(List<BaseDeDados> lista)
    {
        int soma = 0;
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            soma += lista[i].leite;
        }
        Console.WriteLine("a quantidade total de leite produzida por semana é de: " + soma);
    }
    static void QtdAlimSemana(List<BaseDeDados> lista)
    {
        int soma = 0;
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)
        {
            soma += lista[i].alim;
        }
        Console.WriteLine("a quantidade total de Alimento consumido por semana é de: " + soma);
    }

    static void ListaAbate(List<BaseDeDados> lista)
    {
        int qtd = lista.Count();
        Console.WriteLine("****Gados para o Abate***");
        for (int i = 0; i < qtd; i++) {
            if (lista[i].abate == 'S')
            {
                Console.WriteLine("Código: " + lista[i].codigo);
                Console.WriteLine("Leite: " + lista[i].leite);
                Console.WriteLine("Alimento: " + lista[i].alim);
                Console.WriteLine($"Data de Nascimento (Mês/Ano):{lista[i].nasc.mes}/{lista[i].nasc.ano}");
                Console.WriteLine("**************************");

            }
        }
        Console.Clear();
    }
    static void salvarDados(List<BaseDeDados> lista, string nomeArquivo)
    {

        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (BaseDeDados dados in lista)
            {
                writer.WriteLine($"{dados.codigo},{dados.leite},{dados.alim},{dados.abate},{dados.nasc.ano},{dados.nasc.mes}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");

    }
    static void carregarDados(List<BaseDeDados> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                BaseDeDados dados = new BaseDeDados
                {
                    codigo = int.Parse(campos[0]),
                    leite = int.Parse(campos[1]),
                    alim = int.Parse(campos[2]),
                    nasc = 
                    new Nascimento
                    {
                        mes = int.Parse(campos[3]),
                        ano = int.Parse(campos[4]),
                    }
                };
                lista.Add(dados);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int Menu()
    {
        Console.WriteLine("1-Cadastrar dados.");
        Console.WriteLine("2-Retornar a quantidade total de leite produzida por semana na fazenda.");
        Console.WriteLine("3-Retornar a quantidade total de alimento consumido por semana na fazenda.");
        Console.WriteLine("4-Listar os animais que devem ir para o abate.");
        Console.WriteLine("5-Salvar dados em arquivo e carregar dados.");
        Console.WriteLine("0-Sair.");
        Console.Write("Entre com uma opção: ");
        int op = Convert.ToInt32(Console.ReadLine());
        return op;
    }
    static void Main()
    {
        List<BaseDeDados> basedados = new List<BaseDeDados>();
        int op;
        carregarDados(basedados, "dadosFazenda.txt");
        do
        {
            op = Menu();
            switch (op)
            {
                case 1:
                    LerBaseDeDados(basedados); 
                    break;
                case 2:
                    QtdLeiteSemana(basedados);
                    break;
                case 3:
                    QtdAlimSemana(basedados);
                    break;
                case 4:
                    ListaAbate(basedados);
                    break;
                case 5:
                    Console.WriteLine("Salvando e Carregando dados...");
                    salvarDados(basedados, "dadosFazenda.txt");
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
            }
        }
        while (op != 0);
    }
}
   