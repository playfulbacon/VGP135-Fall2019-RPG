using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum StatAdded
{
    Str,
    Int,
    Con,
    Dex,
    Wis
};

public class LevelUpMenu : MonoBehaviour
{
    public GameObject player;
    Stats stats;

    public static bool isPausedForLevelUp = false;

    public Text addStrength;
    public Text addIntelligence;
    public Text addConstitution;
    public Text addDexterity;
    public Text addWisdom;

    bool hasPoint = false;
    StatAdded pointSpend = StatAdded.Str;

    private void Start()
    {
        stats = player.GetComponent<Stats>();
    }

    public void Update()
    {
        /// Debug Purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUpMenuActivate();
        }
    }

    public void LevelUpMenuActivate()
    {
        Time.timeScale = 0.0f;
        isPausedForLevelUp = true;
        gameObject.SetActive(true);
        hasPoint = true;
    }

    public void AddStrengthButton()
    {
        if (hasPoint)
            addStrength.text = (stats.GetBaseStrength() + 1).ToString();
    }
    public void AddIntelligenceButton()
    {
        if(hasPoint)
        addIntelligence.text = (stats.GetBaseIntelligence() + 1).ToString();
    }
    public void AddConstitutionButton()
    {
        if(hasPoint)
        addConstitution.text = (stats.GetBaseConstitution() + 1).ToString();
    }
    public void AddDexterityButton()
    {
        if (hasPoint)
            addDexterity.text = (stats.GetBaseDexterity() + 1).ToString();
    }
    public void AddWisdomButton()
    {
        if (hasPoint)
            addWisdom.text = (stats.GetBaseWisdom() + 1).ToString();
    }

    public void ResetButton()
    {
        addStrength.text = stats.GetBaseStrength().ToString();
        addIntelligence.text = stats.GetBaseIntelligence().ToString();
        addConstitution.text = stats.GetBaseConstitution().ToString();
        addDexterity.text = stats.GetBaseDexterity().ToString();
        addWisdom.text = stats.GetBaseWisdom().ToString();

        hasPoint = true;
    }

    public void AcceptButton()
    {
        if (!hasPoint)
        {
            switch (pointSpend)
            {
                case StatAdded.Str:
                    stats.ModifyBaseStrength(1);
                    break;
                case StatAdded.Int:
                    stats.ModifyBaseIntelligence(1);
                    break;
                case StatAdded.Con:
                    stats.ModifyBaseConstitution(1);
                    break;
                case StatAdded.Dex:
                    stats.ModifyBaseDexterity(1);
                    break;
                case StatAdded.Wis:
                    stats.ModifyBaseWisdom(1);
                    break;
            }

            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Must spend point to leave levelup screen!");
        }
    }
}