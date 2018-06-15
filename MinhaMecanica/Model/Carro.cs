using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Carro
    {
        private string nome;
        private string marca;
        private decimal valor;
        private short anoFabricacao;

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                //if (value == null || value == "")
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome deve ser preenchido");
                }

                if (value.Count() == 1)
                {
                    throw new Exception("Nome deve conter no mínimo 2 caracteres");
                }
                nome = value;
            }
        }   

        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Marca deve ser preenchida");
                }

                if (value.Count() < 3)
                {
                    throw new Exception("Marca deve conter no mínimo 3 caracteres");
                }
                marca = value;
            }
        }

        public decimal Valor
        {
            get { return valor; }
            set
            {
            
                if (value < 0)
                {
                    throw new Exception("Valor deve ser maior que zero");
                }
                valor = value;
            }
        }

        public short AnoFabricacao
        {
            get { return anoFabricacao; }
            set
            {
                if (value < 1885)
                {
                    throw new Exception("Ano deve ser maior que 1885");
                }
                if (value >= DateTime.Now.Year)
                {
                    throw new Exception("Ano deve ser menor ou igual a " + DateTime.Now.Year);
                }
                anoFabricacao = value;
            }
        }
        
       
            
    }
}
