//aggiunta di un prestito
// 1. chiedo all'utente di cercare il cliente su cui si vuole creare un prestito


// 2. chiedo i dati del prestito
// 3. aggiungo il prestito



//inserimento cliente
//Console.WriteLine("Inserisci il codice fiscale:");
//string codiceFiscale = Console.ReadLine();

//bool esitoInserimento = intesa.AggiungiCliente("test 1", "test 1", codiceFiscale, 0);

//if (esitoInserimento)
//{
//    Console.WriteLine("Inserimento utente avvenuto con successo");
//}
//else
//{
//    Console.WriteLine("errore: Impossibile inserire l'utente");
//}
//fine inserimento cliente

//Sviluppare un’applicazione orientata agli oggetti per gestire
//i prestiti che una banca concede ai propri clienti.



//I clienti sono caratterizzati da
//- nome
//- cognome,
//- codice fiscale
//- stipendio
public class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    //qui non serve perchè è già in banca e anche in Prestito c'è la relazione con il cliente
    //public List<Prestito> Prestiti { get; set; }

    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
    }
}