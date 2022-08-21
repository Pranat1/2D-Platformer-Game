using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
[SerializeField] class LevelLoader : MonoBehaviour
{
    private Button button;
    [SerializeField] private LevelName LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level you need to unlock it");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(Convert.ToInt32(LevelName));
                SoundManager.Instance.Play(Sounds.ButtonClick);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(Convert.ToInt32(LevelName));
                SoundManager.Instance.Play(Sounds.ButtonClick);
                break;
        }

    }
}
