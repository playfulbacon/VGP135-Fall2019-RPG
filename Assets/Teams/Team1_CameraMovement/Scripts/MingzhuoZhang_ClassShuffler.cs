using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingzhuoZhang_ClassShuffler : MonoBehaviour
{
    
    void Awake()
    {
        ShufflerClass();
    }

    void ShufflerClass()
    {
        var currentClass = GetComponent<Ranger>();
        var attackObj = currentClass.autoAttackObject;
       // Destroy(currentClass);

        int rand = Random.Range(0, (int)ClassGetter.CharactorClass.NumOfTypes);

        switch (rand)
        {
            case (int)ClassGetter.CharactorClass.Ranger:
                gameObject.AddComponent<Ranger>().autoAttackObject = attackObj;
                break;
            case (int)ClassGetter.CharactorClass.OldMonk:
                gameObject.AddComponent<OldMonk>().autoAttackObject = attackObj;
                break;
            default:
                break;
        }
    }
}
