using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 120f;
    [Tooltip("In m")] [SerializeField] float xRange = 35f;
    [Tooltip("In m")] [SerializeField] float yRange = 20f;

    [SerializeField] float positionPitch = -1.32f;
    [SerializeField] float controlPitch = -2.42f;

    [SerializeField] float positionYaw = 1f;
    [SerializeField] float controlRoll = -2.42f;
    float xThrow, yThrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeRotation();
        ChangePosition();
    }

    private void ChangeRotation()
    { 
        float pitch = (transform.localPosition.y * positionPitch) + (yThrow * controlPitch);
        float yaw = transform.localPosition.x * positionYaw;
        float roll = xThrow * controlRoll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void ChangePosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float newXpos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float newYpos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(newXpos, newYpos, transform.localPosition.z);
    }
}
