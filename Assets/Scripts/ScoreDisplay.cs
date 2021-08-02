using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _text;
    private int _score = 0;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        _score++;

        _text.text = _score.ToString();
    }
}
