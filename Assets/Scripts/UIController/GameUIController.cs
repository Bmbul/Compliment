using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using System.Threading.Tasks;

public class GameUIController : MonoBehaviourSingleton<GameUIController>
{
    [SerializeField] RectTransform settingsPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] AudioClip loseSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip clickSound;

    Vector2 startingPosition;
    Vector2 endPosition;
    bool isSelected;
    bool isMuted;
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource musicSource;

    private void Start()
    {
        startingPosition = settingsPanel.anchoredPosition;
        endPosition = settingsPanel.parent.GetComponent<RectTransform>().anchoredPosition + new Vector2(120,0);
        isSelected = false;
        isMuted = false;
        PublicEvents.Instance.LoseEvent.AddListener(() => OnGameLose());
        PublicEvents.Instance.WinEvent.AddListener(() => OnGameWin());
        PublicEvents.Instance.ReplayEvent.AddListener(() => OnReplay());

    }
    private void OnDestroy()
    {
        PublicEvents.Instance.LoseEvent.RemoveAllListeners();
        PublicEvents.Instance.WinEvent.RemoveAllListeners();
        PublicEvents.Instance.ReplayEvent.RemoveAllListeners();
    }

    internal void OnButtonClick()
    {
        source.clip = clickSound;
        source.Play();
    }

    public void OnSettingButtonClick()
    {
        OnButtonClick();
        if (isSelected)
        {
            settingsPanel.DOAnchorPos(startingPosition, 2f);
        }
        else
        {
            settingsPanel.DOAnchorPos(endPosition, 2f);
        }
        isSelected = !isSelected;
    }

    public void OnMuteButtonClick()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
        OnSettingButtonClick();
    }

    public void OnLeaveButtonClick()
    {
        MultiplayerController.Instance.OnLeave();
    }

    public void OnReplayButtonClick()
    {
        OnButtonClick();
        PublicEvents.Instance.ReplayEvent.Invoke();
    }

    [PunRPC]
    public void OnGameLose()
    {
        losePanel.SetActive(true);
        source.clip = loseSound;
        source.Play();
    }

    public async void OnGameWin()
    {
        winPanel.SetActive(true);
        source.clip = winSound;
        source.Play();

        await Task.Delay(3000);
        winPanel.SetActive(false);
    }

    private void OnReplay()
    {
        losePanel.SetActive(false);
        ResetTimer();
    }

    //Optional Can be Added
    private void ResetTimer()
    {

    }
}
