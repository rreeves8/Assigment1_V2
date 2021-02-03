using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour{
	
	public Text CountText;

	public float density;
	public float scale;

	public GameObject pickup;
	public GameObject main_area;
	public GameObject main_area2;
	public GameObject labrynth_1;
	public GameObject labrynth_2;
	public GameObject labrynth_3;
	public GameObject labrynth_4;
	public GameObject labrynth_5;
	public GameObject labrynth_6;
	public GameObject labrynth_7;
	public GameObject lower_level;
	public GameObject lower_level_entrance_1;
	public GameObject lower_level_entrance_2;

	private int num_of_pickups;
	
	private List<GameObject> list;
	
	void Start(){
		num_of_pickups = 0;
		list = new List<GameObject>();
		list.Add(main_area);
		list.Add(main_area2);
		list.Add(labrynth_1);
		list.Add(labrynth_2);
		list.Add(labrynth_3);
		list.Add(labrynth_4);
		list.Add(labrynth_5);
		list.Add(labrynth_6);
		list.Add(labrynth_7);
		list.Add(lower_level_entrance_1);
		list.Add(lower_level_entrance_2);
		list.Add(lower_level);
		
		placeObjects();
		
	}
	
	void Update(){

		string[] split = CountText.text.Split(' ');

		int pickedUp = int.Parse(split[1]);

		if(pickedUp == num_of_pickups){
			placeObjects();
        }
    }

	void placeObjects(){
		foreach(GameObject plane in list){
			instantiatePickUps(plane, planeSize(plane));
		}
	}

	float planeSize(GameObject plane){
		float area = plane.GetComponent<Renderer>().bounds.size.x * plane.GetComponent<Renderer>().bounds.size.z;
		return area/ density;
	}

	Vector3 randomPlaneVector(GameObject plane){
		float moveAreaX = plane.GetComponent<Renderer>().bounds.size.x / 2;
		float moveAreaZ = plane.GetComponent<Renderer>().bounds.size.z / 2;
		
		Vector3 center = plane.GetComponent<Renderer>().bounds.center;

		float X = center.x + Random.Range(-moveAreaX * scale, moveAreaX * scale);
		float Z = center.z + Random.Range(-moveAreaZ * scale, moveAreaZ * scale);

		float Y = 1f;

		if (plane.transform.position.y < 0){
			Y = -7.1f;
        }

		return new Vector3(X, Y, Z);
	}

	void instantiatePickUps(GameObject plane, float size){
		for (float i = 0; i <= size; i++){
			
			Instantiate(pickup, randomPlaneVector(plane), Quaternion.identity);
			num_of_pickups++;
		}
	}
}
