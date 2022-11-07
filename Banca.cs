
public class Banca
{
    public string Nome { get; set; }
    List<Cliente> Clienti { get; set; }
    List<Prestito> Prestiti { get; set; }

    public Banca(string Nome)
    {
        this.Nome = Nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();

        //DB
        Cliente cliente1 = new Cliente("Mario", "Rossi", "RS00", 1000);
        Cliente cliente2 = new Cliente("Maria", "Rossi", "RS01", 2000);
        Cliente cliente3 = new Cliente("Alberto", "Rossi", "RS02", 3000);

        Clienti.Add(cliente1);
        Clienti.Add(cliente2);
        Clienti.Add(cliente3);

        Prestito prestito1 = new Prestito(1111111, 2000, 100, DateOnly.Parse("01/02/2022"), DateOnly.Parse("01/03/2025"), cliente1);
        Prestito prestito2 = new Prestito(2222222, 4000, 100, DateOnly.Parse("01/03/2022"), DateOnly.Parse("01/04/2025"), cliente2);
        Prestito prestito3 = new Prestito(3333333, 1000, 50, DateOnly.Parse("01/04/2022"), DateOnly.Parse("01/05/2025"), cliente2);
        Prestito prestito4 = new Prestito(4444444, 1000, 30, DateOnly.Parse("01/05/2022"), DateOnly.Parse("01/06/2025"), cliente3);
        Prestito prestito5 = new Prestito(5555555, 1000, 25, DateOnly.Parse("01/06/2022"), DateOnly.Parse("01/07/2025"), cliente3);
        Prestito prestito6 = new Prestito(6666666, 1000, 70, DateOnly.Parse("01/07/2022"), DateOnly.Parse("01/08/2025"), cliente3);

        Prestiti.Add(prestito1);
        Prestiti.Add(prestito2);
        Prestiti.Add(prestito3);
        Prestiti.Add(prestito4);
        Prestiti.Add(prestito5);
        Prestiti.Add(prestito6);
    }

    public bool AggiungiCliente(Cliente cliente)
    {
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

        //ricerca dell'utente tramite codice fiscale
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
    //Modifica
    public bool ModificaCliente(string inputUtente, string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Cliente modificaCliente = RicercaCliente(inputUtente);

        if (
            nome == "" &&
            cognome == "" &&
            codiceFiscale == "" &&
            stipendio == null
            )
        {
            return false;
        }

        if (modificaCliente == null)
        {
            return false;
        }
        if (nome != "")
            modificaCliente.Nome = nome;
        if (cognome != "")
            modificaCliente.Cognome = cognome;
        if (codiceFiscale != "")
            modificaCliente.CodiceFiscale = codiceFiscale;
        if (stipendio != null || stipendio <= 0)
            modificaCliente.Stipendio = stipendio;

        return true;
    }

    public List<Prestito> RicercaPrestito(string codiceFiscale)
    {
        Cliente cliente = RicercaCliente(codiceFiscale);
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
    // Funzione che ritorna il totale dei prestiti dell'utente
    public int AmmontareTotalePrestitiCliente(string codiceFiscale)
    {
        int ammontare = 0; //metterò il conteggio

        List<Prestito> prestitiCliente = RicercaPrestito(codiceFiscale);

        foreach (Prestito prestito in prestitiCliente)
        {
            ammontare += prestito.Ammontare;
        }

        return ammontare;
    }
    //Funzione che ritorna il totale delle rate da pagare per il prestito
    public int RateMancantiCliente(string codiceFiscale)
    {
        int rateMancanti = 0; 
        foreach (Prestito prestito in Prestiti)
        {
            if (prestito.ID.Equals(prestito.ID))
            {
                //momentaneo
                rateMancanti = (prestito.Ammontare / prestito.ValoreRata) - (prestito.ValoreRata - 3);

            }
        }

        return rateMancanti;
    }
    public void AggiungiPrestito(Prestito nuovoPrestito)
    {
        {
            this.Prestiti.Add(nuovoPrestito);
        }
    }

    public void StampaProspettoClienti()
    {
        //stampare per tutti i clienti
        foreach (Cliente cliente in Clienti)
        {
            Console.WriteLine(cliente.ToString());
        }
    }

    public void StampaProspettoPrestiti()
    {
        //stampa per tutti i prestiti
        foreach (Prestito prestito in Prestiti)
        {
            Console.WriteLine(prestito.ToString());
        }
    }

}