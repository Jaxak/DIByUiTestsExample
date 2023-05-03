using System;
using DiExample.Examples.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DiExample.Examples;

public class Examples_AddSingleton : Base
{
    [Test]
    public void DiTest_AddSingleton()
    {
        var text = Guid.NewGuid().ToString();
        
        // Регистрируем контейнер 
        var container = new ServiceCollection()
            .AddSingleton<Token>() // 1 объект на весь проект
            .AddSingleton<ConsoleWriter>(_ => new ConsoleWriter(text))
            .BuildServiceProvider();

        // Берем из контейнера 2 разных экземпляра 1 объекта Token
        var tokenInstance1 = container.GetRequiredService<Token>();
        var tokenInstance2 = container.GetRequiredService<Token>();

        // Проверяем, что экземпляры одинаковые, потому что использовался Singleton
        Assert.AreEqual(tokenInstance1.Id, tokenInstance2.Id);
        
        // Для наглядности можно смотреть в консоль
        Log(nameof(tokenInstance1) + " -> " + tokenInstance1.Id);
        Log(nameof(tokenInstance2) + " -> " + tokenInstance2.Id);

        // Берем из контейнера 2 разных экземпляра 1 объекта ConsoleWriter
        var writerInstance1 = container.GetRequiredService<ConsoleWriter>();
        var writerInstance2 = container.GetRequiredService<ConsoleWriter>();

        // Проверяем, что экземпляры одинаковые, потому что использовался Singleton
        Assert.AreEqual(text, writerInstance1.Text);
        Assert.AreEqual(text, writerInstance2.Text);
        
        // Для наглядности можно смотреть в консоль
        writerInstance1.WriteText();
        writerInstance2.WriteText();
    }
}