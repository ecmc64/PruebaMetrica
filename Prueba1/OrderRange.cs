using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    public class OrderRange
    {
        public string Build(IList<string> pLista)
        {
            var listaEnteros = new List<int>();
            foreach (var numeroCadena in pLista)
            {
                listaEnteros.Add(Convert.ToInt32(numeroCadena));
            }

            var cadenaResultado = string.Empty;
            var listaOrdenada = listaEnteros.OrderBy(x=>x);
            var listaPar = new List<int>();
            var listaImpar = new List<int>();

            foreach (var item in listaOrdenada)
            {
                if (EsPar(item))
                    listaPar.Add(item);
                else
                    listaImpar.Add(item);
            }

            if(listaPar.Count>0)
                cadenaResultado += "[" + string.Join(",", listaPar) + "]";

            if (listaImpar.Count > 0)
                cadenaResultado += "[" + string.Join(",", listaImpar) + "]";

            return cadenaResultado;
        }

        private bool EsPar(int pNum)
        {
            return pNum % 2 == 0;
        }
    }
}
