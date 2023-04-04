using UnityEngine;

public abstract class FlyingObject : MonoBehaviour
{
    [SerializeField]
    protected float minSpeed = 30f, maxSpeed = 50f;

    protected float speed;

    protected virtual void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    protected void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
