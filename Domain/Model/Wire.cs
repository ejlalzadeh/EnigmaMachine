namespace Domain.Model;

internal class Wire
{
    private Letter? _leftLetter = null;
    private Letter? _rightLetter = null;

    public void ConnectLetters(Letter leftLetter, Letter rightLetter)
    {
        _leftLetter = leftLetter;
        _rightLetter = rightLetter;

        _leftLetter.Connect(_rightLetter);
        _rightLetter.Connect(_leftLetter);
    }
}