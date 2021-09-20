using UnityEngine;
using System.Collections;

public static class Utils
{
	public static Rect ScreenRectInWorldCoords()
	{
		// get coordinates of top-left and bottom-right of the screen (in world space, i.e. same coordinate system as GameObjects)
		Vector2 topLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector2 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		
		return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y); 
	}
}
