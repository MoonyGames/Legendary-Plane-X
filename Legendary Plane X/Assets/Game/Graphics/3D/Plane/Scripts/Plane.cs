using UnityEngine;
using DG.Tweening;

public class Plane : MonoBehaviour {
    [SerializeField]
	private GameObject _prop, _propBlured, _bonusGrabEffect;

    [SerializeField]
    private TrailRenderer _trail, _trail1;

    [SerializeField]
    private Gradient startGradient, bonusGradient;

    private bool isTrailChangeColor = false;

    private bool isEngineOn;
	public bool IsEngineOn
    {
        get
        {
            return isEngineOn;
        }

        set
        {
            isEngineOn = value;

            SetEngineState(isEngineOn);
        }
    }

    private void SetEngineState(bool isEngineOn)
    {
        if (isEngineOn)
        {
            _prop.SetActive(false);
            _propBlured.SetActive(true);
        }

        else
        {
            _prop.SetActive(true);
            _propBlured.SetActive(false);
        }
    }

    private void ActivateBonusGrabEffect()
    {
        _bonusGrabEffect.SetActive(true);
    }

    private void ChangeTrailsColor()
    {
        isTrailChangeColor = !isTrailChangeColor;

        if (isTrailChangeColor)
        {
            _trail.colorGradient = bonusGradient;
            _trail1.colorGradient = bonusGradient;

            Invoke("ChangeTrailsColor", 2f);
        }

        else
        {
            _trail.colorGradient = startGradient;
            _trail1.colorGradient = startGradient;
        }
    }

    private void Awake()
    {
        _prop = transform.GetChild(0).gameObject;
        _propBlured = transform.GetChild(1).gameObject;
        _bonusGrabEffect = transform.GetChild(4).gameObject;

        _trail = transform.GetChild(2).GetComponent<TrailRenderer>();
        _trail1 = transform.GetChild(3).GetComponent<TrailRenderer>();

        FlyingBonusCollect.OnBonusCollect += ActivateBonusGrabEffect;
        FlyingBonusCollect.OnBonusCollect += ChangeTrailsColor;
    }

    private void Start()
    {
        IsEngineOn = true;

        SetEngineState(isEngineOn);
    }

    private void Update() 
	{
		if (IsEngineOn)
            _propBlured.transform.Rotate(1000 * Time.deltaTime, 0, 0);
	}

    private void OnDisable()
    {
        FlyingBonusCollect.OnBonusCollect -= ActivateBonusGrabEffect;
        FlyingBonusCollect.OnBonusCollect -= ChangeTrailsColor;
    }
}
