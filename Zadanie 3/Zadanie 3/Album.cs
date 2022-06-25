using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zadanie_3
{
    public class Album : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static readonly Dictionary<string, string[]> PowiązaneWłaściwości
            = new Dictionary<string, string[]>()
            {
                ["Tytuł"] = new string[] { "tytułAutorWydawca" },
                ["Autor"] = new string[] { "tytułAutorWydawca" },
                ["Wydawca"] = new string[] { "tytułAutorWydawca" },
                ["Nośnik"] = new string[] { "Nośnik" },
                ["DataWydania"] = new string[] { "Wiek" },
            };
        void OnPropertyChanged(
            [CallerMemberName] string właściwość = null,
            HashSet<string> obsłużoneWcześniej = null
            )
        {
            if (obsłużoneWcześniej == null)
                obsłużoneWcześniej = new HashSet<string>();
            if (!obsłużoneWcześniej.Contains(właściwość))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(właściwość));
                obsłużoneWcześniej.Add(właściwość);
                if (PowiązaneWłaściwości.ContainsKey(właściwość))
                    foreach (string powiązanaWłaściwość in PowiązaneWłaściwości[właściwość])
                        OnPropertyChanged(powiązanaWłaściwość, obsłużoneWcześniej);
            }
        }

        private string
            tytul, autor, wydawca, nosnik;
        private DateTime?
            dataWydania;

        public string Tytul
        {
            get => tytul;
            set
            {
                tytul = value;
                OnPropertyChanged();
            }
        }
        public string Autor
        {
            get => autor;
            set
            {
                autor = value;
                OnPropertyChanged();
            }
        }

        public string Wydawca
        {
            get => wydawca;
            set
            {
                wydawca = value;
                OnPropertyChanged();
            }
        }

        public string Nosnik
        {
            get => nosnik;
            set
            {
                nosnik = value;
                OnPropertyChanged();
            }
        }
        public string tytułAutorWydawca => $"{Tytul} - {Autor}, wydawca: {Wydawca}";

        public DateTime? DataWydania
        {
            get => dataWydania;
            set
            {
                dataWydania = value;
                OnPropertyChanged();
            }
        }
    }
}
