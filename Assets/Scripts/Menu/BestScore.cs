using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    private TextMeshProUGUI best;

    void Start()
    {
        best = GetComponent<TextMeshProUGUI>();
        best.SetText(GameManager.Instance.GetBestScore());
    }
}
