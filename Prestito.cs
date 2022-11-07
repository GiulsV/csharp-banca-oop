
public class Prestito
{
    public int ID { get; set; }
    public int Ammontare { get; set; }
    public int ValoreRata { get; set; }
    public DateOnly Inizio { get; set; }
    public DateOnly Fine { get; set; }
    public Cliente Intestatario { get; set; }
    public Cliente ClienteEsistente { get; }
    public int Rata { get; }
    public DateTime DataInizio { get; }
    public DateOnly DataInizio1 { get; }

    //prestito in partenza dalla data specificata
    public Prestito(int iD, int ammontare, int valoreRata, DateOnly inizio, DateOnly fine, Cliente intestatario)
    {
        ID = iD;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        Inizio = inizio;
        Fine = fine;
        Intestatario = intestatario;
    }

    //un prestito in data di oggi
    public Prestito(int iD, int ammontare, int valoreRata, DateOnly fine, Cliente intestatario)
    {
        ID = iD;
        Ammontare = ammontare;
        ValoreRata = valoreRata;
        var dateNow = DateOnly.FromDateTime(DateTime.Now);      //data odierna
        Inizio = new DateOnly();
        Fine = fine;
        Intestatario = intestatario;
    }

    public Prestito(Cliente clienteEsistente, int ammontare, int rata, DateOnly dataInizio)
    {
        ClienteEsistente = clienteEsistente;
        Ammontare = ammontare;
        Rata = rata;
        DataInizio1 = dataInizio;
    }
}

