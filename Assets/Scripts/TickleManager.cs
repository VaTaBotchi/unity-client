using UnityEngine;
using UnityEngine.EventSystems;

public class TickleManager : MonoBehaviour
{
    [SerializeField] private float tickleTime = 2f;
    private float _timer;
    
    public void OnDragStart(BaseEventData data)
    {
        _timer = Time.time;
        DinoEmotions.Instance.SetDinoEmotion("tickle", true);
    }

    public void OnDragEnd(BaseEventData data)
    {
        DinoEmotions.Instance.SetDinoEmotion("tickle", false);
        if (Time.time - _timer >= tickleTime)
        {
            FlutterController.Instance.SendTickle();
        }
    }
}
