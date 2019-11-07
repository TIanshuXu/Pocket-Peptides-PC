using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 25f;
    Quaternion InitRotation; // for storing initial rotation

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up    * speed * Time.deltaTime);
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }

    private void Start()
    {
        InitRotation = gameObject.transform.localRotation;
    }

    private void OnEnable()
    {
        // reset the rotation
        if (InitRotation != null)
        {
            gameObject.transform.localRotation = InitRotation; 
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
