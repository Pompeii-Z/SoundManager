using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider, sfxSlider;

    private void Start()
    {
        //如果设置过音量，就读取音量并设置
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else//否则让音量等于UI上的设置值
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);//Slider值和AudioMixer转换
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);//Slider值和AudioMixer转换
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }


    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void Teleport()
    {
        SceneManager.LoadScene("SoundDemo4");
    }

}
