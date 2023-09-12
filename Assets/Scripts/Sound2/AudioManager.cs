using System;
using UnityEngine;

namespace Sound2Demo
{

    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private Sound[] musicSounds, sfxSounds;      //配置音频片段
        public AudioSource musicSource, sfxSource;  //AudioSource

        private void Start()
        {
            PlayMusic("BGM1");
        }

        public void PlayMusic(string name)
        {
            Sound sound = Array.Find(musicSounds, x => x.name == name);
            if (sound == null)
                Debug.Log("没有此音频");
            else
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }

        public void PlaySFX(string name)
        {
            Sound sound = Array.Find(sfxSounds, x => x.name == name);
            if (sound == null)
                Debug.Log("没有此音频");
            else
            {
                sfxSource.PlayOneShot(sound.clip);
            }
        }

        //声音设置
        #region Slider 控制 UIController调用
        /// <summary>
        /// 主音量
        /// </summary>
        /// <param name="value"></param>
        /// 
        public void ChangeMasterVolume(float value)
        {
            AudioListener.volume = value;
        }

        public void ChangeMusicVolume(float value)
        {
            musicSource.volume = value;
        }

        public void ChangeEffectsVolume(float value)
        {
            sfxSource.volume = value;
        }
        #endregion

        #region Toggle 控制
        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        }

        public void ToggleEffects()
        {
            sfxSource.mute = !sfxSource.mute;
        }
        #endregion


    }
}