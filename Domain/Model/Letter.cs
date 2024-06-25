namespace Domain.Model;

internal class Letter
{
    private readonly char _name;
    private Wire? _connectedWire = null;

    public Letter(char name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name.ToString();
    }

    public void SetConnectedWire(Wire wire)
    {
        if (_connectedWire is not null)
            throw new InvalidOperationException($"The letter {_name} is already connected to another wire.");

        _connectedWire = wire;
    }

    public string Translate()
    {
        if (_connectedWire is null)
            return this.GetName();

        Letter letterConnectedByWire = _connectedWire.GetOtherSide(this);
        return letterConnectedByWire.GetName();
    }
}