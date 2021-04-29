using System;
using System.Collections;

namespace LigaMistru
{
    public class SpojovySeznam : IEnumerable, ICollection, IList
    {
        private PrvekSeznamu prvni;
        private PrvekSeznamu posledni;
        private int pocetPrvku;

        public SpojovySeznam()
        {
            prvni = null;
            posledni = null;
            pocetPrvku = 0;
        }

        public class PrvekSeznamu
        {
            public Object Data { get; set; }
            public PrvekSeznamu Dalsi { get; set; }
            public PrvekSeznamu Predchozi { get; set; }

            public PrvekSeznamu(Object data)
            {
                Data = data;
                Dalsi = null;
                Predchozi = null;
            }
        }

        public object this[int index]
        {
            get => Get(index); set => Set(index, value);
        }

        public int Count => pocetPrvku;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Add(object value)
        {
            if (value == null)
            {
                return -1;
            }

            if (pocetPrvku == 0)
            {
                PrvekSeznamu prvek = new PrvekSeznamu(value);
                prvni = (PrvekSeznamu)prvek;
                posledni = (PrvekSeznamu)prvek;
                pocetPrvku++;
                return pocetPrvku;
            }
            else
            {
                PrvekSeznamu prvek = new PrvekSeznamu(value);
                prvek.Data = value;
                prvek.Predchozi = posledni;
                posledni.Dalsi = prvek;
                posledni = prvek;

                pocetPrvku++;
                return pocetPrvku;
            }
        }

        public void Clear()
        {
            prvni = null;
            posledni = null;
            pocetPrvku = 0;
        }

        public bool Contains(object value)
        {
            if (Count == 0 || value==null)
            {
                return false;
            }

            PrvekSeznamu aktualni = prvni;
            while (aktualni != null)
            {
                if (value.Equals(aktualni.Data))
                {
                    return true;
                }
                aktualni = aktualni.Dalsi;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            if(array==null)
            {
                throw new ArgumentNullException("neni nastaveno pole");
            }
            if (array.Length - index < Count)
            {
                // array.length = 20; Count = 20; index = 10
                throw new ArgumentOutOfRangeException("pole neni dostatecne velke"); 
            }
            PrvekSeznamu aktualni = prvni;
            while (aktualni != null)
            {
                array.SetValue(aktualni.Data, index);
                index++;
                aktualni = aktualni.Dalsi;
            }
        }


        public int IndexOf(object value)
        {
            if (Count == 0)
            {
                return -1;
            }

            int index = 0;
            PrvekSeznamu aktualni = prvni;
            while (aktualni != null)
            {
                if (value.Equals(aktualni.Data))
                {
                    return index;
                }
                aktualni = aktualni.Dalsi;
                index++;
            }
            return -1;
        }

        public object Get(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index je mimo rozsah");
            }
            else
            {
                PrvekSeznamu aktualni = prvni;
                for (int i = 0; i < index; i++)
                {
                    aktualni = aktualni.Dalsi;
                }
                return aktualni.Data;
            }
        }

        public void Set(int index, object value)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index je mimo rozsah");
            }
            else
            {
                PrvekSeznamu aktualni = prvni;
                for (int i = 0; i < index; i++)
                {
                    aktualni = aktualni.Dalsi;
                }
                aktualni.Data = value;
            }
        }

        public void Insert(int index, object value)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException("Index je mimo rozsah");
            }
            else
            {
                PrvekSeznamu novyPrvek = new PrvekSeznamu(value);
                if (index == Count)
                {
                    novyPrvek.Predchozi = posledni;
                    posledni.Dalsi = novyPrvek;
                    posledni = novyPrvek;

                    pocetPrvku++;
                }
                else if (index == 0)
                {
                    Add(value);
                }
                else
                {
                    // [0] [1] [stary] [stary2]
                    PrvekSeznamu aktualni = prvni;
                    for (int i = 0; i < index; i++)
                    {
                        aktualni = aktualni.Dalsi;
                    }

                    // [1].dalsi a [1].predchozi
                    novyPrvek.Dalsi = aktualni;
                    novyPrvek.Predchozi = aktualni.Predchozi;

                    // [0].dalsi
                    novyPrvek.Predchozi.Dalsi = novyPrvek;
                    // [stary].predchozi
                    aktualni.Predchozi = novyPrvek;

                    aktualni = novyPrvek;
                    pocetPrvku++;
                }
            }
        }

        public void Remove(object value)
        {

            if (Count != 0)
            {
                PrvekSeznamu aktualni = prvni;
                while (aktualni != null)
                {
                    if (value.Equals(aktualni.Data))
                    {
                        if (aktualni ==prvni)
                        {
                            prvni = prvni.Dalsi;
                            pocetPrvku--;
                        }
                        else if (aktualni == posledni)
                        {
                            posledni = posledni.Predchozi;
                            pocetPrvku--;
                        }
                        else
                        {
                            // [0] [nalezeny] [2]

                            // [0]->[2]
                            aktualni.Predchozi.Dalsi = aktualni.Dalsi;
                            // [0]<-[2]
                            aktualni.Dalsi.Predchozi = aktualni.Predchozi;
                            pocetPrvku--;
                        }
                    }
                    aktualni = aktualni.Dalsi;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count) 
            {
                throw new ArgumentOutOfRangeException("Index je mimo rozsah");
            }
            else
            {
                if (index == 0)
                {
                    prvni = prvni.Dalsi;
                    pocetPrvku--;
                }
                else if (index == Count-1)
                {
                    posledni = posledni.Predchozi;
                    pocetPrvku--;
                }
                else // [0] [nalezeny] [2]
                {
                    PrvekSeznamu aktualni = prvni;
                    for (int i = 0; i < index; i++)
                    {
                        aktualni = aktualni.Dalsi;
                    }
                    // [0]->[2]
                    aktualni.Predchozi.Dalsi = aktualni.Dalsi;
                    // [0]<-[2]
                    aktualni.Dalsi.Predchozi = aktualni.Predchozi;
                    pocetPrvku--;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            PrvekSeznamu aktualni = prvni;
            while (aktualni != null)
            {
                yield return aktualni.Data;
                aktualni = aktualni.Dalsi;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}