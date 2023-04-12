public class CoinsCounter : CoinsShower
{
    protected override void Awake()
    {
        base.Awake();

        FlyingBonusCollect.OnBonusCoinCollect += AddCoin;
    }

    private void OnDisable()
    {
        FlyingBonusCollect.OnBonusCoinCollect -= AddCoin;
    }
}
