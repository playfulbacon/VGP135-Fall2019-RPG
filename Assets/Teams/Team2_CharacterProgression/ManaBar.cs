using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image ImgManaBar;
    public Text TxtMana;
    public int Min;
    public int Max;

    private int mCurrentValue;
    private float mCurrentPercent;

    public void setMana(int Mana)
    {
        if(Mana != mCurrentValue)
        {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = Mana;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtMana.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));
            ImgManaBar.fillAmount = mCurrentPercent;
        }
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue; }
    }

    // Start is called before the first frame update
    void Start()
    {
        setMana(100);
    }


}
