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

Banca boolBank = new Banca("BoolBank");

Console.WriteLine("Software Gestionale {0}" , boolBank.Nome);
Console.WriteLine();

bool running = true;

while (running)
{
    Console.WriteLine("Menu");
    Console.Write("Seleziona l'azione che vuoi eseguire digitando il numero");
    Console.WriteLine();
    Console.WriteLine("[1]  Aggiungi cliente");
    Console.WriteLine("[2]  Modifica cliente");
    Console.WriteLine("[3]  Ricerca cliente");
    Console.WriteLine("[4]  Ricerca prestito cliente");
    Console.WriteLine("[5]  Aggiungi un prestito");
    Console.WriteLine("[6]  Prospetto prestiti banca");
    Console.WriteLine("[7]  Prospetto prestiti");
    Console.WriteLine("[8]  Esc");

    int scelta = Convert.ToInt32(Console.ReadLine());

    switch (scelta)
    {
        //Aggiungi cliente
        case 1:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            string codiceFiscale = Console.ReadLine();

            Cliente clienteEsistente = boolBank.RicercaCliente(codiceFiscale);

            if (clienteEsistente != null)
            {
                Console.WriteLine("Il cliente è già stato inserito!");

            }
            else
            {

                Console.Write("Inserisci Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Inserisci Cognome: ");
                string cognome = Console.ReadLine();

                Console.Write("Inserisci il tuo stipendio: ");
                int stipendio = Convert.ToInt32(Console.ReadLine());


                Cliente nuovoCliente = new Cliente(codiceFiscale);
                boolBank.AggiungiCliente(nuovoCliente);


                if (nuovoCliente != null)
                    Console.WriteLine("Cliente registrato con successo");
                else
                    Console.WriteLine("Errore nella registrazione. Riprova");
                Console.WriteLine();

            }
            break;
            Console.WriteLine("Il cliente è stato inserito correttamente");

        //Modifica cliente
        case 2:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = boolBank.RicercaCliente(codiceFiscale);

            if (clienteEsistente == null)
            {

                Console.WriteLine("Attenzione! non è stato trovato alcun cliente, cambia i criteri di ricerca");

            }
            else
            {
                Console.WriteLine("Inserisci il nome del cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome del cliente:");
                string cognomeCliente = Console.ReadLine();

                clienteEsistente.Nome = nomeCliente;
                clienteEsistente.Cognome = cognomeCliente;

                Console.WriteLine("Il cliente è stato modificato correttamente");
            }
            break;

            //Ricerca cliente
        case 3:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = boolBank.RicercaCliente(codiceFiscale);

            if (clienteEsistente == null)
            {

                Console.WriteLine("Attenzione! non è stato trovato alcun cliente, cambia i criteri di ricerca");

            }
            else
            {
                Console.WriteLine("Cliente Trovato!");
                Console.WriteLine(clienteEsistente.ToString());
            }

            break;

            //Ricerca prestito cliente
        case 4:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            Cliente client = boolBank.RicercaCliente(codiceFiscale);
            List<Prestito> Prestiti = boolBank.RicercaPrestito(codiceFiscale);

            //Richiamre funzione AmmontareTotalePrestitiCliente
            int ammontareTot = 0;

                foreach (Prestito prestito in Prestiti)
                {
                    ammontareTot += prestito.Ammontare;

                }
            Console.WriteLine("Totale ammontare prestiti concessi: {0}", ammontareTot);

            //richiamre funzione RateMancantiCliente

            foreach (Prestito prestito in Prestiti)
            {
                Console.WriteLine("Per il prestito {0}, rimangono {1} rate da pagare.", prestito.ID, prestito.ValoreRata);

            }
            break;

            //Aggiungi un prestito
        case 5:

            Console.WriteLine("Inserisci il codice fiscale del cliente:");
            codiceFiscale = Console.ReadLine();

            clienteEsistente = boolBank.RicercaCliente(codiceFiscale);

            if (clienteEsistente == null)
            {
                Console.WriteLine("Cliente non trovato. Modifica la tua ricerca");
            }
            else
            {
                Console.WriteLine("Cliente trovato");

                Console.WriteLine("Inserisci l'ammontare del prestito:");
                int ammontare = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Inserisci le rate del prestito:");
                int rata = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Inserisci la data di inizio prestito:");
                DateOnly dataInizio = DateOnly.Parse(Console.ReadLine()); ;

                Prestito nuovoPrestito = new(clienteEsistente, ammontare, rata, dataInizio);

                boolBank.AggiungiPrestito(nuovoPrestito);
                Console.WriteLine("Prestito aggiunto");

            }
            break;

            //Prospetto prestiti banca
        case 6:
            Console.WriteLine("Lista prospetto prestiti banca");
            boolBank.StampaProspettoPrestiti();

            break;


        //Prospetto clienti
        case 7:
            Console.WriteLine("Lista prospetto clienti");
            boolBank.StampaProspettoClienti();
            break;

        //esc
        case 8:
            running = false;
            break;

        default:
            Console.WriteLine("L'opzione scelta non esiste");
            break;
    }
}
