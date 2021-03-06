using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class AccentOverlay : MonoBehaviour, ScreenBecameActiveListener
{
    [GetComponent] public Image image;
    [GetComponentInChildren] public Text text;
    [GetComponent] public TransitionElement transitionElement;
    
    private void Awake()
    {
        transitionElement.enterOnScreenBecomeActive = false;
    }

    public void OnScreenBecameActive()
    {
        switch (this.GetScreenParent().GetId())
        {
            case ResultScreen.Id:
                // TODO: Big refactors needed lol
                if (!Context.Player.Settings.PlayRanked)
                {
                    image.color = "#F953C6".ToColor().WithAlpha(0.7f);
                    text.text = "RESULT_MODE_PRACTICE".Get();
                    transitionElement.Enter();
                }
                break;
        }
    }
}