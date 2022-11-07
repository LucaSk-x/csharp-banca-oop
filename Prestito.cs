
// See https://aka.ms/new-console-template for more information


public class Prestito
{
    public int Id { get; set; }
    public int Ammontare { get; set; }
    public int ValoreRata { get; set; }
    public DateOnly Inizio { get; set; }
    public DateOnly Fine { get; set; }
    public Cliente Intestatario { get; set; }

    public Prestito (int id, int ammontare, int valoreRata, DateOnly inizio, DateOnly fine, Cliente interstatario)
    {
        Id = id;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        Inizio = inizio;
        Fine = fine;
        Intestatario = interstatario;
    }
}
