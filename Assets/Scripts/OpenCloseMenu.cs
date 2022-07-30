using UnityEngine.Events;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public UnityEvent CloseMenuEvent;
    public UnityEvent OpenMenuEvent;
    public UnityEvent LevelCompleteEvent;
    public UnityEvent LostLevelEvent;
    public UnityEvent GameCompleteEvent;

    public void CloseMenu()
    {
        CloseMenuEvent.Invoke();
    }
    public void OpenMenu()
    {
        OpenMenuEvent.Invoke();
    }
    public void LevelComplete()
    {
        LevelCompleteEvent.Invoke();
    }
    public void LostLevel()
    {
        LostLevelEvent.Invoke();
    }
    public void GameComplete()
    {
        GameCompleteEvent.Invoke();
    }
}
