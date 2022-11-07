
public class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
    }
    public override string ToString()
    {
        return ("Nome: " + Nome + 
                " Cognome: " + Cognome + 
                " Codice Fiscale: " + CodiceFiscale + 
                " Stipendio: " + Stipendio);
    }

    public Cliente(string codiceFiscale)
    {
        CodiceFiscale = codiceFiscale;
    }
}