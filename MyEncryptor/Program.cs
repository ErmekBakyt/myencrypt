var fullArr = new[]
{
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
    'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
    'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
    'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
    '+', '-', '&', '|', '!', '(', ')', '{', '}', '[', ']', '^', '~', '*', '?', ':'
};

var lowerArr = new[]
{
    'a', 'b', 'c', 'd',
    'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
    'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
};

var upperArr = new[]
{
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
    'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
};

var word = "salihcantekin";

var enc = Encrypt(word);

Console.WriteLine($"Enc: {enc}");

var dec = Decrypt(enc);

Console.WriteLine($"Dec: {dec}");

string Encrypt(string pass)
{
    var result = string.Empty;
    foreach (var ch in pass)
    {
        string midValue, prefix, suffix;

        var randomNum1 = new Random().Next(fullArr.Length);
        var randomNum2 = new Random().Next(lowerArr.Length);

        var charIndex = Array.IndexOf(fullArr, ch);

        if (randomNum1 > charIndex)
        {
            prefix = (randomNum1 - charIndex).ToString();
            
            midValue = lowerArr[randomNum2] + (prefix.Length + 1).ToString();
            midValue += prefix + fullArr[randomNum1];

            result += midValue;
        }
        else
        {
            suffix = (charIndex - randomNum1).ToString();
            
            midValue = upperArr[randomNum2] + (suffix.Length + 1).ToString();
            midValue += fullArr[randomNum1] + suffix;

            result += midValue;
        }
    }

    return result;
}

string Decrypt(string pass)
{
    var result = string.Empty;

    while (true)
    {
        var lengthNumber = (int.Parse(pass[1].ToString()) + 2);
        var part = pass[..lengthNumber];

        var chIndex = -1;

        if (lowerArr.Contains(part[0]))
        {
            var keyChar = part[^1];
            chIndex = Array.IndexOf(fullArr, keyChar);
            chIndex -= int.Parse(part[2..^1]);
            result += fullArr[chIndex];
        }
        else if (upperArr.Contains(part[0]))
        {
            var keyChar = part[2];
            chIndex = Array.IndexOf(fullArr, keyChar);
            chIndex += int.Parse(part[3..]);
            result += fullArr[chIndex];
        }

        pass = pass.Remove(0, lengthNumber);
        if (pass.Length <= 2)
        {
            break;
        }
    }

    return result;
}


Console.WriteLine("Hello, World!");