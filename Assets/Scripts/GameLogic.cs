using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour {
    [SerializeField] private BallScript ballScript;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private GameObject gameOverScreen;
    public int hpAmount = 3;

    void Update() {
        hp.text = hpAmount.ToString();
        if (hpAmount < 0) {
            Debug.Log("Game Over"); 
        } 
        if(hpAmount == -1) {
            hp.text = "X";
            gameOverScreen.SetActive(true);
        }
    }
    public void decreaseLHP() {
        hpAmount--;
    }
}
