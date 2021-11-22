using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamController : MonoBehaviour
{
    CinemachineVirtualCamera vcm;
    CinemachineBasicMultiChannelPerlin vcamNoise;

    [SerializeField, Range(0.1f, 5f)]
    float shakeTime = 0.2f;

    [SerializeField, Range(0.1f, 5f)]
    float shakeGain = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        vcm = GetComponent<CinemachineVirtualCamera>();
        vcamNoise = vcm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        StartCoroutine(Shaking(shakeTime));
    }

    IEnumerator Shaking(float time)
    {
        vcamNoise.m_AmplitudeGain  = shakeGain;
        yield return new WaitForSeconds(time);
        vcamNoise.m_AmplitudeGain  = 0f;
    }
}
