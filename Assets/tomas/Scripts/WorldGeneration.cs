using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {
    public GameManager gameManager;
    float globalLength;
    float staticGlobalLength;

    public GameObject[] segments;
    public float[] segmentsSpawnChance;
    float[] segmentsSpawnChanceSorted;
    float[] segmentsSpawnChanceSum;
    float totalChance = 0;
    float random;
    int[] spawnId;

    private GameObject lastTile;
    float[] segmentSizesX;

    public float posOffsetX = -40.0f;
    public float posOffsetY = 0.0f;
    public float posOffsetZ = 0.0f;
    private Vector3 pos;

    private GameObject mainPlayer;
    public int firstTileGenerationAmount = 15;

    public float startTileDeletionFrom = 10.0f;
    float elementDeletionPos;

    private List<GameObject> tileClone = new List<GameObject>();
    private float posToGenerateFrom = 0.0f;

    public bool hasSpaces;
    [HideInInspector]
    public float gapMinDistance = 0;
    [HideInInspector]
    public float gapMaxDistance = 10;

    void Start () {
        //Assign game manager if null
        if (gameManager == null)
        {
            if(GetComponentInParent<GameManager>() != null)
            {
                gameManager = GetComponentInParent<GameManager>();
            }
            else
            {
                Debug.LogError("Parent object must have Game Manager script assigned", this);
            }
        }

        globalLength = gameManager.globalWorldGenerationLength;
        staticGlobalLength = globalLength; 

        //Copy chance array and sum new array
        segmentsSpawnChanceSorted = new float[segmentsSpawnChance.Length];
        segmentsSpawnChanceSum = new float[segmentsSpawnChance.Length];
        spawnId = new int[segmentsSpawnChance.Length];
        for (int i = 0; i < segmentsSpawnChanceSorted.Length; i++)
        {
            segmentsSpawnChanceSorted[i] = segmentsSpawnChance[i];

            for(int j = 0; j <= i; j++)
            {
                segmentsSpawnChanceSum[i] += segmentsSpawnChance[j];
            }
        }
        //Sort array
        ArraySort(segmentsSpawnChanceSorted);

        //Count total chance
        for (int i = 0; i < segmentsSpawnChance.Length; i++)
        {
            totalChance = totalChance + segmentsSpawnChance[i];
        }
        //Find main player, FUTURE CHANGES: find all players
        mainPlayer = GameObject.FindGameObjectWithTag("Player");

        //Assign lengths by various segments
        Mesh[] meshes;
        Bounds[] bounds;
        meshes = new Mesh[segments.Length];
        bounds = new Bounds[segments.Length];
        segmentSizesX = new float[segments.Length];

        //Find the size of the tiles
        for (int i = 0; i < segments.Length; i++)
        {
            if(meshes[i] != null)
            {
                meshes[i] = segments[i].GetComponent<MeshFilter>().sharedMesh;
                bounds[i] = meshes[i].bounds;
                segmentSizesX[i] = meshes[i].bounds.size.x * segments[i].transform.localScale.x;
            }
            else
            {
                meshes[i] = segments[i].GetComponentInChildren<MeshFilter>().sharedMesh;
                bounds[i] = meshes[i].bounds;
                segmentSizesX[i] = meshes[i].bounds.size.x * segments[i].transform.localScale.x;
            }
        }

        //Generate the tiles of the first element
        pos = new Vector3(posOffsetX, posOffsetY, posOffsetZ);
        for (int i = 0; i < firstTileGenerationAmount; i++)
        {
            if(i == 0)
                GenerateSegments(segments[0], segments[0], segmentSizesX[0]);
            else
                GenerateSegments(segments[0], tileClone[tileClone.Count - 1], segmentSizesX[0]);
        }
        for(int i = 0; i < spawnId.Length; i++)
        {
            Debug.Log("SpawnID" + spawnId[i]);
        }
	}
	
	void Update () {
        if (mainPlayer.transform.position.x > posToGenerateFrom)
        {
            //Generate further tiles
            int randomBlock;

            random = Random.Range(0, totalChance);
            Debug.Log("Random range is: " + random);
            for (int i = 0; i < segmentsSpawnChanceSum.Length; i++)
            {
                if (i == 0)
                {
                    if (random >= 0 && random < segmentsSpawnChanceSum[i])
                    {
                        randomBlock = i;
                        Debug.Log("if i == 0, Random block id: " + randomBlock + " segmentsSpawnChanceSum is: " + segmentsSpawnChanceSum[i]);
                        GenerateSegments(segments[randomBlock], tileClone[tileClone.Count - 1], segmentSizesX[randomBlock]);
                    }
                }
                else
                {
                    if (random >= segmentsSpawnChanceSum[i - 1] && random < segmentsSpawnChanceSum[i])
                    {

                        randomBlock = i;
                        Debug.Log("Random block id: " + randomBlock + " segmentsSpawnChanceSum is: " + segmentsSpawnChanceSum[i]);
                        GenerateSegments(segments[randomBlock], tileClone[tileClone.Count - 1], segmentSizesX[randomBlock]);
                    }
                }
            }
            globalLength = posOffsetX;
        }
		
        if (mainPlayer.transform.position.x > tileClone[0].transform.position.x + startTileDeletionFrom)
        {
            //Delete previous tiles
            Destroy(tileClone[0].gameObject);
            tileClone.RemoveAt(0);
        }
    }

    void GenerateSegments(GameObject spawnObject, GameObject previousObject, float objectSize)
    {
        if (posOffsetX <= globalLength)
        {
            float randomBetweenValues;
            if (!hasSpaces)
                randomBetweenValues = 0;
            else
                randomBetweenValues = Random.Range(gapMinDistance, gapMaxDistance);
            GameObject clone;
            clone = Instantiate(spawnObject, pos, Quaternion.identity) as GameObject;
            clone.transform.parent = gameObject.transform;
            tileClone.Add(clone);
            posOffsetX += objectSize + randomBetweenValues;
            posToGenerateFrom = previousObject.transform.position.x + objectSize + randomBetweenValues - staticGlobalLength;
            pos = new Vector3(posOffsetX, posOffsetY, posOffsetZ);
        }
    }

    public void ArraySort(float[] elements)
    {
        int i, c = elements.Length;
        if(c > 1)
        {
            for (i = 0; i < c; i++)
                spawnId[i] = i;
            System.Array.Sort(elements, spawnId);
        }
    }
}
