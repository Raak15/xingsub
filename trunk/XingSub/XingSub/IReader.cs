namespace XingSub
{
    interface IReader
    {
        string Convert(string pathToRead, string pathToSaveHeader);
        string Descriptions();
        string Extension();
        bool IsEffects();
        bool HasHeader();
    }
}
