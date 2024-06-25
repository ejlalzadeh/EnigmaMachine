namespace Domain.Model;

public class Plugboard
{
    private Letter _a = new('A');
    private Letter _b = new('B');
    private Letter _c = new('C');
    private Letter _d = new('D');
    private Letter _e = new('E');
    private Letter _f = new('F');
    private Letter _g = new('G');
    private Letter _h = new('H');
    private Letter _i = new('I');
    private Letter _j = new('J');
    private Letter _k = new('K');
    private Letter _l = new('L');
    private Letter _m = new('M');
    private Letter _n = new('N');
    private Letter _o = new('O');
    private Letter _p = new('P');
    private Letter _q = new('Q');
    private Letter _r = new('R');
    private Letter _s = new('S');
    private Letter _t = new('T');
    private Letter _u = new('U');
    private Letter _v = new('V');
    private Letter _w = new('W');
    private Letter _x = new('X');
    private Letter _y = new('Y');
    private Letter _z = new('Z');

    private List<Wire> _wires = new(10)
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
        if (!TryConvertCharToLetter(input, out Letter letter))
            return input.ToString();

        return letter.Translate();
    }

    private void WireUp(string wirePairs)
    {
        ValidateWirePairs(wirePairs);

        while (wirePairs.Any())
        {
            if (_wires.Any())
            {
                Wire wire = _wires.First();

                TryConvertCharToLetter(wirePairs[0], out Letter leftSideLetter);
                wire.ConnectToLefSide(leftSideLetter);

                TryConvertCharToLetter(wirePairs[1], out Letter rightSideLetter);
                wire.ConnectToRightSide(rightSideLetter);

                _wires.Remove(wire);
                wirePairs = wirePairs.Remove(0, 2);
            }
            else
            {
                throw new InvalidOperationException("There are no wires left");
            }
        }
    }

    private void ValidateWirePairs(string wirePairs)
    {
        if (wirePairs.Length % 2 != 0)
            throw new InvalidOperationException("Invalid wire pairs configuration");

        foreach (char letterAsCharacter in wirePairs)
        {
            if (!TryConvertCharToLetter(letterAsCharacter, out Letter _))
                throw new InvalidOperationException("Invalid letter in wire pairs");
        }
    }

    private bool TryConvertCharToLetter(char letterAsCharacter, out Letter letter)
    {
        switch (letterAsCharacter)
        {
            case 'A':
                letter = _a;
                return true;
            case 'B':
                letter = _b;
                return true;
            case 'C':
                letter = _c;
                return true;
            case 'D':
                letter = _d;
                return true;
            case 'E':
                letter = _e;
                return true;
            case 'F':
                letter = _f;
                return true;
            case 'G':
                letter = _g;
                return true;
            case 'H':
                letter = _h;
                return true;
            case 'I':
                letter = _i;
                return true;
            case 'J':
                letter = _j;
                return true;
            case 'K':
                letter = _k;
                return true;
            case 'L':
                letter = _l;
                return true;
            case 'M':
                letter = _m;
                return true;
            case 'N':
                letter = _n;
                return true;
            case 'O':
                letter = _o;
                return true;
            case 'P':
                letter = _p;
                return true;
            case 'Q':
                letter = _q;
                return true;
            case 'R':
                letter = _r;
                return true;
            case 'S':
                letter = _s;
                return true;
            case 'T':
                letter = _t;
                return true;
            case 'U':
                letter = _u;
                return true;
            case 'V':
                letter = _v;
                return true;
            case 'W':
                letter = _w;
                return true;
            case 'X':
                letter = _x;
                return true;
            case 'Y':
                letter = _y;
                return true;
            case 'Z':
                letter = _z;
                return true;
            default:
                letter = null;
                return false;
        }
    }
}