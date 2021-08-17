using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject gameCam;
    public Player player;
    public Boss boss;
    public GameObject itemShop;
    public GameObject WeaponShop;
    public GameObject startZone;
    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;
    public int enemyCntD;

    public Transform[] enemyZones;
    public GameObject[] enemise;
    public List<int> enemyList;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject OverPanel;
    public Text maxScoreText;
    public Text scoreText;
    public Text stageText;
    public Text playTimeText;
    public Text playerHealthText;
    public Text playerAmmoText;
    public Text playCoinText;
    public Image Weapon1Img;
    public Image Weapon2Img;
    public Image Weapon3Img;
    public Image WeaponRImg;
    public Text enemyAText;
    public Text enemyBText;
    public Text enemyCText;
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;
    public Text curScoreText;
    public Text bestText;

    void Awake()
    {
        enemyList = new List<int>();
        maxScoreText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
    }
    public void GameStart()
    {
        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);
    }public void GameOver()
    {
        gamePanel.SetActive(false);
        OverPanel.SetActive(true);
        curScoreText.text = scoreText.text;

        int maxScore = PlayerPrefs.GetInt("MaxScore");
        if (player.score > maxScore)
        {
            bestText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("MaxScore", player.score);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StageStart()
    {
        itemShop.SetActive(false);
        WeaponShop.SetActive(false);
        startZone.SetActive(false);

        foreach (Transform zone in enemyZones)
            zone.gameObject.SetActive(true);
        
        isBattle = true;
        StartCoroutine(InBattle());
    }
    public void StageEnd()
    {
        player.transform.position=Vector3.up*0.8f;

        itemShop.SetActive(true);
        WeaponShop.SetActive(true);
        startZone.SetActive(true);

        foreach (Transform zone in enemyZones)
            zone.gameObject.SetActive(false);

        isBattle = false;
        stage++;
    }
    IEnumerator InBattle()
    {
        if (stage % 5 == 0)
        {
            enemyCntD++;
            GameObject instanEnemy = Instantiate(enemise[3], enemyZones[0].position, enemyZones[0].rotation);
            Enemy enemy = instanEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            enemy.manager = this;
            boss = instanEnemy.GetComponent<Boss>();
        }
        else
        {
            for (int index = 0; index < stage; index++)
            {
                int ran = Random.Range(0, 3);
                enemyList.Add(ran);

                switch (ran)
                {
                    case 0:
                        enemyCntA++;
                        break;
                    case 1:
                        enemyCntB++;
                        break;
                    case 2:
                        enemyCntC++;
                        break;

                }
            }
            while (enemyList.Count > 0)
            {
                //몬스터 스폰
                int ranzone = Random.Range(0, 4);
                GameObject instanEnemy = Instantiate(enemise[enemyList[0]], enemyZones[ranzone].position, enemyZones[ranzone].rotation);
                Enemy enemy = instanEnemy.GetComponent<Enemy>();
                enemy.target = player.transform;
                enemy.manager = this;
                enemyList.RemoveAt(0);
                yield return new WaitForSeconds(4f);
            }
        }
        while (enemyCntA+enemyCntB+enemyCntC+enemyCntD>0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3f);

        boss = null;
        StageEnd();
    }
    
    void Update()
    {
        if (isBattle)
            playTime += Time.deltaTime;
    }
    void LateUpdate()
    {
        //상단UI
        scoreText.text = string.Format("{0:n0}",player.score);
        stageText.text = "STAGE" + stage;

        int hour = (int)(playTime / 3600);
        int min = (int)(playTime-hour*3600 / 60);
        int second = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}", hour)+":"+ string.Format("{0:00}", min)+":"+ string.Format("{0:00}", second);

        //플레이어 UI
        playerHealthText.text = player.health + "/" + player.maxHealth;
        playCoinText.text = string.Format("{0:n0}", player.coin);
        if (player.equipWeapon == null)
            playerAmmoText.text = "- / " + player.ammo;
        else if (player.equipWeapon.type == Weapon.Type.Melee)
            playerAmmoText.text = "- / " + player.ammo;
        else
            playerAmmoText.text = player.equipWeapon.curAmmo + " / " + player.ammo;

        //무기 UI
        Weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        Weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        Weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        WeaponRImg.color = new Color(1, 1, 1, player.hasGrenades > 0 ? 1 : 0);

        //몬스터 숫자 UI
        enemyAText.text = enemyCntA.ToString();
        enemyBText.text = enemyCntB.ToString();
        enemyCText.text = enemyCntC.ToString();

        //보스 체력UI
        if(boss != null)
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;
            bossHealthBar.localScale = new Vector3((float)boss.curHealth / boss.maxHealth, 1, 1);
        }
        else
        {
            bossHealthGroup.anchoredPosition = Vector3.up * 200;
        }
            
    }
}
