using UnityEngine;
using UnityEngine.UI;

public class LobbeyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
}
