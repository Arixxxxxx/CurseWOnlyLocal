using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum CharacterNum
{
    Female, Male
}

[Serializable]
public class UserGameInfo
{
    public int battleTime; // 총 전투시간(초)
    public int bossKillCount; // 보스킬 카운터
    public int totalKillEnemy; // 토탈 에너미 카운터
    public int LevelUpCount; // 토탈 레벨업 카운터
    public int playerDeadCount; // 플레이어 사망

    public UserGameInfo(int battleTime, int bossKillCount, int totalKillEnemy, int LevelUpCount, int playerDeadCount) // 생성자
    {
        this.battleTime = battleTime;
        this.bossKillCount = bossKillCount;
        this.totalKillEnemy = totalKillEnemy;
        this.LevelUpCount = LevelUpCount;
        this.playerDeadCount = playerDeadCount;
    }
}
public class DataManager : MonoBehaviour
{

    public static DataManager inst;
    public CharacterNum CurrentCharacter;
    public int curNum { get { return (int)CurrentCharacter; } }


    
    [SerializeField] string userEmail;
    public string UserName { get { return userEmail; }  set { userEmail = value; } }

    [SerializeField] private UserGameInfo curruntPlayUserInfo;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

             
    }
    void Start()
    {
       
    }

   //신규회원가입
    public void F_NewUserSet(string UserEmail)
    {
        UserGameInfo user = new UserGameInfo(0,0,0,0,0);
        string json = JsonUtility.ToJson(user); // Json파일 변환
        UserEmail = UserEmail.Replace(".", ""); // .을 서버에서 인식을 못함
        
    }


    // 세이브
    public void F_SaveGameAndServerUpload(UserGameInfo data)
    {
        string json = JsonUtility.ToJson(data); // 현재 기록 Json파일 변환
        
     }

   
    public UserGameInfo F_GetUserData()
    {
        return curruntPlayUserInfo;
    }

    /// <summary>
    /// 유저이메일에서 앞부분만 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public string F_GetUserID()
    {
        string[] result = userEmail.Split("@");
        return result[0];
    }
}
