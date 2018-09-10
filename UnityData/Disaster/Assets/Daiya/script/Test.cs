using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Test : MonoBehaviour {

    // Use this for initialization

    private TextAsset csvFile; // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    public GameObject block;
    public GameObject kenzan;
    public GameObject rakka;
    public GameObject haeru;
    public GameObject haerusakasa;
    public GameObject kennzannsakasa;




    public int x = -920;
    public int y = 500;

    void Start() {
     

        csvFile = Resources.Load("Stage2") as TextAsset; /* Resouces/CSV下のCSV読み込み */
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
                    Instantiate(kenzan, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "3") {
                    Instantiate(rakka, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "4") {
                    Instantiate(haeru, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "5") {
                    Instantiate(haerusakasa, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
                else if (csvDatas[i][j] == "6") {
                    Instantiate(kennzannsakasa, new Vector3(x, y, 0), Quaternion.identity);
                    x += 80;
                }
            }
            x = -920;
            y -= 80;
        }
    }
}