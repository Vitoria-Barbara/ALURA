﻿//casesensitive
//fortemente tipada
//Screen Sound

string mensagemDeBoasVindas = "\nBoas Vindas ao Screen Sound";
//List<string> ListaDasBandas = new List<string>  { "U2", "The Beatles", "Calypson" } ;   

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 7, 6 });
bandasRegistradas.Add("The Beatles", new List<int> ());


void ExibirLogo()
{
    //Verbatim Literal
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███╗░░██╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝████╗░██║████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░██╔██╗██║██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██║╚████║██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗██║░╚███║██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpçõesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida =  Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1 : RegistrarBandas();
            break; 
        case 2 : MostrarBandasRegistradas();
            break;
        case 3 : AvaliarUmaBanda();
            break;
        case 4 : ExibirMediaDaBanda();
            break;
        case -1 : Console.WriteLine("xau xau xau");
            break;
        default: Console.WriteLine("Opção invállida"); 
            break;
    }

}

void RegistrarBandas() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas:");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;//nao nulo

    //ListaDasBandas.Add(nomeDaBanda);
    bandasRegistradas.Add(nomeDaBanda, new List<int>());

    //interpolação de string 
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas Registradas:");

    /*for(int i = 0; i < ListaDasBandas.Count; i++ )
    {
        Console.WriteLine($"Banda: {ListaDasBandas[i]}");
    }*/

    //ForEach - para somente percorrer a lista sem usar o indice.
    foreach (string banda in bandasRegistradas.Keys)//key é o primeiro parametro
    {
        Console.WriteLine($"Banda: {banda}");
    }


    Console.WriteLine("\nDigite uma tecla para voltar ao menu:");
    Console.ReadKey(); //qualquer tecla 
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void ExibirTituloDaOpcao(string titulo) //recebe "titulo" como parametro
{
    int quantidadeDeLetras = titulo.Length;
    //loop com for ou add em uma string oc caracteres desejados.
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');//add na esquerda da string vazia um caractere.
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos+ "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    //se a banda existir no dicionario >> atribuir uma nota 
    //senão, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");//interpolação de string
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep( 2000 );
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digote uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
}

void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo a Média de Avaliações Da Banda: ");
    Console.Write("Digite o nome da banda que deseja saber a média de avaliações: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine();
        double media = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"A média de avaliações da banda {nomeDaBanda} é: {media}");
        Console.WriteLine("Digote uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digote uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
}

ExibirOpçõesDoMenu();