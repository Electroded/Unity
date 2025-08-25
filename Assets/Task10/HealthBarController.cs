using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private HealthBarView _view;
    [SerializeField] private HealthBarModel _model;

    private void Awake()
    {
        if (_model == null)
        {
            _model = GetComponent<HealthBarModel>();
        }
        if (_model == null)
        {
            _view = GetComponent<HealthBarView>();
        }

        UpdateView();
    }

    public void SetHealth(float health)
    {
        _model.SetHealth(health);

        UpdateView();
    }

    private void UpdateView()
    {
        _view.SetHPBar(_model.Health);

        _view.SetHPText(_model.Health, _model.MaxHealth);

        _view.SmoothSetHPBar(_model.Health);
    }
}