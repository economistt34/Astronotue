using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI scoreText;
  public bool delete;
  
  private int coins;

  void Start() => coins = PlayerPrefs.GetInt("Coins");

  void Update() => scoreText.text = "Coins: " + coins;

  public void AddCoins() => coins += 5;

  

  public void OnBackButtonPressed()
  {
    PlayerPrefs.SetInt("Coins", coins);
    //SceneManager.LoadScene("MainMenuScene");
  }
 
  
}
