using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Text;

public class mem : MonoBehaviour
{
    public Text question;
    public double probability;

    void OnMouseDown()
    {
        var tuple = MakeText();
        question.text = tuple.Item2;
        probability = tuple.Item1;
    }

    Tuple<double, string> MakeText()
    {
        var text = new StringBuilder();
        var counts = new List<int>();
        var rnd = new System.Random();
        var total = 0;
        for (var i = 0; i < 3; i++)
        {
            var next = rnd.Next(1, 11);
            counts.Add(next);
            total += next;
        }
        var ends = new List<string>();
        for (var i = 0; i < 3; i++)
        {
            if (counts[i] == 1)
                ends.Add("МЕМ");
            else if (counts[i] >= 2 && counts[i] <= 4)
                ends.Add("МЕМА");
            else if (counts[i] >= 5 && counts[i] <= 10)
                ends.Add("МЕМОВ");
        }
        text.Append($"САША ОТПРАВИЛ МАШЕ {counts[0]} {ends[0]} С ВОЛКАМИ, {counts[1]} {ends[1]} ПРО УНИВЕРСИТЕТ И {counts[2]} {ends[2]} ПРО ПОДРОСТКОВ. ");

        var choice = 0;
        if (total < 4)
            choice = rnd.Next(1, total);
        else
            choice = rnd.Next(2, 5);
        text.Append($"МАША НАУГАД ВЫБИРАЕТ {choice} МЕМА. ");

        var order = new string[] { "ПЕРВЫЙ", "ВТОРОЙ", "ТРЕТИЙ", "ЧЕТВЕРТЫЙ" };
        var kinds = new string[] { "С ВОЛКОМ", "ПРО УНИВЕРСИТЕТ", "ПРО ПОДРОСТКОВ" };
        var mem = rnd.Next(0, 3);
        var positive = mem;
        text.Append($"КАКОВА ВЕРОЯТНОСТЬ ТОГО, ЧТО {order[choice - 1]} МЕМ - {kinds[mem]}, ");
        counts[positive] -= 1;
        var j = -1;
        while (j < choice - 1)
        {
            mem = rnd.Next(0, 3);
            if (counts[mem] == 0)
                continue;
            else
                counts[mem] -= 1;
            j++;
            if (j == 0)
                text.Append("ЕСЛИ ");
            if (j == choice - 2)
            {
                text.Append($"{order[j]} МЕМ - {kinds[mem]}?");
                break;
            }

            text.Append($"{order[j]} МЕМ - {kinds[mem]}, ");
        }
        counts[positive] += 1;
        var probability = 1.0 * counts[positive] / (total - choice + 1);
        var resText = text.ToString();
        var result = new Tuple<double, string>(probability, resText);
        return result;
    }
}
