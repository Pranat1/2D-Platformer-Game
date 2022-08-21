using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            levelManager.MarkCurrentLevelComplete();
        }
    }
}
