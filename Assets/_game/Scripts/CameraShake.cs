using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public float ShakeDuration = 0.2f;
    [HideInInspector]
    public float ShakeAmplitude = 1.2f;
    [HideInInspector]
    public float ShakeFrequency = 2.0f;

    CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin virtualCamNoise;
    private float ShakeTime = 0f;

    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        virtualCamNoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (ShakeTime > 0.0f)
        {
            virtualCamNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCamNoise.m_FrequencyGain = ShakeFrequency;

            ShakeTime -= Time.deltaTime;
        }

        else
        {
            virtualCamNoise.m_AmplitudeGain = 0;
            virtualCamNoise.m_FrequencyGain = 1;
        }
    }

    public void StartCameraShake(float _amplitude, float _frequency)
    {
        ShakeTime = ShakeDuration;
        ShakeAmplitude = _amplitude;
        ShakeFrequency = _frequency;
    }
}
