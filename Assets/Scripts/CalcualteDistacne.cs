using IJunior.TypedScenes;
using TMPro;
using UnityEngine;

public class CalcualteDistacne : MonoCache
{
    [SerializeField] private WASDCubeController _WASDCubeController;
    [SerializeField] private ArrowsCubeController _ArrowsCubeController;

    [Space(5)]
    [SerializeField] private int _rangeEnable = 2;
    [SerializeField] private int _rangeTransition = 1;

    [Space(5)]
    [SerializeField] private TMP_Text _distacnetText;

    [Space(5)]
    [SerializeField] private GameObject _spheres;

    private float _disatance;

    public override void OnTick()
    {
        _disatance = Vector3.Distance(_WASDCubeController.transform.position, _ArrowsCubeController.transform.position);
        UpdateUI();

        if (_disatance <= _rangeEnable)
            _spheres.SetActive(true);
        else
            _spheres.SetActive(false);

        if (_disatance <= _rangeTransition)
            Scene2.Load();
    }

    private void UpdateUI()
    {
        _distacnetText.text = "Расстояния: " + _disatance.ToString("N2");
    }
}