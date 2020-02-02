using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MusicGameController: MonoBehaviour
    {
        private AudioSource audioSource;
        private static bool AudioBegin;
        public event Action PlayMusic;
        
        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip gameMusic;
        
        private static MusicGameController instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            CreateAudioSource();
            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(audioSource);
            audioSource.playOnAwake = false;
        }

        
        private void Start()
        {
            PlayMusic();
        }

        public void PlayMenuMusic()
        {
            Stop();
            audioSource.loop = true;
            audioSource.time = 0f;
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
        
        public void PlayGameMusic()
        {
            Stop();
            audioSource.loop = false;
            audioSource.time = 0f;
            audioSource.clip = gameMusic;
            audioSource.Play();
        }

        private void CreateAudioSource()
        {
            var newAudioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            audioSource = newAudioSource;
        }

        public void Stop()
        {
            audioSource.Stop();
        }

        public void SetAudioSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }
    }
}