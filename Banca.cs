using System.Globalization;
using System.IO;

public class Banca
{
    public string Nome { get; private set; }
    List<Cliente> Clienti { get; set; }
    List<Prestito> Prestiti { get; set; }
    public Banca(string nome)
    {
        Nome = nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();
    }
    public Cliente CercaCliente(string codiceFiscale)
    {
        if (codiceFiscale == null || codiceFiscale == "")
            return null;
        foreach (Cliente cliente in Clienti)
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
        Clienti.Add(cliente);
        return true;
    }
    public bool ModificaCliente(Cliente clienteModificato, string codiceFiscale)
    {
        Cliente cliente = CercaCliente(codiceFiscale);
        if (cliente == null)
            return false;
        if (clienteModificato.Nome != "" && clienteModificato.Nome != null)
            cliente.Nome = clienteModificato.Nome;
        if (clienteModificato.Cognome != "" && clienteModificato.Cognome != null)
            cliente.Cognome = clienteModificato.Cognome;
        if (clienteModificato.CodiceFiscale != "" && clienteModificato.CodiceFiscale != null)
            cliente.CodiceFiscale = clienteModificato.CodiceFiscale;
        if (clienteModificato.Stipendio >= 0)
            cliente.Stipendio = clienteModificato.Stipendio;
        return true;
    }
    public bool NuovoPrestito(string codiceFiscale, int ammontare, DateOnly inizio, DateOnly fine)
    {
        Cliente cliente = CercaCliente(codiceFiscale);
        if (cliente == null)
            return false;
        DateTime inizioMod = inizio.ToDateTime(TimeOnly.Parse("10:00 PM"));
        DateTime fineMod = fine.ToDateTime(TimeOnly.Parse("10:00 PM"));
        int valoreRata = ammontare / (fineMod.Subtract(inizioMod).Days / 30);
        if (cliente.Stipendio / 2 < valoreRata)
            return false;
        Prestito prestito = new Prestito(Prestito.UltimoId, cliente, ammontare, valoreRata, inizio, fine);
        Prestiti.Add(prestito);
        return true;
    }
    public List<Prestito> RicercaPrestitiCliente(string codiceFiscale)
    {
        Cliente cliente = CercaCliente(codiceFiscale);
        if (cliente == null)
            return null;
        List<Prestito> prestitiCliente = new List<Prestito>();
        foreach (Prestito prestito in Prestiti)
        {
            if (prestito.Intestatario.CodiceFiscale == cliente.CodiceFiscale)
                prestitiCliente.Add(prestito);
        }
        return prestitiCliente;
    }
    public int AmmontareTotalePrestitiCliente(string codiceFiscale)
    {
        List<Prestito> prestitiCliente = RicercaPrestitiCliente(codiceFiscale);
        int ammontareTotale = 0;
        foreach (Prestito prestito in prestitiCliente)
        {
            ammontareTotale += prestito.Ammontare;
        }
        return ammontareTotale;
    }
    public List<Prestito> RateRimanentiPrestitiCliente(string codiceFiscale)
    {
        List<Prestito> prestitiAttivi = new List<Prestito>();
        List<Prestito> prestitiCliente = RicercaPrestitiCliente(codiceFiscale);
        foreach (Prestito prestito in prestitiCliente)
        {
            if (prestito.RateRimanenti() > 0)
                prestitiAttivi.Add(prestito);
        }
        return prestitiAttivi;
    }
}