using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SomManager : MonoBehaviour
{
     [SerializeField]  AudioClip menuMusic;
 [SerializeField]  AudioClip gameMusic;
    [SerializeField] AudioClip gameOverMusic;
     [SerializeField]  AudioClip winMusic;

    private AudioSource audioSource;
    private static SomManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    void PlayMusicForScene(string sceneName)
    {
        AudioClip newClip = null;

        if (sceneName == "Menu") 
            newClip = menuMusic;
        else if (sceneName == "Game") 
            newClip = gameMusic;
        else if (sceneName == "GameOver") 
            newClip = gameOverMusic;
        else if (sceneName == "Ganhou") 
            newClip = winMusic;

        if (newClip != null && audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}

