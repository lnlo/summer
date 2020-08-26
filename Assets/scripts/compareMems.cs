using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class compareMems : MonoBehaviour
{
    int testing;
    public InputField field;
    public GameObject button;
    public Text totalCountText;
    int count = 0;
    public bool isNew;
    int totalQuestionsCount = 5;
    public Text clockText;
    public Text question;
    public Text points;
    int currientPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        totalCountText.text = $"{count}/{totalQuestionsCount}";
    }

    public void Change()
    {
        if (!isNew)
            return;
        var input = field.text;
        try
        {
            var abc = input.Split('/');
            testing++;
            var res = 1.0 * Convert.ToInt32(abc[0]) / Convert.ToInt32(abc[1]);
            testing++;
            if (Math.Round(button.GetComponent<mem>().probability, 3) == Math.Round(res, 3))
            {
                field.text = "";
                isNew = false;
                count++;
                if (count == totalQuestionsCount)
                {
                    clockText.GetComponent<clock>().isStarted = false;
                    question.text = "";
                    count = 0;
                    totalCountText.text = "";
                    if (currientPoints <= 40)
                        points.text = "40/100";
                    else
                        points.text = $"{currientPoints}/100";
                    return;
                }
                else
                    button.GetComponent<mem>().MakeNew();
                totalCountText.text = $"{count}/{totalQuestionsCount}";
            }
            else
            {
                field.text = "Неверно(";
                currientPoints -= 5;
            }
        }
        catch (Exception)
        {
            field.text = testing.ToString();
            return;
        }
       /* field.text = "Неверно(";
        currientPoints -= 5;*/
    }

}
