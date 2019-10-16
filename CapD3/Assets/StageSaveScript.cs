﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recordforstage2
{
    private int rank;
    private string username;
    private float cleartime;
    //private int stagenum;

    public int Rank
    {
        set { this.rank = value; }
        get { return this.rank; }
    }
    public string Username
    {
        set { this.username = value; }
        get { return this.username; }
    }
    public float Cleartime
    {
        set { this.cleartime = value; }
        get { return this.cleartime; }
    }/*
    public int Stagenum
    {
        set { this.stagenum = value; }
        get { return this.stagenum; }
    }*/
    public recordforstage2()
    {
        rank = 0;
        username = "undefined in class";
        cleartime = 0f;
        //Stagenum = StageSaveScript.StageNum;
    }
}
public class StageSaveScript : MonoBehaviour
{
    public static int StageNum;
    public static int StageSave = 0;
    int getnum;
    private static bool onepls=false;
    public static recordforstage2[,] records = new recordforstage2[3,9];

    public void globalfunc1()
    {
        Debug.Log("connectsuceess!!");
        Debug.Log("connectsuceess!!");
        Debug.Log("connectsuceess!!");
        Debug.Log("connectsuceess!!");
        Debug.Log("connectsuceess!!");
    }
    // Start is called before the first frame update
    void Awake()
    {
        donotdestory();
    }
    void donotdestory()
    {
        if (onepls == false)
        {
            DontDestroyOnLoad(gameObject);
            onepls = true;
        }
    }
    public void checknum()
    {
        getnum = StageNum;
        getnum -= 1;
        if (StageNum == -2)
        {
            getnum = 0;
        }
        if (getnum == 100)
        {
            getnum = 2;
        }
    }
    public int getgetnum()
    {
        return getnum;
    }

    void Start()
    {
        
        //setdefaultrecords();
    }
    /*
    public void setdefaultrecords()
    {

        //Debug.Log(records[0]);
        Debug.Log(records[0].Rank);
        for (int i=0; i < records.Length; i++)
        {
            if(records[i] == null)
            {
                records[i].Rank = i+1;
                records[i].Username = "undefined";
                records[i].Cleartime = 0.0f;
                records[i].Stagenum = StageNum;
            }
        }
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
    public void Makerecord1fortest(string Useraname1,float time1 )
    {
        recordforstage2 recordvalue1 = new recordforstage2();
        recordvalue1.Rank = setrank(time1);
        recordvalue1.Username = Useraname1;
        recordvalue1.Cleartime = time1;
        //recordvalue1.Stagenum = StageNum;
        //Debug.Log("rank : " + recordvalue1.Rank);
        //Debug.Log("Username : " + recordvalue1.Username);
        //Debug.Log("Cleartime : " + recordvalue1.Cleartime);
        //Debug.Log("Stagenum : " + recordvalue1.Stagenum);
        setinrecords(recordvalue1);
    }

    public void setinrecords(recordforstage2 newreco)
    {
        checknum();
        int newrank = 1;
        for(int i=0; i < records.GetLength(1); i++)
        {
            if (records[getnum,i] == null)
            {
                records[getnum, i] = newreco;
                break;
            }
            else
            {
                if (records[getnum, i].Cleartime > newreco.Cleartime)
                {
                    for (int j = records.GetLength(1) - 1; j > i; j--)
                    {
                        if (records[getnum, j - 1] != null)
                        {
                            records[getnum, j] = records[getnum, j - 1];
                            records[getnum, j].Rank++;
                        }
                    }
                    records[getnum, i] = newreco;
                    break;
                }
                else
                    newrank++;
            }
        }
        Debug.Log(newrank);
        showrecords();
    }

    public void showrecords()
    {
        checknum();
        for (int i=0; i < records.GetLength(1); i++)
        {
            if(records[getnum,i] != null)
            {
                Debug.Log(records[getnum, i].Cleartime);
                Debug.Log(records[getnum, i].Rank);
            }
        }
    }

    public int setrank(float time1)
    {
        checknum();
        int guessrank = 1;
        for (int i =0; i < records.GetLength(1); i++)
        {
            Debug.Log(getnum);
            if (records[getnum, i] != null && time1 >= records[getnum, i].Cleartime )
            {
                guessrank++;
            }
        }
        return guessrank;
    }
    public void globalfunc2()
    {
        if (StageNum == -1)
            Debug.Log("stagenum -1 ? : " + StageSaveScript.StageNum);
    }
}
