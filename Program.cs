Banca banca = new Banca("N26");
bool exit = false;
do
{
    Console.WriteLine("Banca {0} con {1} clienti", banca.Nome, Cliente.NumeroClienti);
    Console.WriteLine("1) Crea nuovo utente");
    Console.WriteLine("2) Cerca cliente");
    Console.WriteLine("3) Modifica cliente");
    Console.WriteLine("4) Nuovo prestito");
    Console.WriteLine("5) Ricerca Prestiti di un cliente");
    Console.WriteLine("6) Ammontare totale prestiti cliente");
    Console.WriteLine("7) Rate rimanenti prestiti di un cliente");
    Console.WriteLine("8) Esci");
    int scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            Console.WriteLine();
            Console.WriteLine("Inserisci il nome del nuovo cliente");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del nuovo cliente");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci il codice fiscale del nuovo cliente");
            string codiceFiscale = Console.ReadLine();
            Console.WriteLine("Inserisci lo stipendio del nuovo cliente");
            int stipendio = Convert.ToInt32(Console.ReadLine());
            Cliente nuovoCliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
            bool successo = banca.NuovoCliente(nuovoCliente);
            if (successo)
                Console.WriteLine("Cliente aggiunto correttamente");
            else
                Console.WriteLine("Dati errati o utente già presente");
            break;
        case 2:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale dell'utente da cercare");
            string codiceFiscale2 = Console.ReadLine();
            Cliente cliente2 = banca.CercaCliente(codiceFiscale2);
            if (cliente2 == null)
                Console.WriteLine("Cliente non trovato");
            else
                cliente2.StampaCliente();
            break;
        case 3:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale dell'utente da modificare");
            string codiceFiscale3Vecchio = Console.ReadLine();
            Console.WriteLine("Inserisci i campi che vuoi modificare, altrimenti lascia vuoto");
            Console.WriteLine("Nome");
            string nome3 = Console.ReadLine();
            Console.WriteLine("Cognome");
            string cognome3 = Console.ReadLine();
            Console.WriteLine("Codice fiscale");
            string codiceFiscale3 = Console.ReadLine();
            Console.WriteLine("Stipendio, per lasciarlo invariato digita -1");
            int stipendio3 = Convert.ToInt32(Console.ReadLine());
            Cliente clienteModificato = new Cliente(nome3, cognome3, codiceFiscale3, stipendio3);
            bool successo3 = banca.ModificaCliente(clienteModificato, codiceFiscale3Vecchio);
            if (successo3)
                Console.WriteLine("Cliente modificato correttamente");
            else
                Console.WriteLine("Dati errati o utente non presente");
            break;
        case 4:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale per il prestito");
            string codiceFiscale4 = Console.ReadLine();
            Console.WriteLine("Inserisci l'ammontare del prestito");
            int ammontare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci in quante rate si deve ripagare il prestito");
            int numeroRate = Convert.ToInt32(Console.ReadLine());
            DateOnly inizio4 = DateOnly.FromDateTime(DateTime.Now);
            DateOnly fine4 = inizio4.AddMonths(numeroRate);
            bool successo4 = banca.NuovoPrestito(codiceFiscale4, ammontare, inizio4, fine4);
            if (successo4)
                Console.WriteLine("Prestito accettato");
            else
                Console.WriteLine("Prestito rifiutato");
            break;
        case 5:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale del cliente");
            string codiceFiscale5 = Console.ReadLine();
            List<Prestito> prestitiCliente5 = banca.RicercaPrestitiCliente(codiceFiscale5);
            foreach (Prestito prestito in prestitiCliente5)
            {
                prestito.StampaPrestito();
            }
            break;
        case 6:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale del cliente");
            string codiceFiscale6 = Console.ReadLine();
            Console.WriteLine("Ammontare totale dei prestiti concessi: " + banca.AmmontareTotalePrestitiCliente(codiceFiscale6));
            break;
        case 7:
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice fiscale del cliente");
            string codiceFiscale7 = Console.ReadLine();
            List<Prestito> prestitiPagare = banca.RateRimanentiPrestitiCliente(codiceFiscale7);
            foreach (Prestito prestito in prestitiPagare)
            {
                prestito.StampaPrestito();
                Console.WriteLine("Hai " + prestito.RateRimanenti() + " rate da pagare ancora");
            }
            break;
        default:
            exit = true;
            break;
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
} while (!exit);