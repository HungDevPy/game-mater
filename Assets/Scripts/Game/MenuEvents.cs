using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        Time.timeScale = 1;

        // Kiểm tra nếu volumeSlider và mixer không null trước khi sử dụng
        if (volumeSlider != null && mixer != null)
        {
            mixer.GetFloat("volume", out value);
            volumeSlider.value = value;
        }
        else
        {
            Debug.LogError("volumeSlider or mixer is not assigned in the inspector.");
        }
    }

    public void SetVolume()
    {
        if (mixer != null && volumeSlider != null)
        {
            mixer.SetFloat("volume", volumeSlider.value);
        }
        else
        {
            Debug.LogError("volumeSlider or mixer is not assigned in the inspector.");
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitExe()
    {
        Application.Quit();
       Debug.LogError("Da Nhan");
       
    }
}
