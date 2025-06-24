using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] levelPrefabs;

    private GameObject currentLevel;
    private int currentLevelIndex = 0;
    private bool hasWon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("GameManager.Instance đã được khởi tạo");
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        LoadLevel(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            LoadLevel(currentLevelIndex);

        if (Input.GetKeyDown(KeyCode.N))
            LoadLevel(currentLevelIndex + 1);
    }

    public void LoadLevel(int index)
    {
        if (index >= levelPrefabs.Length)
        {
            Debug.Log(" Hết level rồi, không còn để load.");
            return;
        }

        if (currentLevel != null)
        {
            Destroy(currentLevel);
            Debug.Log(" Đã xoá level hiện tại.");
        }

        currentLevelIndex = index;
        currentLevel = Instantiate(levelPrefabs[index]);

        hasWon = false;

        Debug.Log($"▶️ Đã load level {index}");
    }

    public void WinGame()
    {
        if (hasWon)
        {
            Debug.Log("⚠️ WinGame() bị gọi lại, nhưng đã win rồi.");
            return;
        }

        hasWon = true;
        Debug.Log(" WIN! Sẽ chuyển màn sau 4 giây...");

        Invoke(nameof(NextLevel), 4f);
    }

    private void NextLevel()
    {
        int next = currentLevelIndex + 1;

        if (next >= levelPrefabs.Length)
        {
            Debug.Log("Đã hoàn tất tất cả level!");
            return;
        }

        Debug.Log($"Chuyển sang level {next}");
        LoadLevel(next);
    }
}
