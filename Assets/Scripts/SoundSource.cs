using UnityEngine;

internal class SoundSource : MonoBehaviour
{
    private AudioSource audioSource;

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if(audioSource == null) // 오디오 소스 한번도 안썼을 때 비어있을 경우 방지
            audioSource = GetComponent<AudioSource>();

        CancelInvoke();
        audioSource.clip = clip;
        audioSource.volume = soundEffectVolume;
        audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);
        audioSource.Play();
        
        Invoke("Disable", clip.length + 2); // 오디오 소스 2초 뒤에 멈추게 함
    }

    public void Disable()
    {
        audioSource.Stop();
        gameObject.SetActive(false); // 오브젝트 풀에 다시 넣어 줌
    }
}