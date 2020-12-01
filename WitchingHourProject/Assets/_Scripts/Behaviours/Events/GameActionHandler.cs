using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameAction;
    public UnityEvent handlerEvent;
    public float holdTime = 0.01f;
    
    private void Start()
    {
        gameAction.action += ActionHandler;
        gameAction.floatAction += OnActionFloatHandler;
        gameAction.floatDataAction += OnActionFloatDataHandler;
    }

    private void ActionHandler()
    {
        Invoke(nameof(OnActionHandler), holdTime);
    }

    private void OnActionHandler()
    {
        handlerEvent.Invoke();
    }
    
    private void OnActionFloatHandler(float obj)
    {
        //hard code
    }
    
    private void OnActionFloatDataHandler(FloatData obj)
    {
        handlerEvent.Invoke();
    }
}
