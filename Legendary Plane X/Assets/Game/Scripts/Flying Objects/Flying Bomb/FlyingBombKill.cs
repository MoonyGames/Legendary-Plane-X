using UnityEngine;

public class FlyingBombKill : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem boomVFX;

    private MeshRenderer meshRenderer;

    private AudioSource audioSource;

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

            ObjectPooler.IsGenerating = false;

            ShakeCamera.singleton.Shake();

            SpeedUpGame.StopScaling();

            other.GetComponent<PlaneDeath>().Death();

            boomVFX.transform.position = transform.position;
            boomVFX.Play();
        }
    }
}
