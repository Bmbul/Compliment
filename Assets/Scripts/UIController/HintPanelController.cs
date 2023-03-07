using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class HintPanelController : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [SerializeField] RectTransform content;
    [SerializeField] float transitionTime;
    float moveDistance;
    bool canMove;
    int currentHint = 0;

    private void Start()
    {
        moveDistance = content.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x - content.GetChild(1).GetComponent<RectTransform>().anchoredPosition.x;
        canMove = true;
    }

    public async void OnNextButtonClick()
    {
        GameUIController.Instance.OnButtonClick();
        if (!canMove) return;
        canMove = false;
        if (currentHint == 1)
            nextButton.SetActive(false);

        content.DOAnchorPosX(content.anchoredPosition.x + moveDistance, transitionTime);
        await Task.Delay((int)(transitionTime * 1000));
        currentHint++;
        canMove = true;
    }

    public void OnCloseButtonClick()
    {
        GameUIController.Instance.OnButtonClick();
        gameObject.SetActive(false);
    }
}
