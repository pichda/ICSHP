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
        public readonly string[] NazvyKlubu = { "", "FC Porto", "Arsenal", "Real Madrid", "Chelsea", "Barcelona" };

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

        public FotbalovyKlub DejKlub(string Nazev)
        {
            switch (Nazev)
            {
                case "":
                    return FotbalovyKlub.None;
                case "FC Porto":
                    return FotbalovyKlub.FCPorto;
                case "Arsenal":
                    return FotbalovyKlub.Arsenal;
                case "Real Madrid":
                    return FotbalovyKlub.RealMadrid;
                case "Chelsea":
                    return FotbalovyKlub.Chelsea;
                case "Barcelona":
                    return FotbalovyKlub.Barcelona;
                default:
                    return FotbalovyKlub.None;
            }
        }
    }
}
