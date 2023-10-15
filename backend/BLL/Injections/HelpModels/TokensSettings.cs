namespace BLL.Injections.HelpModels;

public class TokensSettings
{
    public TokensSettings(string key, int expiryMinutes)
    {
        Key = key;
        ExpiryMinutes = expiryMinutes;
    }

    public string Key { get; set; }
    public int ExpiryMinutes { get; set; }
}