using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

public class ScoringAndPlateTests
{
    private static Type GameType(string name)
    {
        return AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(name))
            .First(t => t != null);
    }

    [TestCase("KuizController", "soalanAnswer", "checkAnswers", "scores", 3)]
    [TestCase("KuizController", "soalanAnswer", "checkAnswers5Q", "scores", 6)]
    [TestCase("KeputusanController", "Jawapan", "CheckAnswer", "score", 3)]
    public void RepeatedSubmissionRecalculatesCurrentAnswers(string typeName, string answers,
        string methodName, string score, int expected)
    {
        var go = new GameObject("Regression test");
        try
        {
            var type = GameType(typeName);
            var component = go.AddComponent(type);
            var values = new[] { true, false, true, false, true };
            type.GetField(answers).SetValue(component, values);
            type.GetField(score).SetValue(component, 99);
            var method = type.GetMethod(methodName);
            for (int i = 0; i < 3; i++) method.Invoke(component, null);
            Assert.That(type.GetField(score).GetValue(component), Is.EqualTo(expected));
            values[0] = false;
            method.Invoke(component, null);
            Assert.That(type.GetField(score).GetValue(component), Is.EqualTo(expected * 2 / 3));
            Array.Clear(values, 0, values.Length);
            method.Invoke(component, null);
            Assert.That(type.GetField(score).GetValue(component), Is.EqualTo(0));
            for (int i = 0; i < values.Length; i++) values[i] = true;
            method.Invoke(component, null);
            Assert.That(type.GetField(score).GetValue(component), Is.EqualTo(expected == 6 ? 10 : 5));
        }
        finally { UnityEngine.Object.DestroyImmediate(go); }
    }

    [Test]
    public void PlateAcceptsExactlyFourCompleteUniqueArrangements()
    {
        var method = GameType("PingganSihatMalaysiaController").GetMethod("IsCorrectArrangement",
            BindingFlags.Public | BindingFlags.Static);
        string[] foods = { "IKAN", "NASI", "BUAH", "SAYUR", "", "UNKNOWN", null };
        int accepted = 0;
        foreach (string a in foods) foreach (string b in foods)
        foreach (string c in foods) foreach (string d in foods)
        {
            bool expected = ((a == "IKAN" && b == "NASI") || (a == "NASI" && b == "IKAN"))
                && ((c == "BUAH" && d == "SAYUR") || (c == "SAYUR" && d == "BUAH"));
            bool actual = (bool)method.Invoke(null, new object[] { a, b, c, d });
            Assert.That(actual, Is.EqualTo(expected), $"{a}/{b}/{c}/{d}");
            if (actual) accepted++;
        }
        Assert.That(accepted, Is.EqualTo(4));
        Assert.That(method.Invoke(null, new object[] { " ikan ", "nasi", "buah", "SAYUR" }), Is.True);
    }
}
