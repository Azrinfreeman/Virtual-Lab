using System;
using System.Linq;
using NUnit.Framework;

public class OfflineChatTests
{
    private static string Reply(string question)
    {
        var type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType("OpenAI.ChatGPT"))
            .First(t => t != null);
        return (string)type.GetMethod("DemoAnswer").Invoke(null, new object[] { question });
    }

    [Test]
    public void DemoAnswersSupportedQuestionsWithoutCredentials()
    {
        StringAssert.Contains("maltosa", Reply("  APAKAH FUNGSI AMILASE?  "));
        StringAssert.Contains("DCPIP", Reply("Apakah fungsi vitamin C?"));
        StringAssert.Contains("separuh", Reply("Bagaimana Pinggan Sihat Malaysia?"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("Topik yang tidak disokong")]
    public void UnsupportedQuestionDisclosesOfflineDemo(string question)
    {
        StringAssert.Contains("demo luar talian", Reply(question));
    }
}
