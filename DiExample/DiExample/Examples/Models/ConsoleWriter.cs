using NUnit.Framework;

namespace DiExample.Examples.Models;

public class ConsoleWriter
{
    public readonly string Text;

    public ConsoleWriter(string text)
    {
        Text = text;
        TestContext.Out.WriteLine($"Зарегестрировали {nameof(ConsoleWriter)} с текстом {Text}");
    }

    public void WriteText()
    {
        TestContext.Out.WriteLine($"В поле текст: {Text}");
    }
}