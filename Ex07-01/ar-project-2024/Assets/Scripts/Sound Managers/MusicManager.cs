using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	
public class MusicManager : Singleton<MusicManager> {

    private AudioSource[] m_audio_sources;

    // true if using the game object name to start the music
    public bool m_useGONames = false;

    private Dictionary<string, AudioSource> music_list;

    void Awake() {
        
        if (FindObjectsOfType(typeof(MusicManager)).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        music_list = new Dictionary<string, AudioSource>();

        m_audio_sources = gameObject.GetComponentsInChildren<AudioSource>();

        for (int i = 0; i < m_audio_sources.Length; i++) {
            AudioSource s = m_audio_sources [i];
            if (m_useGONames)
                music_list [s.gameObject.name] = s;
            else
                music_list [s.clip.name] = s;
        }
    }

    public void PlayMusic(string name, bool repeated = false, float duration =0, int n_times = 1, float pitchVariance = 0)
    {
        if (music_list.ContainsKey(name))
        {
            if (pitchVariance != 0) music_list[name].pitch = 1 + Random.Range(-pitchVariance, pitchVariance);

            if (!music_list [name].isPlaying)
                if(!repeated)
                {   music_list[name].Play();}
                else
                {
                    StartCoroutine(PlayMusicRepeated(name, duration, n_times));
                }

        } else Debug.LogWarning("No sound of name " + name + " exists");
    }

    IEnumerator PlayMusicRepeated(string name, float duration, int n_times)
    {
        for(int i = 0; i < n_times; i++)
        {
            music_list[name].Play();
            yield return new WaitForSeconds(duration);
        }

        yield return new WaitForSeconds(0f);

    }

    public void MuteAll()
    {
        for (int i = 0; i < m_audio_sources.Length; i++)
            m_audio_sources [i].mute = true;
    }

    public void UnmuteAll()
    {
        for (int i = 0; i < m_audio_sources.Length; i++)
            m_audio_sources [i].mute = false;
    }

    public void StopAll()
    {
        StopAllCoroutines();
        for (int i = 0; i < m_audio_sources.Length; i++)
            m_audio_sources [i].Stop ();
    }

    public bool isPlaying(string name) {
        if (music_list.ContainsKey (name)) {
            return music_list [name].isPlaying;
        } else {
            Debug.LogWarning ("No sound of name " + name + " exists");
            return false;
        }
    }
		
}
