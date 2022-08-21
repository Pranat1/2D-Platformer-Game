using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static LevelManager Instance { get {return instance; } }
    public string[] Levels;
    [SerializeField] private SceneLoader sceneLoader;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for(int i = 0; i < 5; i++){
            SetLevelStatus(i.ToString(), LevelStatus.Locked);
        } 
        //Debug.Log(8);
        //Debug.Log((int) LevelName.Level1);
        //Debug.Log(9);
        //Debug.Log(GetLevelStatus(LevelName.Level1)); 
        if(GetLevelStatus(LevelName.Level1)  == LevelStatus.Locked){
            //Debug.Log(7);
            //Debug.Log(((int) LevelName.Level1).ToString());
            SetLevelStatus(((int) LevelName.Level1).ToString(), LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(LevelName level)
    {
        //Debug.Log(11);
        //Debug.Log(PlayerPrefs.GetInt(((int) level).ToString()));
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(((int) level).ToString());
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        //Debug.Log(10);
        //Debug.Log(level);
        PlayerPrefs.SetInt(level, (int) levelStatus);
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //int nextSceneIndex = currentScene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        //LevelManager.Instance.SetLevelStatus(nextScene.name, LevelStatus.Completed);
        int currentSceneIndex = Array.FindIndex(Levels, level => level.ToString() == currentScene.name) + 1;
        SetLevelStatus(currentSceneIndex.ToString(), LevelStatus.Completed);
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log(currentSceneIndex);
        Debug.Log(nextSceneIndex);
        if(nextSceneIndex < Levels.Length)
        {
            Debug.Log(20);
            SetLevelStatus(nextSceneIndex.ToString(), LevelStatus.Unlocked);
        }
        sceneLoader.OpenLobbey();

        
    }
}
