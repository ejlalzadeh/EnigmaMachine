namespace Domain.Model;

public class Plugboard
{
    private readonly Letter _a = new('A');
    private readonly Letter _b = new('B');
    private readonly Letter _c = new('C');
    private readonly Letter _d = new('D');
    private readonly Letter _e = new('E');
    private readonly Letter _f = new('F');
    private readonly Letter _g = new('G');
    private readonly Letter _h = new('H');
    private readonly Letter _i = new('I');
    private readonly Letter _j = new('J');
    private readonly Letter _k = new('K');
    private readonly Letter _l = new('L');
    private readonly Letter _m = new('M');
    private readonly Letter _n = new('N');
    private readonly Letter _o = new('O');
    private readonly Letter _p = new('P');
    private readonly Letter _q = new('Q');
    private readonly Letter _r = new('R');
    private readonly Letter _s = new('S');
    private readonly Letter _t = new('T');
    private readonly Letter _u = new('U');
    private readonly Letter _v = new('V');
    private readonly Letter _w = new('W');
    private readonly Letter _x = new('X');
    private readonly Letter _y = new('Y');
    private readonly Letter _z = new('Z');

    private readonly List<Wire> _wires = new(10)
    {
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire(),
        new Wire()
    };

    public Plugboard() { }

    public Plugboard(string pairs)
    {
        if (!string.IsNullOrWhiteSpace(pairs))
            WireUp(pairs);
    }

    public string Process(char input)
    {
        try
        {
            Letter letter = ConvertCharToLetter(input);

            return letter.Translate();
        }
        catch (ArgumentException)
        {
            return input.ToString();
        }
    }

    private void WireUp(string pairs)
    {
        if (pairs.Length % 2 != 0)
            throw new InvalidOperationException("Invalid pairing configuration");

        while (pairs.Any())
        {
            if (_wires.Any())
            {
                Wire wire = _wires.First();
                Letter left = ConvertCharToLetter(pairs[0]);
                Letter right = ConvertCharToLetter(pairs[1]);

                wire.Connect(left, right);

                _wires.Remove(wire);
                pairs = pairs.Remove(0, 2);
            }
            else
            {
                throw new InvalidOperationException("There are no wires left");
            }
        }
    }

    private Letter ConvertCharToLetter(char letterAsCharacter)
    {
        return letterAsCharacter switch
        {
            'A' => _a,
            'B' => _b,
            'C' => _c,
            'D' => _d,
            'E' => _e,
            'F' => _f,
            'G' => _g,
            'H' => _h,
            'I' => _i,
            'J' => _j,
            'K' => _k,
            'L' => _l,
            'M' => _m,
            'N' => _n,
            'O' => _o,
            'P' => _p,
            'Q' => _q,
            'R' => _r,
            'S' => _s,
            'T' => _t,
            'U' => _u,
            'V' => _v,
            'W' => _w,
            'X' => _x,
            'Y' => _y,
            'Z' => _z,
            _ => throw new ArgumentException("Invalid letter", nameof(letterAsCharacter))
        };
    }
}

internal class Letter
{
    private readonly char _name;
    private Letter? _connectedLetter;

    public Letter(char name)
    {
        _name = name;
        _connectedLetter = null;
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


internal class Wire
{
    private Letter? _leftLetter;
    private Letter? _rightLetter;

    public Wire()
    {
        _leftLetter = null;
        _rightLetter = null;
    }

    public void Connect(Letter leftLetter, Letter rightLetter)
    {
        _leftLetter = leftLetter;
        _rightLetter = rightLetter;

        _leftLetter.Connect(_rightLetter);
        _rightLetter.Connect(_leftLetter);
    }
}