using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    public class MoneyParts
    {
        readonly List<decimal> _monedas = new List<decimal>() { 0.05m, 0.1m, 0.2m, 0.5m, 1m, 2m, 5m, 10m, 20m, 50m, 100, 200m };
        private static List<string> _combinaciones;

        public List<string> Build(string input)
        {
            var suma = Convert.ToDecimal(input);
            _combinaciones = new List<string>();
            var lista = new List<string>();

            Contar(_monedas, suma, new List<decimal>(), lista);

            return _combinaciones;
        }

        private static void Contar(List<decimal> pListaMonedas, decimal suma, List<decimal> parcial, List<string> lst)
        {
            decimal s = parcial.Sum();

            if (s == suma)
            {
                var final = parcial.OrderBy(x => x).ToArray();
                if (lst.IndexOf(string.Join(",", final)) == -1)
                {
                    _combinaciones.Add("[" + string.Join(",", final) + "]");
                    lst.Add(string.Join(",", final));
                }
            }

            if (s >= suma)
                return;

            for (int i = 0; i < pListaMonedas.Count; i++)
            {

                var remaining = new List<decimal>();

                var lstPartial = new List<decimal>(parcial);
                for (int nivel = i; nivel < pListaMonedas.Count; nivel++)
                {
                    decimal n = pListaMonedas[nivel];
                    lstPartial.Add(n);
                    Contar(pListaMonedas, suma, lstPartial, lst);
                }
                for (int j = i + 1; j < pListaMonedas.Count; j++)
                    remaining.Add(pListaMonedas[j]);

                Contar(remaining, suma, lstPartial, lst);
            }
        }
    }
}
