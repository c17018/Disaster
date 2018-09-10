using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StageGenerator:MonoBehaviour {
    TextAsset csvFile; // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    [SerializeField]
    GameObject[] Blocks;

    public int x = -920;
    public int y = 500;

    void Start() {
        csvFile = Resources.Load("Stage" + (SceneManager.GetActiveScene().buildIndex)) as TextAsset; /* Resouces/CSV下のCSV読み込み */

        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1) {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる

        }
        for (int i = 0; i < csvDatas.Count; i++) {
            for (int j = 0; j < csvDatas[i].Length; j++) {
                int n = int.Parse(csvDatas[i][j]);
                if(n > 0){
                    Instantiate(Blocks[n - 1], new Vector2(x, y), Quaternion.identity);
                }
                x += 80;
            }
            x = -920;
            y -= 80;
        }
    }
}