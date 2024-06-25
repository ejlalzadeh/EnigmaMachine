namespace Domain.Model;

internal class Letter
{
    private readonly char _name;
    private Letter? _connectedLetter = null;

    public Letter(char name)
    {
        _name = name;
    }

    public void Connect(Letter connectedLetter)
    {
        if (_connectedLetter is not null)
            throw new InvalidOperationException($"The letter {_name} is already connected to another letter.");

        _connectedLetter = connectedLetter;
    }

    public string Translate()
    {
        if (_connectedLetter is null)
            return _name.ToString();

        return _connectedLetter._name.ToString();
    }
}