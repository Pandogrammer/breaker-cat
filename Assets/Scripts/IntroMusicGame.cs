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

        private void Start()
        {
            PlayMusic();
        }

        public void Play()
        {
            CreateAudioSource();

            audioSource.clip = menuMusic;
            audioSource.Play();
        }

        private void CreateAudioSource()
        {
            var newAudioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            newAudioSource.loop = true;
            audioSource = newAudioSource;
        
            if (!AudioBegin) {
                DontDestroyOnLoad(gameObject);
                AudioBegin = true;
            }
        }
    }
}