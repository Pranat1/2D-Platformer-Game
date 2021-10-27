using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class PlayerDeath : MonoBehaviour{
    
    public GameObject UnityButton; 

/*
void OnTriggerEnter2D()
    {
        Instantiate(UnityButton, new Vector3(0f,0f,0f), transform.rotation);
    }
*/
    public void LoadSceneAgain() 
    {
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name);
    }
}
