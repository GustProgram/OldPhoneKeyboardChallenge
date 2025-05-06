using System;
using System.Collections.Generic;
using System.Text;

public class OldPhonePadDecoder
{
    /// <summary>
    /// imitates sequence of keypresses from an old phone keypad to letters.
    ///1: (special characters, ignored)
    ///2: A B C
    ///3: D E F
    ///4: G H I
    ///5: J K L
    ///6: M N O
    ///7: P Q R S
    ///8: T U V
    ///9: W X Y Z
    ///0: (space)
    /// Rules:
    /// - Repeated digits map to letters (e.g. "222" -> 'C')
    /// - A space " " separates different characters from the same button
    /// - "*" acts as a backspace, removing the last added letter
    /// - Input must end with "#", which signals "send"
    /// </summary>
    /// <param name="input">Key press sequence string</param>
    /// <returns>Decoded string</returns>
    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrWhiteSpace(input) || !input.EndsWith("#"))
            return "";

        // Mapping of digits to corresponding letters
        Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            { '1', "" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        StringBuilder result = new StringBuilder();
        StringBuilder currentGroup = new StringBuilder();



        // Remove trailing '#' (send key)
        input = input.Substring(0, input.Length - 1);

        foreach (char c in input)
        {
            if (c == ' ')
            {
                ProcessGroup(currentGroup.ToString(), keypad, result);
                currentGroup.Clear();
            }
            else if (c == '*')
            {
                ProcessGroup(currentGroup.ToString(), keypad, result);
                currentGroup.Clear();
                if (result.Length > 0)
                    result.Remove(result.Length - 1, 1);
            }
            else
            {
                // Digit
                if (currentGroup.Length > 0 && currentGroup[0] != c)
                {
                    ProcessGroup(currentGroup.ToString(), keypad, result);
                    currentGroup.Clear();
                }
                currentGroup.Append(c);
            }
        }

        // Process final group
        if (currentGroup.Length > 0)
            ProcessGroup(currentGroup.ToString(), keypad, result);

        return result.ToString();
    }

    /// <summary>
    /// Converts the sequence of keypresses like "7777" to the correct letter ('S')
    /// </summary>
    private static void ProcessGroup(string group, Dictionary<char, string> keypad, StringBuilder result)
    {
        if (string.IsNullOrEmpty(group))
            return;

        char key = group[0];
        int pressCount = group.Length;

        if (!keypad.ContainsKey(key) || keypad[key].Length == 0)
            return;

        string letters = keypad[key];
        int index = (pressCount - 1) % letters.Length;
        result.Append(letters[index]);
    }
}


class Program
{
    static void Main()
    {

        Console.WriteLine(OldPhonePadDecoder.OldPhonePad(""));
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("33#")); // E
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("227*#")); // B
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("4433555 555666#")); // HELLO
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("8 88777444666*664#")); // THINE
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("444 777 666 66#"));  // retorna "IRON"
        Console.WriteLine(OldPhonePadDecoder.OldPhonePad("4 88 7777 8 2 888 666 0 3 2 0 7777 444 555 888 2 0 7777 2 66 8 666 7777#"));

    }
}
