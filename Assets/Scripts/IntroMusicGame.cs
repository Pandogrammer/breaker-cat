using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class IntroMusicGame: MonoBehaviour
    {
        private AudioSource audioSource;
        private static bool AudioBegin;
        public event Action PlayMusic;
        public event Action StopMusic;
        
        [SerializeField] private AudioClip menuMusic;
        
        private static IntroMusicGame instance;

        void Awake()
        {
            CreateAudioSource();
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(audioSource);
        }

        
        private void Start()
        {
            PlayMusic();
        }

        public void Play()
        {
            audioSource.clip = menuMusic;
            audioSource.Play();
        }

        private void CreateAudioSource()
        {
            var newAudioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            newAudioSource.loop = true;
            audioSource = newAudioSource;
        }   
    }
}