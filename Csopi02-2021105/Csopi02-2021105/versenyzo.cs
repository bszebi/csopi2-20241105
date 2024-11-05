using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csopi02_2021105
{
    internal class versenyzo
    {
        public string Nev { get; set; }
        public int SzulEv { get; set; }
        public string RajtSzam { get; set; }
        public bool Nem { get; set; } // true = férfi, false = nő
        public string Kategoria { get; set; }
        public Dictionary<string, TimeSpan> VersenyIdok { get; set; }

        public int OsszIdo => (int)VersenyIdok.Values.Sum(x => x.TotalSeconds);

        public override string ToString() =>
            $"[{RajtSzam}] {Nev} ({Kategoria}, {(Nem ? "férfi" : "nő")})";

        public versenyzo(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            SzulEv = int.Parse(v[1]);
            RajtSzam = v[2];
            Nem = v[3] == "f";
            Kategoria = v[4];
            VersenyIdok = new()
            {
                { "Úszás",    TimeSpan.Parse(v[5]) },
                { "I. depó",  TimeSpan.Parse(v[6]) },
                { "Kerékpár", TimeSpan.Parse(v[7]) },
                { "II. depó", TimeSpan.Parse(v[8]) },
                { "Futás",    TimeSpan.Parse(v[9]) },
            };
        }
    }
}
