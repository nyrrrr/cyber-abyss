using UnityEngine;
using System.Collections;

public class LevelGeneration : MonoBehaviour {

	private GameObject BFH1;
	private GameObject BFH2;
	private GameObject BFH3;
	private GameObject BFH4;
	private GameObject BWS1;
	private GameObject BWS2;
	private GameObject BWS3;
	private GameObject ES1;
	private GameObject ES2;
	private GameObject ES3;
	private GameObject ES4;
	private GameObject VS1;
	private GameObject MB1;

	private GameObject LevelPrefab;
	private GameObject MainGame;


	void Awake () {
		MainGame = GameObject.Find ("MainGame");

		BFH1 = Resources.Load ("LevelSets/BarrierFlatHorizontalFollow1") as GameObject; // 1
		BFH2 = Resources.Load ("LevelSets/BarrierFlatHorizontalFollow2") as GameObject; // 2
		BFH3 = Resources.Load ("LevelSets/BarrierFlatHorizontalFollow3") as GameObject; // 3
		BFH4 = Resources.Load ("LevelSets/BarrierFlatHorizontalFollow4") as GameObject; // 4
		
		BWS1 = Resources.Load ("LevelSets/BarrierWallSet1") as GameObject; // 5
		BWS2 = Resources.Load ("LevelSets/BarrierWallSet2") as GameObject; // 6
		BWS3 = Resources.Load ("LevelSets/BarrierWallSet3") as GameObject; // 7
		
		ES1 = Resources.Load ("LevelSets/EnemySet1") as GameObject; // 8
		ES2 = Resources.Load ("LevelSets/EnemySet2") as GameObject; // 9
		ES3 = Resources.Load ("LevelSets/EnemySet3") as GameObject; // 10
		ES4 = Resources.Load ("LevelSets/EnemySet4") as GameObject; // 11
		
		VS1 = Resources.Load ("LevelSets/VerticalSet1") as GameObject; // 12
		MB1 = Resources.Load ("MasterBoss") as GameObject; // 13
	}

	// Use this for initialization
	void Start () {
		print (BWS1.transform.name);
		// Sample Level
		int[] set = new int[] {0,1,5,9,0,2,3,2,10,0,7,11,4,12,0,8,9,7,5, 12,12,13};
		float xpos = -0.7f, ypos = 75f, plus = 0;

		for(int i=0; i<set.Length; i++)
		{
			plus = 100;
			if(set[i] > 0)
			{
				GameObject instantiate = BFH1;
				xpos = -0.7f;

				switch (set[i])
				{
				case 1:
					instantiate = BFH1;
					xpos = -1.22f;
					plus = 60;
					break;
				case 2:
					instantiate = BFH2;
					xpos = -1.22f;
					plus = 60;
					break;
				case 3:
					instantiate = BFH3;
					xpos = -1.22f;
					plus = 60;
					break;
				case 4:
					instantiate = BFH4;
					xpos = -1.22f;
					plus = 60;
					break;
				case 5:
					instantiate = BWS1;
					break;
				case 6:
					instantiate = BWS2;
					break;
				case 7:
					instantiate = BWS3;
					break;
				case 8:
					instantiate = ES1;
					xpos = 0.25f;
					plus = 100;
					break;
				case 9:
					instantiate = ES2;
					xpos = 0.25f;
					plus = 100;
					break;
				case 10:
					instantiate = ES3;
					xpos = 0.25f;
					plus = 100;
					break;
				case 11:
					instantiate = ES4;
					xpos = 0.25f;
					break;
				case 12:
					instantiate = VS1;
					break;
				case 13:
					instantiate = MB1;
					break;
				}
				print (xpos);
				LevelPrefab = GameObject.Instantiate(instantiate, new Vector3(0, ypos, 10), Quaternion.Euler(Vector2.zero)) as GameObject;
				LevelPrefab.transform.parent = MainGame.transform;
			}

			ypos -= plus;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
