using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;


public class money : MonoBehaviour
{
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
        var rnd = new System.Random();
        var groups = rnd.Next(2, 8);
        var avaible = rnd.Next(2, 4);
        var stdntsInGroup = 0;
        while (stdntsInGroup < avaible)
            stdntsInGroup = rnd.Next(2, 9);
        var total = groups * stdntsInGroup;
        text.Append($"В {groups} АКАДЕМИЧЕСКИХ ГРУППАХ ЕСТЬ ПО {stdntsInGroup} ЖЕЛАЮЩИХ ПЕРЕВЕСТИСЬ НА БЮДЖЕТ, ОДНАКО ЕСТЬ ТОЛЬКО {avaible} БЮДЖЕТНЫХ МЕСТА. КАКОВА ВЕРОЯТНОСТЬ ТОГО, ЧТО ВСЕ БЮДЖЕТНЫЕ МЕСТА ЗАЙМУТ СТУДЕНТЫ ИЗ ОДНОЙ ГРУППЫ?");

        var probability = 1.0;
        for (var i = 0; i < avaible; i++)
            probability *= 1.0 * (stdntsInGroup - i) / (total - i);
        probability *= groups;
        var resText = text.ToString();
        var result = new Tuple<double, string>(probability, resText);
        return result;
    }
}
