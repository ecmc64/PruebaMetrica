using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    public class ChangeString
    {
        private readonly IList<string> _lista;

        public ChangeString()
        {
            var letras = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,ñ,o,p,q,r,s,t,u,v,w,x,y,z";
            _lista = letras.Split(',').ToList();
        }
        public string Build(string pCadena)
        {
            var inputArray = pCadena.ToCharArray().Select(x => x.ToString()).ToList();
            var cadenaResultado = Transformar(inputArray);
            return cadenaResultado;
        }

        private string Transformar(IList<string> pLista)
        {
            var resultado = string.Empty;
            foreach (var item in pLista)
            {
                var index = _lista.IndexOf(item.ToLower());
                if (index == -1)
                    resultado = string.Concat(resultado, item);
                else
                {
                    var index2 = index + 1;
                    index2 = index2 >= _lista.Count() ? 0 : index2;

                    if (char.IsUpper(item[0]))
                        resultado = string.Concat(resultado, _lista[index2].ToUpper());
                    else
                    {
                        resultado = string.Concat(resultado, _lista[index2]);
                    }
                }
            }

            return resultado;
        }
    }
}
