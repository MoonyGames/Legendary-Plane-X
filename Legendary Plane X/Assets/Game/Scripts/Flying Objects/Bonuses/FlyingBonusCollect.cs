using UnityEngine;

public class FlyingBonusCollect : FlyingObject
{
    [SerializeField]
    private GameObject _hitParticle;

    private AudioSource audioSource;

    public delegate void BonusCollect();
    public event BonusCollect OnBonusCollect;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _hitParticle.SetActive(true);
            audioSource.Play();

            OnBonusCollect?.Invoke();
        }
    }
}
