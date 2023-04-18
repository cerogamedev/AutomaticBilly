using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static int tree=0, stone=0, gold = 0;
    public TextMeshProUGUI treeTxt, stoneTxt, goldTxt;
    public static float LevelIndex=1;
    public GameObject UpgradeButton;
    void Start()
    {
        UpgradeButton.SetActive(false);
    }

    void Update()
    {
        ObjectDestroyer.destroyTime = Mathf.Clamp(4 - LevelIndex / 10, 01, 4);

        stoneTxt.text = "Stone "+ stone.ToString();
        treeTxt.text = "Tree " + tree.ToString();
        goldTxt.text = "Gold " + gold.ToString();
        if (stone == LevelIndex * 10 && tree == LevelIndex * 10 && stone == LevelIndex * 10)
        {
            UpgradeButton.SetActive(true);
        }
    }
    public void LevelUpgrade()
    {
        LevelIndex += 0.2f;
        UpgradeButton.SetActive(false);

    }
}
