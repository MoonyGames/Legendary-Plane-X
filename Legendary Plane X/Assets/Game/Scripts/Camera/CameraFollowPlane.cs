using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    [Range(0f, 10f)]
    private float _strength = 5f;

    private const float STARTTARGETYROTATION = -50f;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(_strength, STARTTARGETYROTATION, transform.rotation.z), Quaternion.Euler(-_strength, STARTTARGETYROTATION, transform.rotation.z), PlaneController.interpolator);
    }
}
