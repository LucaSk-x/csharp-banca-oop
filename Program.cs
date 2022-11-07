
// See https://aka.ms/new-console-template for more information

Banca banca = new Banca("Intesa san Paolo");
Cliente Cliente1 = new Cliente("mario", "rossi", "MRARSS00E256DD89", 1200);
Cliente Cliente2 = new Cliente("mario", "rossi", "MRARSS00E256DD89", 1200);

banca.NuovoCliente(Cliente1);
banca.NuovoCliente(Cliente2);

Cliente cercaCliente = banca.CercaCliente("MRARSS00E256DD89");
Console.WriteLine("Ho trovato il cliente " + cercaCliente.Nome + " " + cercaCliente.Cognome);

Cliente Cliete1Mod = new Cliente("Giuseppe", "", "MRARSS00E256DD89", 1000);
banca.ModificaCliente(Cliete1Mod);

Console.WriteLine("Ho trovato il cliente " + cercaCliente.Nome + " " + cercaCliente.Cognome);

DateOnly inizio = DateOnly.FromDateTime(DateTime.Now);
DateOnly fine = inizio.AddMonths(24);
banca.NuovoPrestito("CRNSMN", 10000, inizio, fine);