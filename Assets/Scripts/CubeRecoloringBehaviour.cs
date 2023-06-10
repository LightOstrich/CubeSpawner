using UnityEngine;
using Random = UnityEngine.Random;

public class CubeRecoloringBehaviour : MonoBehaviour
{
    private const float HueMin = 0f;
    private const float HueMax = 1f;
    private const float SaturationMin = 0.8f;
    private const float SaturationMax = 1f;
    private const float ValueMinBrightness = 0.7f;
    private const float ValueMaxBrightness = 1f;

    [SerializeField] private float colorChangeTime = 2f;
    [SerializeField] private float delayAfterColorChange = 2f;

    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _recoloringTimeDuration;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        GetNextColoring();
    }

    private void GetNextColoring()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(HueMin, HueMax, SaturationMin, SaturationMax, ValueMinBrightness,
            ValueMaxBrightness);
    }

    // Update is called once per frame
    private void Update()
    {
        _recoloringTimeDuration += Time.deltaTime;
        var t = _recoloringTimeDuration / colorChangeTime;
        _renderer.material.color = Color.Lerp(_startColor, _nextColor, t);
        if (_recoloringTimeDuration >= delayAfterColorChange + colorChangeTime)
        {
            _recoloringTimeDuration = 0;
            GetNextColoring();
        }
    }
}