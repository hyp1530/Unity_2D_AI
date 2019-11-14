using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnSwitch : MonoBehaviour
{
    public string myColor = "黑色";

    public enum season
    {
        spring, summer, fall, winter
    }
    public season _season = season.fall;

    private void Start()
    {
        if (myColor == "黑色")
        {
            print("玩家輸入的是黑色");
        }
        else if (myColor == "白色")
        {
            print("玩家輸入的是白色");
        }

    }
    
}
