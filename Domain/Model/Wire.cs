namespace Domain.Model;

internal class Wire
{
    private Letter? _leftSideLetter = null;
    private Letter? _rightSideLetter = null;
    private bool _fullyConnected = false;

    public void ConnectToLefSide(Letter letter)
    {
        _leftSideLetter = letter;
        _leftSideLetter.SetConnectedWire(this);

        _fullyConnected = _rightSideLetter is not null;
    }

    public void ConnectToRightSide(Letter letter)
    {
        _rightSideLetter = letter;
        _rightSideLetter.SetConnectedWire(this);

        _fullyConnected = _leftSideLetter is not null;
    }

    public Letter GetOtherSide(Letter letter)
    {
        if (!_fullyConnected)
            throw new InvalidOperationException("The wire is not fully connected");

        return letter == _leftSideLetter ? _rightSideLetter! : _leftSideLetter!;
    }
}