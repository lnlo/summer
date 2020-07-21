using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class help : MonoBehaviour
{
    public GameObject button;
    public Text helpText;
    bool isPushed;

    void OnMouseDown()
    {
        if (isPushed)
            helpText.text = "";
        else
            helpText.text = "Приветики! Не понимаешь, что происходит? Сейчас объясню. Меня зовут Джейс," +
                            " и я здесь для того, чтобы разрядить обстановку во время решения задач. Смотри, " +
                            "часы сверху показывают время, за которое ты решишь 5 задач (для запуска нажми на них). " +
                            "Вводи ответ в виде обыкновенной дроби!" +
                            "На белой закладке написано количество решенных задач. Нажми на красную, если хочешь " +
                            "вернуться в меню и выбрать другой тип задач. Удачки";
        isPushed = !isPushed;
    }
}
