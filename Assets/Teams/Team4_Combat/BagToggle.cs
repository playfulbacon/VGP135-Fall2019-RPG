using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagToggle : MonoBehaviour
{
    bool isBagOpen;
    Vector3 toggleVec;
    float toggleX;
    void Start()
    {
        toggleVec = new Vector3();
        isBagOpen = true;
        toggleX = 1500;
        ToggleBag();
    }

    public void ToggleBag()
    {
        if (isBagOpen)
        {
            toggleVec.x = toggleX;
            transform.Translate(toggleVec);
            isBagOpen = false;
        }
        else
        {
            toggleVec.x = -toggleX;
            transform.Translate(toggleVec);
            isBagOpen = true;
        }
    }
}
