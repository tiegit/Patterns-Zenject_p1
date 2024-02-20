using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Drag;

    private const int LeftMouseButton = 0;

    private bool _isSwiping;
    private Vector3 _previousMosePosition;

    public void Tick()
    {
        ProcessClickUp();
        ProcessClickDown();
        ProcessSwipe();
    }

    private void ProcessSwipe()
    {
        if(_isSwiping == false)
            return;

        if(Input.mousePosition != _previousMosePosition)
            Drag?.Invoke(Input.mousePosition);  

        _previousMosePosition = Input.mousePosition;
    }

    private void ProcessClickDown()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            ClickDown?.Invoke(Input.mousePosition);
            _isSwiping = true;
        }
    }

    private void ProcessClickUp()
    {
        if (Input.GetMouseButtonUp(LeftMouseButton))
        {
            ClickUp?.Invoke(Input.mousePosition);
            _isSwiping = false;
        }
    }
}
