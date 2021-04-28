using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal class PrvekSeznamu
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
            get => throw new NotImplementedException(); set => throw new NotImplementedException(); 
        }

        public int Count => pocetPrvku;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Add(object value)
        {
            if(value == null)
            {
                return -1;
            }
            else if (pocetPrvku == 0)
            {
                PrvekSeznamu prvek = new PrvekSeznamu(value);
                prvni = (PrvekSeznamu) value;
                posledni = (PrvekSeznamu)value;
                pocetPrvku++;
                return pocetPrvku;
            }
            else
            {
                PrvekSeznamu prvek = new PrvekSeznamu(value);
                prvek.Data = value;
                prvek.Dalsi = prvni;
                prvni.Predchozi = prvek;
                prvni = prvek;

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
            if (Count == 0)
            {
                throw new NullReferenceException();
            }

            PrvekSeznamu aktualni = DejPrvni();
            while(aktualni!=null)
            {
                if (value.Equals(aktualni))
                {
                    return true;
                }
                aktualni = aktualni.Dalsi;
            }
            return false;
            throw new NotImplementedException();
        }
        //TODO
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        //TODO
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        //TODO
        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        //TODO
        //public object Get(int index)
        //{
        //    if ()
        //    {

        //    }
        //}
        //TODO
        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }
        //TODO
        public void Remove(object value)
        {
            throw new NotImplementedException();
        }
        //TODO
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        

    }
}
