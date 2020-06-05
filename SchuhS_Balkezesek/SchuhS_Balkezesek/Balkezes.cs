using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Balkezesek
{
    class Balkezes
    {
        //név;első;utolsó;súly;magasság
        public string Nev;
        public string ElsoPalyaralepes;
        public string UtolsoPalyaralepes;
        public int Suly;
        public int Magassag;

        public Balkezes(string sor)
        {
            var dbok = sor.Split(';');
            this.Nev = dbok[0];
            this.ElsoPalyaralepes = dbok[1];
            this.UtolsoPalyaralepes = dbok[2];
            this.Suly = int.Parse(dbok[3]);
            this.Magassag = int.Parse(dbok[4]);

        }

    }
}
