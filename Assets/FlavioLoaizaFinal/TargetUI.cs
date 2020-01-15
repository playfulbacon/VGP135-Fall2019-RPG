using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUI : MonoBehaviour
{
    private Image mImageWhenTargeted;
    public float imageRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mImageWhenTargeted = GetComponentInChildren<Image>();
        if (mImageWhenTargeted)
        {
            mImageWhenTargeted.gameObject.SetActive(false);
        }
    }

    public void SetDisplayOnPlayerTarget(bool isBeenAttacked) // B indicates whether or not the object is been attacked
    {
        if (mImageWhenTargeted && isBeenAttacked)
        {
            if(!mImageWhenTargeted.gameObject.activeSelf)
            {
                mImageWhenTargeted.gameObject.SetActive(true);
            }
        }
        if (mImageWhenTargeted && !isBeenAttacked)
        {
            mImageWhenTargeted.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (mImageWhenTargeted.gameObject.activeSelf)
        {
            //mImageWhenTargeted.rectTransform.Rotate(0.0f, 0.0f, imageRotationSpeed * Time.deltaTime);
        }
    }
}
