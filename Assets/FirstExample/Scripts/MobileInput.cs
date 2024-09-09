using System;
using UnityEngine;
using Zenject;

public class MobileInput : IInput, ITickable
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Drag;

    private const int FirstTouch = 0;

    public void Tick()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(FirstTouch);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    ClickDown?.Invoke(touch.position);
                    break;

                case TouchPhase.Moved:
                    Drag?.Invoke(touch.position);
                    break;

                case TouchPhase.Ended:
                    ClickUp?.Invoke(touch.position);
                    break;
            }
        }
    }
}
