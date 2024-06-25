using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60f; // Thời gian đếm ngược ban đầu
    public Text timerText; // Đối tượng Text hiển thị thời gian
    public GameObject gameOverScreen; // Panel hiển thị khi kết thúc thời gian

    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay(); // Cập nhật hiển thị ban đầu
        StartCountdown(); // Bắt đầu đếm ngược
    }

    void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f); // Chờ 1 giây
            currentTime -= 1f; // Giảm thời gian đi 1 giây
            UpdateTimerDisplay(); // Cập nhật hiển thị
        }

        // Đã kết thúc đếm ngược
        TimerEnded();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Hiển thị đồng hồ đếm ngược dưới dạng "Thời Gian: 00:00"
        timerText.text = string.Format("Thời Gian: {0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Countdown Timer Ended!");
        PlayerManager.isGameOver = true;
        AudioManager.instance.Play("GameOver");
        gameOverScreen.SetActive(true); // Hiển thị màn hình game over
        gameObject.SetActive(false);
        // Thực hiện hành động khi đồng hồ đếm ngược kết thúc
    }
}
