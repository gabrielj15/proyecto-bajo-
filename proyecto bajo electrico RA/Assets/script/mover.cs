using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mover : MonoBehaviour {

    // Vector2 touchDeltaPosition;
    // private Vector2 lastTouchPosition;

    private Vector2 lastTouchPosition;
    private float rotationSpeed = 0.2f;
    private float zoomSpeed = 0.01f;

    void Update () {
       

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.position - lastTouchPosition;
                //float rotateX = -touchDeltaPosition.y * rotationSpeed;
                float rotateX = touchDeltaPosition.y * (rotationSpeed * -1);
                float rotateY = touchDeltaPosition.x * rotationSpeed;

                transform.Rotate(rotateX, rotateY, 0);
            }

            lastTouchPosition = touch.position;
        }
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float zoomDelta = prevTouchDeltaMag - touchDeltaMag;

            Vector3 newScale = transform.localScale + Vector3.one * zoomDelta * zoomSpeed;
            newScale = Vector3.Max(newScale, Vector3.one * 0.1f); // Limit minimum scale
            newScale = Vector3.Min(newScale, Vector3.one * 10.0f); // Limit maximum scale

            transform.localScale = newScale;
        }
    }
}