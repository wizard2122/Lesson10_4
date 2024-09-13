using UnityEngine;
using Zenject;

public class Joystick : MonoBehaviour
{
    private IInput _input;

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }
}
