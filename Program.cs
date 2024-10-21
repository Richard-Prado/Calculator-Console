INICIO:
Console.Clear();

Console.Title = "Calculadora Console";

Console.WriteLine("Qual o primeiro número?"); // Pergunta qual o primeiro número da conta
var inputUm = Console.ReadLine(); // Lê a entrada do usuário
var numeroConvertido = Conv(inputUm); // Chama o método de conversão

Console.WriteLine("Qual o segundo número?"); // Pergunta o segundo número da conta
var inputDois = Console.ReadLine(); // Lê a entrada do usuário
var numeroDoisConvertido = Conv(inputDois); // Chama o método de conversão

var operation = Ope(); // Seleciona a operação

switch (operation)
{
    case 0: // Adição
        Console.WriteLine(numeroConvertido + numeroDoisConvertido);
        break;
    case 1: // Subtração
        Console.WriteLine(numeroConvertido - numeroDoisConvertido);
        break;
    case 2: // Multiplicação
        Console.WriteLine(numeroConvertido * numeroDoisConvertido);
        break;
    case 3: // Divisão
        if (numeroDoisConvertido != 0) // Verifica se não está dividindo por zero
        {
            Console.WriteLine(numeroConvertido / numeroDoisConvertido);
        }
        else
        {
            Console.WriteLine("Erro: Divisão por zero não é permitida!");
        }
        break;
}
Console.WriteLine("\n\nPara continuar pressione qualquer tecla!");
Console.ReadLine();
Console.WriteLine("Gostaria de fazer um novo cálculo? (Sim ou Não)");
var res = YesOrNo(); // Pergunta se deseja continuar

if (res)
{
    Console.WriteLine("REINICIANDO PROGRAMA");
    Thread.Sleep(1000);
    goto INICIO;
}

Console.WriteLine("ENCERRANDO PROGRAMA");
Thread.Sleep(1000);

#region Método de conversão
int Conv(string? input)
{
    if (int.TryParse(input, out var i)) // Tenta converter para int
    { 
        return i;
    }
    Console.WriteLine("Entrada inválida. Não é um número!");
    return 0;
}
#endregion

#region Selecionando a operação desejada
int Ope()
{
    string[] options = ["Adição", "Subtração", "Multiplicação", "Divisão"]; // Corrigido para usar chaves
    var selectedIndex = 0;
    ConsoleKey keyPressed;

    do
    {
        Console.Clear();
        Console.WriteLine("Qual a operação desejada? (Use as SETAS para navegar e ENTER para selecionar a opção desejada)");

        // Exibe as opções
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Destaca a opção selecionada
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }

        // Captura a tecla pressionada
        keyPressed = Console.ReadKey(true).Key;

        // Atualiza o índice selecionado
        selectedIndex = keyPressed switch
        {
            ConsoleKey.UpArrow => (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1,
            ConsoleKey.DownArrow => (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1,
            _ => selectedIndex
        };
    } while (keyPressed != ConsoleKey.Enter);

    // Exibe a opção selecionada
    Console.Clear();
    Console.WriteLine($"Você selecionou: {options[selectedIndex]}");
    
    return selectedIndex;
}
#endregion

#region Escolhendo entre Sim ou Não
bool YesOrNo()
{
    string[] options = ["Sim", "Não"]; // Corrigido para usar chaves
    var selectedIndex = 0;
    ConsoleKey keyPressed;

    do
    {
        Console.Clear();
        Console.WriteLine("Gostaria de fazer um novo cálculo? (Use as SETAS para navegar e ENTER para selecionar a opção desejada)");

        // Exibe as opções
        for (var i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Destaca a opção selecionada
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }

        // Captura a tecla pressionada
        keyPressed = Console.ReadKey(true).Key;

        // Atualiza o índice selecionado
        selectedIndex = keyPressed switch
        {
            ConsoleKey.UpArrow => (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1,
            ConsoleKey.DownArrow => (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1,
            _ => selectedIndex
        };
    } while (keyPressed != ConsoleKey.Enter);

    // Exibe a opção selecionada
    Console.Clear();
    Console.WriteLine($"Você selecionou: {options[selectedIndex]}");

    return selectedIndex == 0; // Retorna true se "Sim" for selecionado
}
#endregion