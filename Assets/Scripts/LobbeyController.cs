using UnityEngine;
using UnityEngine.UI;

public class LobbeyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        LevelSelection.SetActive(true);
    }
}
