using System;
using UnityEngine;

public class MovementHandler: IDisposable
{
    private IInput _input;

    public MovementHandler(IInput input)
    {
        _input = input;

        Debug.Log(input.GetType());

        _input.ClickDown += OnClickDown;
        _input.ClickUp += ClickUp;
        _input.Drag += OnDrag;
    }

    public void Dispose()
    {
        Debug.Log("Dispose");
        _input.ClickDown -= OnClickDown;
        _input.ClickUp -= ClickUp;
        _input.Drag -= OnDrag;
    }

    private void OnClickDown(Vector3 position)
    {
        Debug.Log("ClickDown");
    }

    private void ClickUp(Vector3 position)
    {
        Debug.Log("ClickUp");
    }

    private void OnDrag(Vector3 position)
    {
        Debug.Log("Drag");
    }
}
