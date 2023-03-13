using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmSpiegazione.Model;
using System.Collections.ObjectModel;

namespace MvvmSpiegazione.ModelView
{
    public partial class PersonModelView : ObservableObject
    {
        // Dichiarazione di una collezione di oggetti di tipo "Person"
        public ObservableCollection<Person> People { get; set; }

        // Dichiarazione di una proprietà osservabile di tipo stringa, usata per la gestione dell'input dell'utente
        [ObservableProperty]
        string text;

        // Costruttore della classe
        public PersonModelView()
        {
            // Inizializzazione della collezione "People"
            People = new ObservableCollection<Person>();

            // Aggiunta di alcuni elementi predefiniti alla collezione "People"
            People.Add(new Person() { Name = "Pippo", Surname = "Baudo", Age = 27 });
            People.Add(new Person() { Name = "Marco", Surname = "Bianchi", Age = 21 });
            People.Add(new Person() { Name = "Luca", Surname = "Rossi", Age = 13 });
        }

        // Metodo usato per l'aggiunta di un nuovo elemento alla collezione "People"
        [RelayCommand]
        public void AddItem()
        {
            // Divisione dell'input dell'utente in una serie di sottostringhe usando il punto e virgola come separatore
            string[] array = Text.Split(';');

            // Creazione di un nuovo oggetto "Person" a partire dalle sottostringhe ottenute
            Person person = new Person() { Name = array[0], Surname = array[1], Age = int.Parse(array[2]) };

            // Aggiunta dell'oggetto appena creato alla collezione "People"
            People.Add(person);

            // Azzeramento della proprietà "Text"
            Text = null;
        }
    }

}
