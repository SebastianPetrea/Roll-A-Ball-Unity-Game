using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int iLevelToLevel;
    public string sLevelToLoad;

    public bool LoadLevel = false;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collisionGameObjekt = collision.gameObject;

        if (collisionGameObjekt.name == "Player")
        {
            LoadScene();
        }

        void LoadScene()
        {
            if (LoadLevel)
            {
                SceneManager.LoadScene(iLevelToLevel);
            }
            else
            {
                SceneManager.LoadScene(sLevelToLoad);
            }
        }
    }


}

