using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private float minSpeed = 30f, maxSpeed = 50f;
    private float speed;

    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
