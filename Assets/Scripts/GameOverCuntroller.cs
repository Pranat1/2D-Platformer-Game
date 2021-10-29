using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCuntroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOverMethod(){
        gameObject.SetActive(true);
    }
}
