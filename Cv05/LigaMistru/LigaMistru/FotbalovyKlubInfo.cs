using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru
{
    class FotbalovyKlubInfo
    {
        public readonly int Pocet;

        public FotbalovyKlubInfo()
        {
            foreach (FotbalovyKlub fk in (FotbalovyKlub[])Enum.GetValues(typeof(FotbalovyKlub)))
            {
                Pocet++;
            }
        }

        public string DejNazev(FotbalovyKlub klubEnum)
        {
            switch (klubEnum)
            {
                case FotbalovyKlub.None:
                    return "";
                case FotbalovyKlub.FCPorto:
                    return "FC Porto";
                case FotbalovyKlub.Arsenal:
                    return "Arsenal";
                case FotbalovyKlub.RealMadrid:
                    return "Real Madrid";
                case FotbalovyKlub.Chelsea:
                    return "Chelsea";
                case FotbalovyKlub.Barcelona:
                    return "Barcelona";
                default:
                    return "";
            }
        }
    }
}
