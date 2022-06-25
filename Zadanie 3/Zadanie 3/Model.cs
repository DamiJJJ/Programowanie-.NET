using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie_3
{
    internal class Model
    {
        public ObservableCollection<Album> ListaAlbumów { get; } = new ObservableCollection<Album>();
        public Model()
        {
            ListaAlbumów.Add(new Album() { Tytul = "Pretty Boy", Autor = "White 2115", Wydawca = "SBM Label", Nosnik = "CD" });
            ListaAlbumów.Add(new Album() { Tytul = "Uczta", Autor = "Sanah", Wydawca = "Magic Records" });
            ListaAlbumów.Add(new Album() { Tytul = "Zeit", Autor = "Rammstein", Wydawca = "Universal Music Group", DataWydania= new DateTime(2022, 4, 29)});
        }

        internal Album NowyAlbum()
        {
            Album nowy = new Album();
            ListaAlbumów.Add(nowy);
            return nowy;
        }
    }
}
