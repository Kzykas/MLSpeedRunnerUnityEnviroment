using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WorldGeneration))]
public class WorldGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WorldGeneration worldGeneration = (WorldGeneration)target;

        if (worldGeneration.segmentsSpawnChance.Length != worldGeneration.segments.Length)
        {
            System.Array.Resize(ref worldGeneration.segmentsSpawnChance, worldGeneration.segments.Length);
        }

        //Check if chance is valid
        for(int i = 0; i < worldGeneration.segmentsSpawnChance.Length; i++)
        {
            if (worldGeneration.segmentsSpawnChance[i] < 1)
            {
                worldGeneration.segmentsSpawnChance[i] = 1;
            }
        }

        //Check if tile deletion is valid
        if (worldGeneration.startTileDeletionFrom < 1)
            worldGeneration.startTileDeletionFrom = 1;

        //Check if spaces are checked
        if (worldGeneration.hasSpaces == true)
        {
            worldGeneration.gapMinDistance = EditorGUILayout.FloatField("Minimum distance", worldGeneration.gapMinDistance);
            worldGeneration.gapMaxDistance = EditorGUILayout.FloatField("Maximum distance", worldGeneration.gapMaxDistance);
        }
    }
}