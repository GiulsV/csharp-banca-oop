//aggiunta di un prestito
// 1. chiedo all'utente di cercare il cliente su cui si vuole creare un prestito


//Per la banca deve essere possibile:
//- aggiungere, modificare e ricercare un cliente dato il codice fiscale.
//- aggiungere un prestito.
//- effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//- sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//- sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.

//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano
//in un formato di tipo stringa a piacere.

//**Bonus:**

//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

//La banca è caratterizzata da
//- un nome
//- un insieme di clienti (una lista)
//-un insieme di prestiti concessi ai clienti (una lista)
public class Banca
{
    public string Nome { get; set; }
    List<Cliente> Clienti { get; set; }
    List<Prestito> Prestiti { get; set; }

    public Banca(string Nome)
    {
        Nome = Nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();
    }

    public bool AggiungiCliente(Cliente cliente)
    {
        //if (
        //   cliente.Nome == null || cliente.Nome == "" ||
        //   cliente.Cognome == null || cliente.Cognome == "" ||
        //   codiceFiscale == null || codiceFiscale == "" ||
        //   stipendio < 0
        //   )
        //{
        //    return false;
        //}

        return false;
    }
    public bool AggiungiCliente(string nome, string cognome, string codiceFiscale, int stipendio, int altezza)
    {

        if (
            nome == null || nome == "" ||
            cognome == null || cognome == "" ||
            codiceFiscale == null || codiceFiscale == "" ||
            stipendio < 0
            )
        {
            return false;
        }

        Cliente esistente = RicercaCliente(codiceFiscale);

        //se il cliente esiste l'istanza sarà diversa dal null
        if (esistente != null)
            return false;

        Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        Clienti.Add(cliente);

        return true;
    }

    public Cliente RicercaCliente(string codiceFiscale)
    {

        foreach (Cliente cliente in Clienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }

        return null;
    }

    public List<Prestito> RicercaPrestito(string codiceFiscale)
    {
        List<Prestito> trovati = new List<Prestito>();



        return trovati;
    }

    public int AmmontareTotalePrestitiCliente(string codiceFiscale)
    {
        int ammontare = 0; //metterò il conteggio

        //conteggio...

        return ammontare;
    }

    public int RateMancantiCliente(string codiceFiscale)
    {
        int rateMancanti = 0; //metterò il conteggio

        //conteggio...

        return rateMancanti;
    }

    public void StampaProspettoClienti()
    {
        //stampare per tutti i clienti
    }

    public void StampaProspettoPrestiti()
    {
        //stampa per tutti i prestiti
    }

    public void AggiungiPrestito(Prestito nuovoPrestito)
    {

    }
}

