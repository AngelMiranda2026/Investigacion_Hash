using System;
using System.Collections.Generic;
using System.Text;

namespace Parqueo
{
    public class EspacioVisual
    {
        public int Numero;
        public bool Ocupado;
        public Rectangle Area;

        public EspacioVisual(int numero, Rectangle area)
        {
            Numero = numero;
            Area = area;
            Ocupado = false;
        }
    }
}