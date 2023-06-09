using UnityEngine;

public class PlaneDeath : MonoBehaviour
{
    public static bool isDead;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip _planeCrashSound;

    private PlaneController planeController;

    private GameObject fire;

    private Plane plane;

    [SerializeField]
    private GameObject _deathScreen;

    private void Start()
    {
        FlyingBombKill.OnBombKill += Death;

        isDead = false;

        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        audioSource = GetComponent<AudioSource>();

        planeController = GetComponent<PlaneController>();

        fire = transform.GetChild(2).gameObject;

        plane = GetComponent<Plane>();
    }

    private void Death()
    {
        isDead = true;

        plane.IsEngineOn = false;

        planeController.enabled = false;

        fire.SetActive(true);

        audioSource.clip = _planeCrashSound;
        audioSource.loop = false;
        audioSource.Play();

        rigidbody.isKinematic = false;
        boxCollider.enabled = false;

        _deathScreen.SetActive(true);

        rigidbody.AddForce(Vector3.down * 5000f);
        rigidbody.AddTorque(Vector3.down * 10000f);
    }

    private void OnDisable()
    {
        FlyingBombKill.OnBombKill -= Death;
    }
}
