using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public int level;
    public int exprience;
    public float CurrentExprience;

    public int exprienceNeededToLevelUp;
    public Image ImgXPBar;
    public Text txtXP;
    public Text txtLevel;

    public LevelUpMenu myMenu;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        exprience = 0;
        exprienceNeededToLevelUp = 10;

        CurrentExprience = (float)exprience / (float)exprienceNeededToLevelUp;
        txtXP.text = string.Format("{0} %", Mathf.RoundToInt(CurrentExprience * 100));
        ImgXPBar.fillAmount = CurrentExprience;

        txtLevel.text = "Level: " + level.ToString();
    }

    // Incease level
    void IncreaseLevel()
    {
        exprience = 0;
        CurrentExprience = (float)exprience / (float)exprienceNeededToLevelUp;
        txtXP.text = string.Format("{0} %", Mathf.RoundToInt(CurrentExprience * 100));
        ImgXPBar.fillAmount = CurrentExprience;

        exprienceNeededToLevelUp += 10;

        level += 1;
        txtLevel.text = "Level: " + level.ToString();

        
        myMenu.LevelUpMenuActivate();

    }

    void Update()
    {
        // when exp reach the requirment, will level up
        if(exprience == exprienceNeededToLevelUp)
        {
            IncreaseLevel();
        }

        // Level up test code
        if(Input.GetKeyDown(KeyCode.F))
        {
            exprience += 2;
            CurrentExprience = (float)exprience / (float)exprienceNeededToLevelUp;
            txtXP.text = string.Format("{0} %", Mathf.RoundToInt(CurrentExprience * 100));
            ImgXPBar.fillAmount = CurrentExprience;
        }
    }

    // Gain EXP
    public void GainExp(int value)
    {
        exprience += value;
    }
}
