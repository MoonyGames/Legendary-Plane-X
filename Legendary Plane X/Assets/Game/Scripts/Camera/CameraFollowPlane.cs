using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    [Range(0f, 10f)]
    private float _strength = 5f;

    private PlaneController planeController;

    private float i;
    private const float STARTTARGETYROTATION = -50f;

    private void Awake()
    {
        planeController = _target.GetComponent<PlaneController>();
    }

    private void Update()
    {
        i = Mathf.InverseLerp(planeController.bottom, -planeController.bottom, _target.position.y);

        Debug.Log(i);

        transform.rotation = Quaternion.Lerp(Quaternion.Euler(_strength, STARTTARGETYROTATION, transform.rotation.z), Quaternion.Euler(-_strength, STARTTARGETYROTATION, transform.rotation.z), i);
    }
}
