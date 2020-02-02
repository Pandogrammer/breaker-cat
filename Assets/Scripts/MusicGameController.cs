using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MusicGameController: MonoBehaviour
    {
        private AudioSource audioSource;
        private AudioSource audioSourceWhistle;
        private static bool AudioBegin;
        public event Action PlayMusic;
        
        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip gameMusic;
        [SerializeField] private AudioClip whistleSound;
        
        private static MusicGameController instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            CreateAudioSource();
            CreateAudioSourceWhistle();

            instance = this;
            DontDestroyOnLoad(instance);
            DontDestroyOnLoad(audioSource);
            DontDestroyOnLoad(audioSourceWhistle);
            audioSource.playOnAwake = false;
        }

        
        private void Start()
        {
            PlayMusic();
        }

        public void PlayMenuMusic()
        {
            RestoreAudioSource();
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
        
        public void PlayGameMusic()
        {
            RestoreAudioSource();
            audioSource.clip = gameMusic;
            audioSource.Play();
        }

        public void PlayWhistle()
        {
            RestoreAudioSource();
            audioSourceWhistle.Play();
        }

        private void CreateAudioSource()
        {
            var newAudioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
            audioSource = newAudioSource;            
        }

        private void CreateAudioSourceWhistle()
        {
            audioSourceWhistle = new GameObject("AudioSource").AddComponent<AudioSource>();
            ;
            audioSourceWhistle.Stop();
            audioSourceWhistle.loop = false;
            audioSourceWhistle.time = 0f;
            audioSourceWhistle.clip = whistleSound;
        }

        public void SetAudioSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }

        private void RestoreAudioSource()
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.time = 0f;
        }
    }
}