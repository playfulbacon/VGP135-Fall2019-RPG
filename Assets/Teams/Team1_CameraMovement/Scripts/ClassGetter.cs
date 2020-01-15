using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassGetter : MonoBehaviour
{
    public enum CharactorClass
    {
        None = -1,
        Ranger = 0,
        OldMonk = 1,
        //Mage = 2
        NumOfTypes
    }

    private CharactorClass mPlayerClass;

    public CharactorClass PlayerClass { get { return mPlayerClass; }}

    void Awake()
    {
        //if (GetComponent<Ranger>() != null)
        //    mPlayerClass = CharactorClass.Ranger;
        //else if (GetComponent<OldMonk>() != null)
        //    mPlayerClass = CharactorClass.OldMonk;
        //else if (GetComponent<Mage>() != null)
        //    mPlayerClass = CharactorClass.Mage;
        int rand = Random.Range(0, (int)ClassGetter.CharactorClass.NumOfTypes);
        mPlayerClass = (ClassGetter.CharactorClass)rand;
    }
}
