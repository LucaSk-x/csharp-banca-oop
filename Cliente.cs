public class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }
    public static int NumeroClienti { get; set; }
    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
        NumeroClienti++;
    }
    public void StampaCliente()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Cognome: " + Cognome);
        Console.WriteLine("Codice Fiscale: " + CodiceFiscale);
        Console.WriteLine("Stipendio: " + Stipendio + "€");
    }
}