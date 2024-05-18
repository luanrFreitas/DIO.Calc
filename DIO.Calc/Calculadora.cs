using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Calc
{
    public class Calculadora
    {
        private List<string> _historico;
                DateTime _date;

        public Calculadora(DateTime date)
        {
            _historico = new List<string>();
            _date = date;
        }
        public int Somar(int val1, int val2)
        {
            int resultado = val1 + val2;
            _historico.Insert(0, $"{val1} + {val2} = {resultado} : {_date}");
            return resultado;
        }

        public int Subtrair(int val1, int val2)
        {
            int resultado = val1 - val2;
            _historico.Insert(0, $"{val1} - {val2}={resultado}");
            return resultado;
        }

        public int Multiplicar(int val1, int val2)
        {
            int resultado = val1 * val2;
            _historico.Insert(0, $"{val1} * {val2}={resultado}");
            return resultado;
        }

        public int Dividir(int val1, int val2)
        {
            int resultado = val1 / val2;
            _historico.Insert(0, $"{val1} / {val2}={resultado}");
            return resultado;
        }
        public List<string> Historico()
        {
            if (_historico.Count > 3)
                _historico.RemoveRange(3, _historico.Count - 3);
            return _historico;
        }
    }
}
