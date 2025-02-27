public interface IJsonController
{
    void WriteJsonToFile(string path, Person person);
    List<Person> ReadJsonFromFile(string path);
    void EditJsonFile(string path, string id, string newName, int newAge);
    void DeleteJsonFile(string path, string id);
}
