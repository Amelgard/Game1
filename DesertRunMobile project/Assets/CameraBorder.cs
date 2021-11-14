using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder
{
    public float RightBorder { get; private set; }
    public float LeftBorder { get; private set; }
    public float UpBorder { get; private set; }
    public float DownBorder { get; private set; }
    public CameraBorder(Camera currentCamera)
    {
        FindBorderVertical(currentCamera);
        FindBorderHorizontal(currentCamera);
    }
    public CameraBorder(Camera currentCamera, int rightOffset, int leftOffset, int upOffset, int downOffset)
    {
        FindBorder(currentCamera, rightOffset, leftOffset, upOffset, downOffset);
    }
    public void FindBorderVertical(Camera currentCamera)
    {
        Vector2 upRight = currentCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Vector2 downleft = currentCamera.ScreenToWorldPoint(new Vector3(0, 0));
        UpBorder = upRight.y;
        DownBorder = downleft.y;
    }
    public void FindBorderHorizontal(Camera currentCamera)
    {
        Vector2 upRight = currentCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Vector2 downleft = currentCamera.ScreenToWorldPoint(new Vector3(0, 0));
        RightBorder = upRight.x;
        LeftBorder = downleft.x;
    }
    public void FindBorderVertical(Camera currentCamera, int upOffset, int downOffset)
    {
        Vector2 upRight = currentCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height - upOffset));
        Vector2 downleft = currentCamera.ScreenToWorldPoint(new Vector3(0, downOffset));
        UpBorder = upRight.y;
        DownBorder = downleft.y;
    }
    public void FindBorderHorizontal(Camera currentCamera, int rightOffset, int leftOffset)
    {
        Vector2 upRight = currentCamera.ScreenToWorldPoint(new Vector3(Screen.width - rightOffset, Screen.height));
        Vector2 downleft = currentCamera.ScreenToWorldPoint(new Vector3(leftOffset, 0));
        RightBorder = upRight.x;
        LeftBorder = downleft.x;
    }
    public void FindBorder (Camera currentCamera, int rightOffset, int leftOffset, int upOffset, int downOffset)
    {
        FindBorderHorizontal(currentCamera,  rightOffset, leftOffset);
        FindBorderVertical(currentCamera, upOffset, downOffset);
    }
}
