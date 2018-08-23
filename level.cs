using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {

    [SerializeField] int breakableBlocks=0;
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
       
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
	
    public void blockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
