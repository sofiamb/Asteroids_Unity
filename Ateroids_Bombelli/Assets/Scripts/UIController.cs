using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject losePanel;
    public TMP_Text pointsText;
    public int totalPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanel() {
        StartCoroutine(showLosePanel());
    }
    private IEnumerator showLosePanel()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(2);
        losePanel.SetActive(false);
    }

    public void setPoints(int points) {
        totalPoints += points;
        pointsText.text = totalPoints.ToString();
    }
}
