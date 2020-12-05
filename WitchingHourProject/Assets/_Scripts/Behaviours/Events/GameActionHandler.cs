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
        gameAction.floatDataAction += OnActionFloatDataHandler;
        gameAction.transformAction += OnTransformAction;
        gameAction.colliderAction += OnColliderAction;
    }

    private void ActionHandler()
    {
        Invoke(nameof(OnActionHandler), holdTime);
    }

    private void OnActionHandler()
    {
        handlerEvent.Invoke();
    }

    private void OnActionFloatDataHandler(FloatData obj)
    {
        handlerEvent.Invoke();
    }

    private void OnTransformAction(Transform obj)
    {
        handlerEvent.Invoke();
    }

    private void OnColliderAction(BoxCollider obj)
    {
        handlerEvent.Invoke();
    }
}
