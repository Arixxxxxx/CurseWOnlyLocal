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
    public int battleTime; // �� �����ð�(��)
    public int bossKillCount; // ����ų ī����
    public int totalKillEnemy; // ��Ż ���ʹ� ī����
    public int LevelUpCount; // ��Ż ������ ī����
    public int playerDeadCount; // �÷��̾� ���

    public UserGameInfo(int battleTime, int bossKillCount, int totalKillEnemy, int LevelUpCount, int playerDeadCount) // ������
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

   //�ű�ȸ������
    public void F_NewUserSet(string UserEmail)
    {
        UserGameInfo user = new UserGameInfo(0,0,0,0,0);
        string json = JsonUtility.ToJson(user); // Json���� ��ȯ
        UserEmail = UserEmail.Replace(".", ""); // .�� �������� �ν��� ����
        
    }


    // ���̺�
    public void F_SaveGameAndServerUpload(UserGameInfo data)
    {
        string json = JsonUtility.ToJson(data); // ���� ��� Json���� ��ȯ
        
     }

   
    public UserGameInfo F_GetUserData()
    {
        return curruntPlayUserInfo;
    }

    /// <summary>
    /// �����̸��Ͽ��� �պκи� �������� �Լ�
    /// </summary>
    /// <returns></returns>
    public string F_GetUserID()
    {
        string[] result = userEmail.Split("@");
        return result[0];
    }
}
