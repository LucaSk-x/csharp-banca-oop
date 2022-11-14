public class Prestito
{
    public int Id { get; set; }
    public Cliente Intestatario { get; set; }
    public int Ammontare { get; set; }
    public int ValoreRata { get; set; }
    public DateOnly Inizio { get; set; }
    public DateOnly Fine { get; set; }
    public static int UltimoId { get; set; }
    public Prestito(int id, Cliente intestatario, int ammontare, int valoreRata, DateOnly inizio, DateOnly fine)
    {
        Id = id;
        Intestatario = intestatario;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        Inizio = inizio;
        Fine = fine;
        UltimoId++;
    }
    public int RateRimanenti()
    {
        DateTime oggi = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("10:00 PM"));
        DateTime fine = Fine.ToDateTime(TimeOnly.Parse("10:00 PM"));
        int rateRimanenti = fine.Subtract(oggi).Days / 30;
        return rateRimanenti;
    }
    public void StampaPrestito()
    {
        Console.WriteLine("Prestito di {0}$ da {1}$ a rata", Ammontare, ValoreRata);
    }
}