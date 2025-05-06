using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class OldPhonePadDecoderTests
{
    [TestMethod]
    public  void Test_EmptyInput_ReturnsEmptyString()
    {
        string input = "";
        string expected = "";
        Console.WriteLine($"Running Test_EmptyInput_ReturnsEmptyString with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_SingleKeyPress_ReturnsCorrectLetter()
    {
        string input = "33#";
        string expected = "E";
        Console.WriteLine($"Running Test_SingleKeyPress_ReturnsCorrectLetter with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Backspace_RemovesLastCharacter()
    {
        string input = "227*#";
        string expected = "B";
        Console.WriteLine($"Running Test_Backspace_RemovesLastCharacter with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_MultipleKeyPressesWithSpaces_ReturnsCorrectString()
    {
        string input = "4433555 555666#";
        string expected = "HELLO";
        Console.WriteLine($"Running Test_MultipleKeyPressesWithSpaces_ReturnsCorrectString with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_ComplexSequenceWithBackspace_ReturnsCorrectString()
    {
        string input = "9 666 777 555 3*3#"; // 9=W, 666=O, 777=R, 555=L, 3=D (with backspace removing the first D)
        string expected = "WORLD";
        Console.WriteLine($"Running Test_ComplexSequenceWithBackspace_ReturnsWorld with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_SequenceWithSpaces_ReturnsCorrectString()
    {
        string input = "444 777 666 66#";
        string expected = "IRON";
        Console.WriteLine($"Running Test_SequenceWithSpaces_ReturnsCorrectString with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_LongSequence_ReturnsCorrectString()
    {
        string input = "4 88 7777 8 2 888 666 0 3 2 0 7777 444 555 888 2 0 7777 2 66 8 666 7777#";
        string expected = "GUSTAVO DA SILVA SANTOS";
        Console.WriteLine($"Running Test_LongSequence_ReturnsCorrectString with input: '{input}'");
        string result = OldPhonePadDecoder.OldPhonePad(input);
        Console.WriteLine($"Expected: '{expected}', Actual: '{result}'");
        Assert.AreEqual(expected, result);
    }
}