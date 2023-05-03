using DiExample.Examples.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DiExample.Examples;

public class Ulern_Test
{
    [Test]
    public void DiTest_AddScoped_And_Singleton_UseCommonToken()
    {
        var container = new ServiceCollection()
            .AddScoped<Token>()
            .AddScoped<ConsoleTokenWriter1>()
            .AddScoped<ConsoleTokenWriter2>()
            .BuildServiceProvider();

        var sp1 = container.CreateScope().ServiceProvider;
        var sp2 = container.CreateScope().ServiceProvider;

        Assert.AreEqual(
            sp1.GetRequiredService<ConsoleTokenWriter1>().Text,
            sp2.GetRequiredService<ConsoleTokenWriter1>().Text
        );
    }

    [Test]
    public void DiTest_AllAddScoped_UseRandomToken()
    {
        var container = new ServiceCollection()
            .AddScoped<Token>()
            .AddScoped<ConsoleTokenWriter1>()
            .AddScoped<ConsoleTokenWriter2>()
            .BuildServiceProvider();

        var sp1 = container.CreateScope().ServiceProvider;
        var sp2 = container.CreateScope().ServiceProvider;

        var instance_1_1 = sp1.GetRequiredService<ConsoleTokenWriter1>();
        var instance_2_1 = sp2.GetRequiredService<ConsoleTokenWriter1>();
        var instance_2_2 = sp2.GetRequiredService<ConsoleTokenWriter2>();

        Assert.Multiple(() =>
            {
                Assert.AreEqual(instance_1_1, instance_2_1);
                Assert.AreEqual(instance_2_1, instance_2_2);
                Assert.AreEqual(instance_1_1, instance_2_2);
            }
        );
    }
}