using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text _mainText;

    private enum Chapters { start, forest, path_1, path_2, path_3, lion, snake, river, garden };
    private Chapters _presentChapter;

    // Start is called before the first frame update
    void Start()
    {

        _presentChapter = Chapters.start;
    }

    // Update is called once per frame
    void Update()
    {
        if (_presentChapter == Chapters.start)
        {
            ChapterStart();
        }
        else if (_presentChapter == Chapters.forest)
        {
            ChapterForest();
        }
        else if (_presentChapter == Chapters.path_1)
        {
            ChapterPath1();
        }
        else if (_presentChapter == Chapters.path_2)
        {
            ChapterPath2();
        }
        else if (_presentChapter == Chapters.path_3)
        {
            ChapterPath3();
        }
        else if (_presentChapter == Chapters.lion)
        {
            ChapterLion();
        }
        else if (_presentChapter == Chapters.snake)
        {
            ChapterSnake();
        }
        else if (_presentChapter == Chapters.river)
        {
            ChapterRiver();
        }
        else if (_presentChapter == Chapters.garden)
        {
            ChapterGarden();
        }

    }

    void ChapterGarden()
    {
        _mainText.text = "Look at this uniquely beautiful green garden.\n" +
            " The fruits look beautiful.\n" +
            " Eat it right away, because it can cut your stomach.\n" +
            " Feed your stomach with these fruits and quench your thirst with the water in them.\n" +
            "Press P for restart play";
        if (Input.GetKeyDown(KeyCode.P))
        {
            _presentChapter = Chapters.start;
        }
    }

    void ChapterRiver()
    {
        _mainText.text = " you tired but it was worth it. Look at that deep blue river.\n" +
            " Come on, drink water and have fun as you wish. " +
            "You might even catch fish to feed your stomach\n" +
            "Press P for restart play";
        if (Input.GetKeyDown(KeyCode.P))
        {
            _presentChapter = Chapters.start;
        }
    }

    void ChapterSnake()
    {
        _mainText.text = "Oh my god what a big snake this is.\n Run away before poisoning us.\n" +
            " Ahh! the snake attacked and you died unfortunately... \n" +
            "Press P for restart play";
        if (Input.GetKeyDown(KeyCode.P))
        {
            _presentChapter = Chapters.start;
        }
    }

    void ChapterLion()
    {
        _mainText.text = "Wow do you see the big lion.\n" +
            " It looks very strong and shouldn't notice us.\n" +
            " Let's go back. Run quickly noticed us.\n" +
            " But you couldn't escape from the lion.\n" +
            " A very bad death\n" +
            "Press P for restart play";

        if (Input.GetKeyDown(KeyCode.P))
        {
            _presentChapter = Chapters.start;
        }
    }

    void ChapterStart()
    {
        _mainText.text = " Hello, welcome to adventure game! \n Press enter to continue..  ";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _presentChapter = Chapters.forest;
        }
    }
    void ChapterForest()
    {
        _mainText.text = " It's so dark and scary. \n I guess this is the Dark Forest that doesn't fall out of those tongues." +
                " \n You're so hungry and thirsty.. \n There are 3 ways in front of you. You should trust your feelings and choose someone.." +
                "\n Press 1 for path 1, 2 for path 2, 3 for path 3...";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _presentChapter = Chapters.path_1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _presentChapter = Chapters.path_2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _presentChapter = Chapters.path_3;
        }


    }

    void ChapterPath1()
    {
        _mainText.text = "You are awesome first choices are always important.\n" +
            " You chose the first way. And what is that. road is divided into two here.\n" +
            "One of these ways leads to a lion and the other to a snake\n" +
            "What are you going to do?\n Press L for Lion, S for Snake Or Press B for return";

        if (Input.GetKeyDown(KeyCode.L))
        {
            _presentChapter = Chapters.lion;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _presentChapter = Chapters.snake;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            _presentChapter = Chapters.forest;
        }

    }
    void ChapterPath2()
    {
        _mainText.text = "You took the wrong path :( \n Don't worry, our mistakes shed light on finding the truth, now go back and try other ways.\n Press B to return";
        if (Input.GetKeyDown(KeyCode.B))
        {
            _presentChapter = Chapters.forest;
        }
    }
    void ChapterPath3()
    {
        _mainText.text = "Endless roads and long torture. I know you're tired. But there is a crossroads in front of you.\n" +
            "You are very hungry and thirsty.\n" +
            " Either you will go to the river and drink water or you will go to the garden and eat.\n" +
            " The decision is yours.What are you going to do?\n Press R for River, G for Garden Or Press B for return";

        if (Input.GetKeyDown(KeyCode.R))
        {
            _presentChapter = Chapters.river;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _presentChapter = Chapters.garden;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            _presentChapter = Chapters.forest;
        }
    }
}
