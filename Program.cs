// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


/*Consegna:
Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.

La banca è caratterizzata da
        - un nome
        - un insieme di clienti (una lista)
        - un insieme di prestiti concessi ai clienti (una lista)

I clienti sono caratterizzati da
        - nome,
        - cognome,
        - codice fiscale
        - stipendio

I prestiti sono caratterizzati da
        - ID
        - intestatario del prestito (il cliente),
        - un ammontare,
        - una rata,
        - una data inizio,
        - una data fine.

Per la banca deve essere possibile:
        - aggiungere, modificare e ricercare un cliente.
        - aggiungere un prestito.
        - effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
        - sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
        - sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.

Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.

Bonus:
visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.*/

Banca intesa = new Banca("Intesa san Paolo");


Console.WriteLine("Sistema amministrazione banca " + intesa.Nome);

//aggiunta di un prestito
// 1. chiedo all'utente di cercare il cliente su cui si vuole creare un prestito
Console.WriteLine("Creazione di un nuovo prestito");
Console.WriteLine();
Console.WriteLine("Inserisci il codice fiscale:");
string codiceFiscale = Console.ReadLine();

Cliente esistente = intesa.RicercaCliente(codiceFiscale);

if (esistente == null)
{
    Console.WriteLine("errore: Cliente non trovato!");
}
else
{

    Console.WriteLine("Ammontare del prestito: ");
    int ammontarePrestito = Convert.ToInt32(Console.ReadLine());
    Prestito nuovoPrestito = new Prestito(0, ammontarePrestito, 0, new DateOnly(), esistente);

    intesa.AggiungiPrestito(nuovoPrestito);
}