
// See https://aka.ms/new-console-template for more information

public class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    public Cliente (string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
    }

    public void AggiugiCliente (string Input)
    {
        switch (Input)
        {
            case "aggiungere":

                Console.WriteLine("digita il tuo nome");
                string nomeInput = Console.ReadLine();

                Console.WriteLine("digita il tuo cognome");
                string cognomeInput = Console.ReadLine();

                Console.WriteLine("digita il tuo codice fiscale");
                string codiceFiscInput = Console.ReadLine();

                Console.WriteLine("inserisci il tuo stipendio");
                string stipendioInput = Console.ReadLine();

                return;
            default:
                break;
        }

    }
}
