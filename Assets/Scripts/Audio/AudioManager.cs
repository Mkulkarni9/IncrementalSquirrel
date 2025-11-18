using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class AudioManager : MonoBehaviour
{

    [SerializeField] GameObject audioPrefab;

    [Header("SFX Clips")]
    [SerializeField] AudioSO buttonClick;
    [SerializeField] AudioSO buttonHover;




    [Header("Music Clips")]
    [SerializeField] AudioSO titleMusic;



    IObjectPool<GameObject> audioPool;


    public float MusicVolume { get; private set; }

    void OnEnable()
    {
        GameManager.OnClickUIButton += PlayButtonClickSFX;
        ButtonHoverAnimations.OnHoverEnter += PlayButtonHoverSFX;


    }



    void OnDisable()
    {
        GameManager.OnClickUIButton -= PlayButtonClickSFX;
        ButtonHoverAnimations.OnHoverEnter -= PlayButtonHoverSFX;




    }


    private void Awake()
    {
        audioPool = ObjectPoolingManager.Instance.GetPool(audioPrefab.gameObject.GetInstanceID(), audioPrefab);
    }




    void PlaySound(AudioSO audioSO, float clipVolume = 1)
    {
        //Debug.Log("AudioSO: " + audioSO);
        AudioClip audioClip = audioSO.AudioClip;


        GameObject soundObject = audioPool.Get();
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.volume = audioSO.volume;
        audioSource.outputAudioMixerGroup = audioSO.mixer;

        if (audioSO.ChangePitch)
        {
            audioSource.pitch = Random.Range(audioSO.pitchRangeMin, audioSO.pitchRangeMax);
        }

        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(ReturnToPoolAfterPlayRoutine(soundObject, audioClip.length));
    }
    IEnumerator ReturnToPoolAfterPlayRoutine(GameObject soundObject, float lengthOfClip)
    {
        yield return new WaitForSeconds(lengthOfClip);
        audioPool.Release(soundObject);
    }


    void PlayMusic(AudioSO audioSO)
    {

        GameObject musicObject = new GameObject("Music audio source");
        AudioSource audioSource = musicObject.AddComponent<AudioSource>();

        AudioClip musicClip = audioSO.AudioClip;

        audioSource.clip = musicClip;
        audioSource.loop = audioSO.loop;
        audioSource.volume = audioSO.volume;
        audioSource.outputAudioMixerGroup = audioSO.mixer;
        audioSource.Play();
    }

    

    #region Play SFX clips

    public void PlayButtonClickSFX()
    {
        PlaySound(buttonClick);
    }

    public void PlayButtonHoverSFX()
    {
        PlaySound(buttonHover);
    }
    




    #endregion

    #region Play Music clips

    public void PlayTitleMusic()
    {
        PlayMusic(titleMusic);
    }



    #endregion
}
