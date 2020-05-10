using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [Header("TESTING")]
    public bool TestShake = true;
    [Header("SHAKE PROPERTIES")]
    public float ShakeDuration = 0.2f;
    public float ShakeAmplitude = 1.2f;
    public float ShakeFrequency = 2.0f;

    CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin virtualCamNoise;
    private float shakeTime = 0f;
    private bool waitForShake = false;

    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        virtualCamNoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (shakeTime > 0.0f)
        {
            virtualCamNoise.m_AmplitudeGain = ShakeAmplitude;
            virtualCamNoise.m_FrequencyGain = ShakeFrequency;

            shakeTime -= Time.deltaTime;
        }
        else
        {
            waitForShake = false;
            virtualCamNoise.m_AmplitudeGain = 0;
            virtualCamNoise.m_FrequencyGain = 1;
        }
    }

    public void StartCameraShake(float _duration, float _amplitude, float _frequency, bool _waitToEnd = false)
    {
        if (waitForShake)
            return;

        waitForShake = _waitToEnd;
        shakeTime = ShakeDuration;
        ShakeAmplitude = _amplitude;
        ShakeFrequency = _frequency;
    }
}
