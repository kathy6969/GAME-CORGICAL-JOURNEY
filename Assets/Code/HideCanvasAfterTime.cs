using UnityEngine;
using System.Collections;

public class HideCanvasAfterTime : MonoBehaviour
{
    public float delay = 3f;         // Thời gian chờ (3 giây mặc định)
    public Canvas targetCanvas;      // Canvas muốn ẩn (kéo vào từ Inspector)

    void Start()
    {
        if (targetCanvas != null)
        {
            StartCoroutine(HideAfterDelay());
        }
        else
        {
            Debug.LogWarning("⚠️ Chưa gán Canvas vào script HideCanvasAfterTime.");
        }
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        targetCanvas.gameObject.SetActive(false);
        Debug.Log("✅ Đã ẩn Canvas sau " + delay + " giây.");
    }
}
