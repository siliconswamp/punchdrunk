using UnityEngine;
using System.Collections;
[System.Serializable]
//A

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip aclip;
    public float delay;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = aclip;
        setStats(audio);
        audio.PlayDelayed(delay);

        yield return new WaitForSeconds(audio.clip.length);

    }


    void setStats(AudioSource aD)
    {
        aD.volume = volume;
        aD.pitch = pitch;
    }
}

//Script and Sound Object done based on instructions found here: https://support.unity3d.com/hc/en-us/articles/206116056-How-do-I-use-an-Audio-Source-in-a-script-


//Previous Version
/*
 * using UnityEngine;
[System.Serializable]

public class Sound {
    public string name;
    public AudioClip clip;
    private AudioSource source;


    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;


    public void SetSource (AudioSource _source) {
        source = _source;
        source.clip = clip;
    }

    public void Play () {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake() {
        if(instance != null){
            Debug.LogError ("More than one AudioManager in scene");
        }
        else {
            instance = this;
        }
        
    }
    
    [SerializeField]
    Sound[] sounds;

    void Start () {
        for(int i = 0; i < sounds.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
        }
        PlaySound("song");
    }

    public void PlaySound(string _name) {
        for(int i = 0; i < sounds.Length; i++){
            if(sounds[i].name == _name){
                sounds[i].Play();
                return;
            }
        }

        //no sound found
        Debug.LogWarning("AudioManager: Sound not found in array: " + _name);
    }

}

//https://www.youtube.com/watch?v=HhFKtiRd0qI
*/
