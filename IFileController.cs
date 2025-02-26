using System;

public interface IFileController
{
    void WriteToFile(string path, string content);
    string ReadFromFile(string path);
    void AppendToFile(string path, string content);
    void EditFile(string path, string newContent);
    void DeleteFile(string path);
}