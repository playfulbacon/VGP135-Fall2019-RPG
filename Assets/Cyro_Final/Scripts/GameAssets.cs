using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets sGameAssets;

    public static GameAssets Instance
    {
        get { 
            if (!sGameAssets)
            {
                sGameAssets = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return sGameAssets;
        }
    }

    public Transform pfDamagePopUp;
}
