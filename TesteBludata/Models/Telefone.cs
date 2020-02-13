using TesteBludata.Models.Enums;

namespace TesteBludata.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public string NumeroTelefone { get; set; }
        public TelefoneTipo Tipo { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Telefone() 
        { 
        }

        public Telefone(int id, string numeroTelefone, TelefoneTipo tipo, Fornecedor fornecedor)
        {
            Id = id;
            NumeroTelefone = numeroTelefone;
            Tipo = tipo;
            Fornecedor = fornecedor;
        }
    }
}
