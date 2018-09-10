﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Stage6 : MonoBehaviour {

    private TextAsset csvFile; // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    public GameObject block;
    public GameObject Sword;
    public GameObject DropSword;
    public GameObject GrowSword;
    public GameObject ReversGrowSword;
    public GameObject ReversSword;

    public int x = -920;
    public int y = 500;

    void Start() {


        csvFile = Resources.Load("Stage6") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1) {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる

        }
        for (int i = 0; i < csvDatas.Count; i++) {
            for (int j = 0; j < 24; j++) {
                if (csvDatas[i][j] == "0") {
                    x += 80;
                }
                else if (csvDatas[i][j] == "1") {
                    Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "2") {
                    Instantiate(Sword, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "3") {
                    Instantiate(DropSword, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "4") {
                    Instantiate(GrowSword, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "5") {
                    Instantiate(ReversGrowSword, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "6") {
                    Instantiate(ReversSword, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
            }
            x = -920;
            y -= 80;
        }
    }
}