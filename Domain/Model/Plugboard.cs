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

                Letter leftSideLetter = ConvertCharToLetter(pairs[0]);
                wire.ConnectToLefSide(leftSideLetter);

                Letter rightSideLetter = ConvertCharToLetter(pairs[1]);
                wire.ConnectToRightSide(rightSideLetter);

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