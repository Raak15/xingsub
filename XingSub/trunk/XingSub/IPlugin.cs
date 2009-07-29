namespace XingSub
{
    public interface IPlugin
    {
        int Convert(string input, string path);
        string Descriptions();
        string Extension();
        bool IsEffects();
    }
}
