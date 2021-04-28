
// povolení testů spojového seznamu
#define PROVADEJ_TESTY_SPOJOVEHO_SEZNAMU

// povolení testování přetížení metody Equals ve třídě Hrac
#define TESTUJ_EQUALS

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LigaMistru;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaMistru.Tests
{
#if PROVADEJ_TESTY_SPOJOVEHO_SEZNAMU
    /*
     * Následující testy testují pouze omezenou část validního chování spojového seznamu.
     * Chybí testy všech variant okrajových hodnot a chybných stavů (např. odebrání ze začátku, 
     * z prostředka, z konce nebo neexistujícího prvku). Tyto testy můžete doplnit sami.
     */
    [TestClass()]
    public class SpojovySeznamTests
    {
        private void AssertHrac(Hrac expected, object actual)
        {
#if TESTUJ_EQUALS
            Assert.AreEqual(
                new Hrac() { Jmeno = expected.Jmeno, Klub = expected.Klub, GolPocet = expected.GolPocet },
                actual
            );
#else
            Assert.AreSame(expected, actual);
#endif
        }

        [TestMethod()]
        public void EmptyListTest()
        {
            SpojovySeznam ss = new SpojovySeznam();

            //...

            Assert.AreEqual(0, ss.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h = new Hrac();

            ss.Add(h);

            Assert.AreEqual(1, ss.Count);
            AssertHrac(h, ss[0]);
        }

        [TestMethod()]
        public void AddTestMultipleEntities()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac();
            Hrac h2 = new Hrac();
            Hrac h3 = new Hrac();

            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            Assert.AreEqual(3, ss.Count);
            AssertHrac(h1, ss[0]);
            AssertHrac(h2, ss[1]);
            AssertHrac(h3, ss[2]);
        }

        [TestMethod()]
        public void ClearTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac();
            Hrac h2 = new Hrac();
            Hrac h3 = new Hrac();
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            ss.Clear();

            Assert.AreEqual(0, ss.Count);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);

            Assert.IsTrue(ss.Contains(h1));
            Assert.IsTrue(ss.Contains(h2));
            Assert.IsFalse(ss.Contains(h3));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            Hrac[] hraci = new Hrac[3];
            ss.CopyTo(hraci, 0);

            AssertHrac(h1, hraci[0]);
            AssertHrac(h2, hraci[1]);
            AssertHrac(h3, hraci[2]);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            IEnumerator enumerator = ss.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            AssertHrac(h1, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            AssertHrac(h2, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            AssertHrac(h3, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            Hrac h4 = new Hrac() { Jmeno = "D", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            Assert.AreEqual(0, ss.IndexOf(h1));
            Assert.AreEqual(1, ss.IndexOf(h2));
            Assert.AreEqual(2, ss.IndexOf(h3));
            Assert.AreEqual(-1, ss.IndexOf(h4));
        }

        [TestMethod()]
        public void InsertTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            Hrac h4 = new Hrac() { Jmeno = "D", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            ss.Insert(2, h4);

            Assert.AreEqual(4, ss.Count);
            AssertHrac(h1, ss[0]);
            AssertHrac(h2, ss[1]);
            AssertHrac(h4, ss[2]);
            AssertHrac(h3, ss[3]);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            ss.Remove(h1);

            Assert.AreEqual(2, ss.Count);
            AssertHrac(h2, ss[0]);
            AssertHrac(h3, ss[1]);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            SpojovySeznam ss = new SpojovySeznam();
            Hrac h1 = new Hrac() { Jmeno = "A", GolPocet = 2, Klub = FotbalovyKlub.Barcelona };
            Hrac h2 = new Hrac() { Jmeno = "B", GolPocet = 3, Klub = FotbalovyKlub.Barcelona };
            Hrac h3 = new Hrac() { Jmeno = "C", GolPocet = 5, Klub = FotbalovyKlub.Barcelona };
            ss.Add(h1);
            ss.Add(h2);
            ss.Add(h3);

            ss.RemoveAt(2);

            Assert.AreEqual(2, ss.Count);
            AssertHrac(h1, ss[0]);
            AssertHrac(h2, ss[1]);
        }
    }
#endif
}