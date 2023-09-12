using UnityEngine;
using UnityEngine.UI;
using Sound2Demo;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider wholeVolumeSlider, musicSlider, effectsSlider;

    [SerializeField] private Toggle toggleWholeMusic, toggleMusic, toggleEffects;

    //UI分离

    private void Start()
    {
        //初始化 让音量和面板slider一致
        AudioManager.Instance.ChangeMasterVolume(wholeVolumeSlider.value);
        AudioManager.Instance.ChangeMusicVolume(musicSlider.value);
        AudioManager.Instance.ChangeEffectsVolume(effectsSlider.value);


        //wholeVolumeSlider.onValueChanged.AddListener(value=>WholeVolume());       //不拖拽 加监听事件
        //toggleWholeMusic.onValueChanged.AddListener(value=>ToggleWholeMusic());   //不拖拽 加监听事件
    }

    #region 声音设置
    //Slider
    public void WholeVolume()
    {
        AudioManager.Instance.ChangeMasterVolume(wholeVolumeSlider.value);
    }
    public void MusicVolume()
    {
        AudioManager.Instance.ChangeMusicVolume(musicSlider.value);
    }
    public void EffectsVolume()
    {
        AudioManager.Instance.ChangeEffectsVolume(effectsSlider.value);
    }

    //Toggle 
    public void ToggleWholeMusic()
    {
        if (toggleMusic.isOn == true)
            AudioManager.Instance.ToggleMusic();
        if (toggleEffects.isOn == true)
            AudioManager.Instance.ToggleEffects();
    }
    public void ToggleMusic()
    {
        if (toggleWholeMusic.isOn == false)
            return;
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleEffects()
    {
        if (toggleWholeMusic.isOn == false)
            return;
        AudioManager.Instance.ToggleEffects();
    }
    #endregion

    #region 使用
    public void SFX_Btn()
    {
        AudioManager.Instance.PlaySFX("bomb");
    }

    public void Test_Btn()
    {
        AudioManager.Instance.PlaySFX("yanhua");
    }
    #endregion


}
