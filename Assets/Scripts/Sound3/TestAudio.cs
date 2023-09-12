using UnityEngine;
using Sound3Demo;

public class TestAudio : MonoBehaviour
{
    #region 使用
    public void Test_Btn()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clips[2]);
    }

    #endregion

}
