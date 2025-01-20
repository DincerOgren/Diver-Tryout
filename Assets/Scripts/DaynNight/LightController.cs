using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightController : MonoBehaviour
{
    [SerializeField] Light _directionalLight;
    [SerializeField] LightingPreset _lightingPreset;
    [SerializeField] [Range(0, 24)] float _timeOfTheDay;



    private void Update()
    {
        if (_lightingPreset == null) return;

        if (Application.isPlaying)
        {
            _timeOfTheDay += Time.deltaTime;
            _timeOfTheDay %= 24;
            UpdateLighting(_timeOfTheDay / 24);
        }
        else
            UpdateLighting(_timeOfTheDay / 24);

    }


    void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = _lightingPreset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = _lightingPreset.FogColor.Evaluate(timePercent);

        if (_directionalLight != null)
        {
            _directionalLight.color = _lightingPreset.DirectionalColor.Evaluate(timePercent);

            _directionalLight.transform.localRotation = 
                Quaternion.Euler(new Vector3((timePercent * 360) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (_directionalLight != null)
            return;

        if (RenderSettings.sun != null)
            _directionalLight = RenderSettings.sun;
        else
        {
            Light[] lights = FindObjectsOfType<Light>();
            foreach (var item in lights)
            {
                if (item.type == LightType.Directional)
                {
                    _directionalLight = item;
                    return;
                }
            }
        }

    }

}
