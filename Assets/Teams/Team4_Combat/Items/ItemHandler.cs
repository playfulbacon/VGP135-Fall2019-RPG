using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    Button[] buttons;

    public int mID;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            gameObject.SetActive(false);
    }
}
