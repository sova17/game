using UnityEngine;
using System.Collections;

public class GridManager: MonoBehaviour
{
	public GameObject Hex;
	public Vector3 startPoint;
	public int gridWidthInHexes;
	public int gridHeightInHexes;
	public Material hexMaterial;
	float edge = 50.0f;
	
	public Vector3 getNord()
	{
		return Mathf.Sqrt(3) * Vector3.forward;
	}

	public Vector3 getSouth()
	{
		return Mathf.Sqrt(3) * Vector3.back;
	}

	public Vector3 getSW()
	{
		return new Vector3(- 1.5f, 0,  -  Mathf.Sqrt(3)/2);
	}

	public Vector3 getSE()
	{
		return new Vector3(1.5f, 0, 0 -  Mathf.Sqrt(3)/2);
	}

	public Vector3 getNW()
	{
		return new Vector3(- 1.5f, 0, Mathf.Sqrt(3)/2);
	}

	public Vector3 getNE()
	{
		return new Vector3(1.5f, 0, Mathf.Sqrt(3)/2);
	}
	
	void createGrid()
	{
		GameObject hexGrid = new GameObject("HexGrid");
		hexGrid.transform.parent = GameObject.FindGameObjectWithTag("World").transform;
		hexGrid.transform.position = startPoint;
		GameObject mapGO = new GameObject("MapGO");
		mapGO.AddComponent<Map>();
		//mapGO.GetComponent<Map>().Initialize(gridWidthInHexes, gridHeightInHexes);
		for (int x = 0; x < gridWidthInHexes; x++)
		{
			for (int z = 0; z < gridHeightInHexes; z++)
			{
				Vector3 coordinate = startPoint + x * edge * getNE() + z * edge * getNord();
				GameObject hex = (GameObject) Instantiate(Hex);
				hex.transform.position = coordinate;
				hex.GetComponent<Cell>().X = x;
				hex.GetComponent<Cell>().Z = z;
				hex.transform.parent = hexGrid.transform;
				hex.renderer.material = hexMaterial;
				mapGO.GetComponent<Map>()[x, z] = hex.GetComponent<Cell>();
			}
		}
	}
}