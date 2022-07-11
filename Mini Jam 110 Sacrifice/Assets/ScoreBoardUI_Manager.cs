using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardUI_Manager : MonoBehaviour
{
  public ScoreBoard_SO data;

  public TextMeshProUGUI highScoreText;
  public List<TextMeshProUGUI> scoreTexts;

  public void updateScore(){
    data.GetLatestSave();

    highScoreText.text = "" + data.GetHighScore();

    for(int i = 0; i < scoreTexts.Count; ++i){
      scoreTexts[i].text = "" + data.GetScoreAtIndext(i + 1);
    }
  }
}
