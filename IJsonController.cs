public interface IJsonController
{
    void WriteJsonTofile(string path, Person person);
    Person ReadJsonFromFile(string path);
    void EditJsonFile(string path, Person updatedPerson);
    void DeleteJsonFile(string path);

}