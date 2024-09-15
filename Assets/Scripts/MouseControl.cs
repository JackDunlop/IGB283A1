using UnityEngine;

public class MouseControl  
{


    private bool isMoving = false;
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public IGB283Vector3 gameObjectPosition { get; set; }
    public IGB283Vector3 mousePosition { get; set; }

    public MouseControl(IGB283Vector3 gameObjectPosition)
    {
        this.gameObjectPosition = gameObjectPosition;
    }

    void UpdateMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new IGB283Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObjectPosition).z));
    }

    public void MouseClickAction()
    {
        if (Input.GetMouseButton(0))
        {
            MouseOverAction();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            IsMoving = false;
        }
    }

    void MouseOverAction()
    {
        UpdateMousePosition();
        float distance = IGB283Vector3.Distance(mousePosition, gameObjectPosition);
        if (distance <= 8)
        {
            IsMoving = true;
        }
   
    }
    public void UpdateGameObjectPosition(IGB283Vector3 newPosition)
    {
        gameObjectPosition = newPosition;
    }


    public (IGB283Vector3, bool) GetModifiedValues()
    {
        if (IsMoving)
        {
            return (mousePosition, true);
        }
        return (null, false);
    }
}
