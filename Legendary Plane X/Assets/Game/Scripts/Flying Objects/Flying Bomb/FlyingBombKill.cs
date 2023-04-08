using UnityEngine;

public class FlyingBombKill : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem boomVFX;

    private MeshRenderer meshRenderer;

    private AudioSource audioSource;

    public delegate void BombKill();
    public static event BombKill OnBombKill;

    private void Awake()
    {
        boomVFX = GameObject.Find("Boom").GetComponent<ParticleSystem>();

        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !PlaneDeath.isDead)
        {
            meshRenderer.enabled = false;

            audioSource.Play();

            OnBombKill?.Invoke();

            ObjectPooler.IsGenerating = false;

            ShakeCamera.singleton.Shake();

            SpeedUpGame.StopScaling();

            boomVFX.transform.position = transform.position;
            boomVFX.Play();
        }
    }
}
