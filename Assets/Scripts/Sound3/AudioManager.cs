using UnityEngine;

namespace Sound3Demo
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("-------Audio Source-------")]
        [SerializeField] public AudioSource musicSource, sfxSource;
        [Header("-------Audio Clip-------")]
        public AudioClip[] clips;

        private void Start()
        {
            musicSource.clip = clips[0];
            musicSource.Play();
        }

        public void PlaySFX(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
