using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class RegraDesconto
    {
        public RegraDesconto(int diasDesconto, decimal percentual)
        {
            DiasDesconto = diasDesconto;
            PercentualDesconto = percentual;
        }
        public int DiasDesconto { get; set; }
        public decimal PercentualDesconto { get; set; }
    }
}
