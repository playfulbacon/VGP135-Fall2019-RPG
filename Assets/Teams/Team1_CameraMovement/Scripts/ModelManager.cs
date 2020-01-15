using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ModelManager : MonoBehaviour
{
    [System.Serializable]
    public struct ClassModelData
    {
        public string mName;
        public GameObject mModelTPos;
        public float mShootDelay;
    }

    public ClassModelData[] mModelDatas;

    public ClassModelData GetModelData(ClassGetter.CharactorClass charactorClass)
    {
        if (charactorClass == ClassGetter.CharactorClass.None)
        {
            return mModelDatas[0];
        }
        else
        {
            return mModelDatas[(int)charactorClass];
        }
    }
}
