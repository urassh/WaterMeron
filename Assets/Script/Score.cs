using TMPro;
using UnityEngine;

class Score : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreValueText;
    private int score = 0;

    public void AddScore(FruitTag fruitTag) {
        switch (fruitTag) {
            case FruitTag.Level1:
                score += 10;
                break;
            case FruitTag.Level2:
                score += 20;
                break;
            case FruitTag.Level3:
                score += 30;
                break;
            case FruitTag.Level4:
                score += 40;
                break;
            case FruitTag.Level5:
                score += 50;
                break;
            case FruitTag.Level6:
                score += 60;
                break;
        }

        scoreValueText.text = score.ToString();
    }
}
