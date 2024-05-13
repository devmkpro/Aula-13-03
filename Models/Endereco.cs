using System;

namespace CEP.Models
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string DDD { get; set; }

        public Endereco(string cep, string logradouro, string complemento, string uf, string bairro, string ddd)
        {
            CEP = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            UF = uf;
            Bairro = bairro;
            DDD = ddd;
        }
        
    }
}
