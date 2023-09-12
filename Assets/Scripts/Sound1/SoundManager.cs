using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicSource, effectSource;

    [SerializeField] private Slider wholeVolumeSlider, musicSlider, effectsSlider;

    [SerializeField] private Toggle toggleWholeMusic, toggleMusic, toggleEffects;

    //应该在UI脚本中给slider toggle 赋方法，此处省事。在UI管理，可见SoundDemo2场景示例
    private void Start()
    {
        //初始化
        ChangeMasterVolume(wholeVolumeSlider.value);
        wholeVolumeSlider.onValueChanged.AddListener(value => ChangeMasterVolume(value));

        ChangeMusicVolume(musicSlider.value);
        musicSlider.onValueChanged.AddListener(value => ChangeMusicVolume(value));

        ChangeEffectsVolume(effectsSlider.value);
        effectsSlider.onValueChanged.AddListener(value => ChangeEffectsVolume(value));

        toggleMusic.onValueChanged.AddListener(value => ToggleMusic());
        toggleEffects.onValueChanged.AddListener(value => ToggleEffects());
        toggleWholeMusic.onValueChanged.AddListener(value => ToggleWholeMusic());

    }

    /// <summary>
    /// 播放音效  
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySFXSound(AudioClip clip)
    {
        if (clip is null)
            Debug.Log("没有音频");
        else
            effectSource.PlayOneShot(clip);
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        if (clip is null)
            Debug.Log("没有音频");
        else
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    //声音设置
    #region Slider 控制
    /// <summary>
    /// 主音量
    /// </summary>
    /// <param name="value"></param>
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
        effectSource.volume = value;
    }
    #endregion

    #region Toggle 控制 
    public void ToggleWholeMusic()
    {
        if (toggleMusic.isOn == true)
            musicSource.mute = !musicSource.mute;
        if (toggleEffects.isOn == true)
            effectSource.mute = !effectSource.mute;
    }

    public void ToggleMusic()
    {
        if (toggleWholeMusic.isOn == false)
            return;

        musicSource.mute = !musicSource.mute;
    }

    public void ToggleEffects()
    {
        if (toggleWholeMusic.isOn == false)
            return;

        effectSource.mute = !effectSource.mute;
    }
    #endregion

}
