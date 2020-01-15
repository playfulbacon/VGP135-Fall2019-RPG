using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gateway : InteractableObj
{
    public bool presetlevel = false;
    bool playerIsHere = false;
    public bool isActive = true;
    public string[] presetScenes = new string[10];
    public GameObject testWatchObj;
    SceneManager sceneManager;
    public override void Interact(KeyCode input)
    {
        
    }

    public override void IsTouching(GameObject obj)
    {
        testWatchObj = obj;
        if (isActive) //Load new level when player touching the gateway while it's activated
        {
            if (obj.CompareTag("Player"))
            {
                if (presetlevel) //Use preset levels
                {
                    int i = Random.Range(0, presetScenes.Length);
                    if (presetScenes[i] != null)
                    {
                        SceneManager.LoadScene(presetScenes[i]); //choose a random preset level

                        LevelCleanUp(ref obj); //Clean up after loading a new scene
                    }
                }
                else
                {
                    //Whatever flavio has to refresh the level


                    //After Flavio refresh level
                    LevelCleanUp(ref obj);
                }
            }
        }
    }

    private void LevelCleanUp(ref GameObject obj) //Clean ups after loading a new scene
    {
        GameObject spawn;
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        if (spawn != null)
        {
            obj.transform.position = spawn.transform.position; //position the character a spawn point after loading into a new scene
        }

        if (!persistentObject) //If not a persistent Object, destroy itself after loading into a new scene
        {
            Destroy(gameObject);
        }
        isActive = false;
    }
    public override void OnExit(GameObject obj)
    {
        
    }

    public override void OnTouch(GameObject obj)
    {

    }

    public override void ObjUpdate()
    {
    }
}
