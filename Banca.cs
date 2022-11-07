
// See https://aka.ms/new-console-template for more information

public class Banca
{
    public string Nome { get; set; }
    public List<Cliente> ListaClienti { get; set; }
    public List<Prestito> ListaPrestiti { get; set; }
    public Banca (string nome)
    {
        Nome = nome;
    }
}
