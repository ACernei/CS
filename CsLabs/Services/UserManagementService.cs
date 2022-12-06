namespace Services;

public class UserManagementService
{
    private readonly Dictionary<string, string> database;
    private readonly Hash hash;

    public UserManagementService()
    {
        this.database = new Dictionary<string, string>();
        this.hash = new Hash();
    }

    public void CreateUser(string username, string password)
    {
        if (database.ContainsKey(username))
            Console.WriteLine("Username already exists");

        database[username] = hash.CreateHash(password);
    }

    public bool IsValid(string usernameInput, string  passwordInput)
    {
        if (database.ContainsKey(usernameInput))
            return database[usernameInput] == hash.CreateHash(passwordInput);
        return false;
    }
}
