using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSquare : MonoBehaviour
{
	public Transform[] Positions;
	public GameObject Object;
	public Transform Location;
	public bool ToSpawn = true;

	void Update()
	{
		Location = Positions[Random.Range(0, Positions.Length)];

		if (ToSpawn == true)
		{
			Instantiate(Object, Location);
			ToSpawn = false;
			StartCoroutine(ToSpawnTrue());
		}
	}

	IEnumerator ToSpawnTrue()
	{
		yield return new WaitForSeconds(0.75f);
		ToSpawn = true;
	}
}
