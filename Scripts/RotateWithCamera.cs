using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    void Update()
    {
        float x = Camera.main.transform.eulerAngles.x;
        float y = Camera.main.transform.eulerAngles.y;

        // Only rotate the player model if camera x rotation is between 30 and 330 degrees
        if (x > 0f && x < 360f)
        {
            transform.eulerAngles = new Vector3(0f, y, 0f);
        }
    }
}