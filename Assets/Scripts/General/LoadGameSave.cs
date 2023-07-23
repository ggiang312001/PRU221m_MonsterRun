using Assets.Scripts.ObjectSave;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LoadGameSave : MonoBehaviour
{
    [SerializeField]
    GameObject MediumGround;
    [SerializeField]
    GameObject ShortGround;
    [SerializeField]
    GameObject LongGround;

    public static GameObject LastGround;
    public static bool isLoadFinish = false;

    // Start is called before the first frame update

    void Start()
    {
        
    }
    private static string GetFilePath(string FolderName, string FileName = "")
    {
        string filePath;
        filePath = Path.Combine(Application.persistentDataPath, "data", FolderName);
        if (FileName != "")
            filePath = Path.Combine(filePath, FileName + ".json");
        return filePath;
    }
    // Update is called once per frame
    void Update()
    {
        if (ContinueGame.isContinue == true && ! isLoadFinish)
        {
            Time.timeScale = 1;
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.SetHealth(PlayerPrefs.GetInt("Health", 0));
            hud.SetTimer(PlayerPrefs.GetFloat("Time", 0));
            GameManage.Instance.speed = PlayerPrefs.GetFloat("Speed", 0);
            GameObject StartGround = GameObject.FindGameObjectWithTag("Ground");
            StartGround.SetActive(false);

            string filePath = "";
            filePath = GetFilePath("data", "data");
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
        
            string json = File.ReadAllText(filePath);
            var objs = JsonConvert.DeserializeObject<List<Item>>(json);
            float max = 0;
            foreach (var item in objs)
            {
                if (item.Type.Equals("ground"))
                {
                    if (item.x >= max)
                    {
                        max = item.x;
                    }
                }
            }

            foreach (var item in objs)
            {

                if (item.Type.Equals("trap") && item.Name.Equals("fire"))
                {
                    GameObject fire = FirePool.Instance.GetObject();
                    fire.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("trap") && item.Name.Equals("thorn"))
                {
                    GameObject thorn = ThornPool.Instance.GetObject();
                    thorn.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("trap") && item.Name.Equals("mine"))
                {
                    GameObject mine = MinePool.Instance.GetObject();
                    mine.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("item") && item.Name.Equals("heart"))
                {
                    GameObject heart = HeartPool.Instance.GetObject();
                    heart.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("item") && item.Name.Equals("snow"))
                {
                    GameObject snow = SnowPool.Instance.GetObject();
                    snow.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("monter") && item.Name.Equals("fighter"))
                {
                    GameObject fighter = FighterPool.Instance.GetObject();
                    fighter.transform.position = new Vector3(item.x, item.y, 0);
                }
                if (item.Type.Equals("monter") && item.Name.Equals("wizard"))
                {
                    GameObject wizard = WizardPool.Instance.GetObject();
                    wizard.transform.position = new Vector3(item.x, item.y, 0);
                }


                if (item.Type.Equals("ground"))
                {
                    if (item.Name.Equals("longground"))
                    {

                        GameObject longGround = Instantiate<GameObject>(LongGround, new Vector3(item.x, item.y, 0), Quaternion.identity);
                        if (item.x == max)
                        {
                            LastGround = longGround;
                        }
                    }
                    if (item.Name.Equals("shortground"))
                    {
                        GameObject shortGround = Instantiate<GameObject>(ShortGround, new Vector3(item.x, item.y, 0), Quaternion.identity);
                        if (item.x == max)
                        {
                            LastGround = shortGround;
                        }
                    }
                    if (item.Name.Equals("mediumground"))
                    {
                        GameObject mediumGround = Instantiate<GameObject>(MediumGround, new Vector3(item.x, item.y, 0), Quaternion.identity);
                        if (item.x == max)
                        {
                            LastGround = mediumGround;
                        }
                    }
                }
                string playerFilePath = "";
                playerFilePath = GetFilePath("data", "player");
                if (!Directory.Exists(Path.GetDirectoryName(playerFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(playerFilePath));
                }

                string json1 = File.ReadAllText(playerFilePath);
                var player = JsonConvert.DeserializeObject<Player>(json1);
                GameObject playerLoad = GameObject.FindGameObjectWithTag("Player");
                playerLoad.transform.position = new Vector3(player.x,player.y);
                //ContinueGame.isContinue = false;
                isLoadFinish = true;    
            }
        }
    }
}
