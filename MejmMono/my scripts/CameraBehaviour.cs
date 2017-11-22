using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    /// <summary>
    /// This script manages the zoom and rotation of the camera
    /// </summary>

    private InputManager _inputManager;
    [SerializeField]
    private Camera _camera;
    // Multiplier for the zoom speed
    private float _zoomSpeed = 0.05f;
    // Multiplier for the rotation speed
    private float _rotationSpeed = 0.5f;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        // Debug
        if (Input.GetKey("up"))
        {
            _camera.fieldOfView += -2f;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 50f, 130f);
        }
        if (Input.GetKey("down"))
        {
            _camera.fieldOfView += 2f;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 50f, 130f);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0f, 5f, 0f);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0f, -5f, 0f);
        }
        // End of Debug

        // If two fingers touch the screen
        if (_inputManager.TwoFingers())
        {
            ZoomCamera();
        }

        // If three fingers touch the screen
		if (_inputManager.ThreeFingers())
        {
            RotateCamera();
        }
	}

    // Zooms the camera in and out
    void ZoomCamera()
    {
        // Touches are stored into local variables for easier access
        Touch zero = _inputManager.touchZero;
        Touch one = _inputManager.touchOne;

        // Touch positions are stored in Vector2's to compare with the touch locations of the next frame
        Vector2 posZeroPrev = zero.position - zero.deltaPosition;
        Vector2 posOnePrev = one.position - one.deltaPosition;

        // Distances (magnitudes) between Touch locations are stored in floats
        float deltaMagPrev = (posZeroPrev - posOnePrev).magnitude;
        float deltaMagCurr = (zero.position - one.position).magnitude;

        // Difference in distances between 2 frames
        float deltaMagDiff = deltaMagPrev - deltaMagCurr;

        // Zooms the camera in or out depending on the delta magnitude difference
        _camera.fieldOfView += deltaMagDiff * _zoomSpeed;

        // Limits the zoom to a minimum and maximum distance
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 50f, 130f);

    }

    // Rotates the Y axis of the camera's parent
    void RotateCamera()
    {
        // Touches are stored into local variables for easier access
        Touch zero = _inputManager.touchZero;
        Touch one = _inputManager.touchOne;
        Touch two = _inputManager.touchTwo;

        // Delta x positions of the touches are normalized
        float normalizedX = (zero.deltaPosition.x + one.deltaPosition.x + two.deltaPosition.x) / 3;

        // Normalized position multiplied by the rotation speed to slow down rotation
        float rotationAngle = normalizedX * _rotationSpeed;
        if (zero.phase == TouchPhase.Moved)
        {
            // Rotation speed is applied to the Y axis
            transform.rotation *= Quaternion.AngleAxis(rotationAngle, Vector3.up);
        }
    }
}
