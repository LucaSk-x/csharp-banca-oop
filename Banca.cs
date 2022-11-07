
// See https://aka.ms/new-console-template for more information

public class Banca
{
    public string Nome { get; set; }
    List<Cliente> ListaClienti { get; set; }
    List<Prestito> ListaPrestiti { get; set; }
    public Banca (string nome)
    {
        Nome = nome;
        ListaClienti = new List<Cliente> ();
        ListaPrestiti = new List<Prestito> ();

    }

    public Cliente CercaCliente(string codiceFiscale)
    {
        foreach (Cliente cliente in ListaClienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }
        return null;
    }


    public bool NuovoCliente(Cliente cliente)
    {
        if (
            cliente.Nome == null || cliente.Nome == "" ||
            cliente.Cognome == null || cliente.Cognome == "" ||
            cliente.CodiceFiscale == null || cliente.CodiceFiscale == "" ||
            cliente.Stipendio < 0
           )
            return false;
        Cliente clienteEsistente = CercaCliente(cliente.CodiceFiscale);
        if (clienteEsistente != null)
            return false;
        ListaClienti.Add(cliente);
        return true;
    }

    public bool ModificaCliente(Cliente clienteModificato)
    {
        Cliente cliente = CercaCliente(clienteModificato.CodiceFiscale);
        if (cliente == null)
            return false;
        if (clienteModificato.Nome != "")
            cliente.Nome = clienteModificato.Nome;
        if (clienteModificato.Cognome != "")
            cliente.Cognome = clienteModificato.Cognome;
        if (clienteModificato.Stipendio > 0)
            cliente.Stipendio = clienteModificato.Stipendio;
        return true;
    }

    public bool NuovoPrestito(string codiceFiscale, int ammontare, DateOnly inizio, DateOnly fine)
    {
        Cliente cliente = CercaCliente(codiceFiscale);
        if (cliente == null)
            return false;
        DateTime inizioMod = inizio.ToDateTime(TimeOnly.Parse("10:00"));
        DateTime fineMod = fine.ToDateTime(TimeOnly.Parse("10:00"));
        if (cliente.Stipendio / 2 < ammontare / (fineMod.Subtract(inizioMod).Days / 30))
            return false;
        Prestito prestito = new Prestito(1, ammontare, ammontare / 24, inizio, fine, cliente);
        ListaPrestiti.Add(prestito);
        return true;
    }

    public List<Prestito> ricercaPrestitiCliente(string codiceFiscale)
    {
        Cliente cliente = CercaCliente(codiceFiscale);
        if (cliente != null)
            return null;
        List<Prestito> prestitiCliente = new List<Prestito>();
        foreach (Prestito prestito in ListaPrestiti)
        {
            if (prestito.Intestatario.CodiceFiscale == cliente.CodiceFiscale)
                prestitiCliente.Add(prestito);
        }
        return prestitiCliente;
    }
}
