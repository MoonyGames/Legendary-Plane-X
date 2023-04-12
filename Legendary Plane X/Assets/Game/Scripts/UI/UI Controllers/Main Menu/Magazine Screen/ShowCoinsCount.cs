public class ShowCoinsCount : CoinsShower
{
    protected override void Awake()
    {
        base.Awake();

        ChangeSkin.OnSkinBuy += AddCoin;
    }

    private void OnDisable()
    {
        ChangeSkin.OnSkinBuy -= AddCoin;
    }
}
