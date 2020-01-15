using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public static DamagePopUp Create(Vector3 position, int damageAmount)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.Instance.pfDamagePopUp, position, Quaternion.identity);
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.SetUp(damageAmount);
        return damagePopUp;
    }

    private const float DISAPPEAR_TIMER_MAX = 1f;

    private TextMesh mTextMesh;
    private float disappearTime;
    private Color mTextColor;
    private Vector3 moveVector;
    private void Awake()
    {
        mTextMesh = transform.GetComponent<TextMesh>();
    }
    /// <summary>
    /// Createa pop up damage
    /// </summary>
    /// <param name="position">top enemy position</param>
    /// <param name="damageAmount">damage receive</param>
    /// <returns></returns>

    public void SetUp(int damageAmount)
    {
        mTextMesh.text = damageAmount.ToString();
        mTextColor = mTextMesh.color;
        disappearTime = DISAPPEAR_TIMER_MAX;
        moveVector = new Vector3(1f, 1f) * 30f;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 15f * Time.deltaTime; // moving popup to the right

        if (disappearTime > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            float increaseScale = 1f;
            transform.localScale += Vector3.one * increaseScale * Time.deltaTime;
        }
        else
        {
            float increaseScale = 1f;
            transform.localScale -= Vector3.one * increaseScale * Time.deltaTime;
        }

        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            float disappearSpeed = 3f;
            mTextColor.a -= disappearSpeed * Time.deltaTime;
            mTextMesh.color = mTextColor;
            if (mTextColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
