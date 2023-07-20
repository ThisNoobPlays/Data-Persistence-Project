using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{
    class SaveData
    {
        public int bestScore;
        public string bestName;
    }

    [SerializeField] private TMP_InputField textInput;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private int bestScore = 0;
    private string bestName = "";

    // Start is called before the first frame update
    void Start()
    {
        string savePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            bestName = data.bestName;
        }

        bestScoreText.SetText("Best Score : " + bestName + " : " + bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        string name = textInput.text;
        PersistentData.Instance.name = name;
        PersistentData.Instance.bestScore = bestScore;
        PersistentData.Instance.bestName = bestName;

        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
