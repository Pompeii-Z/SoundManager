using UnityEngine;

public class TestSound : MonoBehaviour
{
    //提前存储音频
    [SerializeField] private AudioClip[] SFX_clips;
    [SerializeField] private AudioClip[] Music_clips;

    private void Start()
    {
        SoundManager.Instance.PlaySound(Music_clips[0]);
    }

    public void SFX_Btn()
    {
        SoundManager.Instance.PlaySFXSound(SFX_clips[0]);
    }

    public void Test_btn()
    {
        SoundManager.Instance.PlaySound(SFX_clips[1]);
    }
}
