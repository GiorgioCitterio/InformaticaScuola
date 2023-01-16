using _11_EsempioMVVM.Model;
namespace _11_EsempioMVVM.ViewModel
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; } = new List<Person>();
        public PeopleViewModel() 
        {
            People.Add(new Person() { Name = "Mario", Age = 20, Weight = 40 });
            People.Add(new Person() { Name = "Giacomo", Age = 45, Weight = 75 });
            People.Add(new Person() { Name = "Pippo", Age = 80, Weight = 80 });
            People.Add(new Person() { Name = "Francesco", Age = 28, Weight = 55 });
            People.Add(new Person() { Name = "Pluto", Age = 33, Weight = 60 });
            People.Add(new Person() { Name = "Mario", Age = 20, Weight = 40 });
            People.Add(new Person() { Name = "Giacomo", Age = 45, Weight = 75 });
            People.Add(new Person() { Name = "Pippo", Age = 80, Weight = 80 });
            People.Add(new Person() { Name = "Francesco", Age = 28, Weight = 55 });
            People.Add(new Person() { Name = "Pluto", Age = 33, Weight = 60 });
        }
    }
}
