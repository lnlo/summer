using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class socks : MonoBehaviour
{
    /*public Text question;
    public double probability;

    void OnMouseDown()
    {
        var tuple = MakeText();
        question.text = tuple.Item2;
        probability = tuple.Item1;
    }*/
    public Text question;
    public double probability;
    public GameObject inputField;
    bool isStarted;
    public Text clockText;
    public Text totalCountText;
    public Text pointsText;

    void OnMouseDown()
    {
        if (isStarted)
        {
            clockText.GetComponent<clock>().isStarted = false;
            isStarted = false;
        }
        else
        {
            totalCountText.text = $"0/5";
            pointsText.text = "";
            clockText.GetComponent<clock>().isStarted = true;
            clockText.GetComponent<clock>().seconds = 0;
            MakeNew();
        }
    }

    public void MakeNew()
    {
        isStarted = true;
        inputField.GetComponent<Compare>().isNew = true;
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
        for (var i = 0; i < 2; i++)
        {
            var next = rnd.Next(3, 11);
            counts.Add(next);
            total += next;
        }
        var ends = new List<string>();
        for (var i = 0; i < 2; i++)
        {
            if (counts[i] == 3 || counts[i] == 4)
                ends.Add("ПАРЫ");
            else if (counts[i] >= 5 && counts[i] <= 10)
                ends.Add("ПАР");
        }
        text.Append($"САША КУПИЛ {counts[0]} {ends[0]} НОСКОВ С ПАНДАМИ И {counts[1]} {ends[1]} ОДНОТОННЫХ НОСКОВ. ПО ОЧЕРЕДИ МАША И ДАША СЛУЧАЙНЫМ ОБРАЗОМ ВЫБИРАЮТ ПО ОДНОЙ ПАРЕ НОСКОВ.  ");
        var kinds = new string[] { "НОСКИ С ПАНДОЙ", "ОДНОТОННЫЕ НОСКИ" };
        var kindM = rnd.Next(0, 2);
        var kindD = rnd.Next(0, 2);
        var probability = 1.0;
        if (kindD == kindM)
        {
            text.Append($"КАКОВА ВЕРОЯТНОСТЬ ТОГО, ЧТО МАШЕ И ДАШЕ ДОСТАНУТСЯ {kinds[kindM]}?");
            probability = (1.0 * counts[kindM] / total) * (1.0 * (counts[kindM] - 1) / (total - 1));
        }

        else
        {
            text.Append($"КАКОВА ВЕРОЯТНОСТЬ ТОГО, ЧТО МАШЕ ДОСТАНУТСЯ {kinds[kindM]}, А ДАШЕ {kinds[kindD]}?");
            probability = (1.0 * counts[kindM] / total) * (1.0 * counts[kindD] / (total - 1));
        }
        var resText = text.ToString();
        var result = new Tuple<double, string>(probability, resText);
        return result;
    }
}
