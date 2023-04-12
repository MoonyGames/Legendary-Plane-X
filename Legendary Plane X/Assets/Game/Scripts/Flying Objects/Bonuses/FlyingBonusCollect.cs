using UnityEngine;

public class FlyingBonusCollect : FlyingObject
{
    private GameObject hitParticle, coinParticle;

    private AudioSource audioSource;

    public delegate void BonusCollect();
    public static event BonusCollect OnBonusCollect;

    public delegate void BonusCoinCollect(int count);
    public static event BonusCoinCollect OnBonusCoinCollect;

    private void Awake()
    {
        hitParticle = transform.GetChild(0).gameObject;
        coinParticle = transform.GetChild(1).gameObject;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hitParticle.SetActive(true);
            coinParticle.SetActive(true);
            audioSource.Play();

            OnBonusCollect?.Invoke();
            OnBonusCoinCollect?.Invoke(1);
        }
    }
}
