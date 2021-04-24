using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;



// Taken from
public class MovementAudio : MonoBehaviour
{
    public enum MovementType
    {
        WALKING,
        RUNNING,
        JUMP_START,
        JUMP_LAND,
        SIZE,
        NULL
    }

    public enum TerrainType
    {
        STONE,
        MUD,
        GRASS,
        WOOD,
        SIZE,
        NULL
    }

    [Header("Walking Clips")]
    public AudioClip[] stoneWalkClips;
    public AudioClip[] mudWalkClips;
    public AudioClip[] grassWalkClips;
    public AudioClip[] woodWalkClips;

    [Header("Running Clips")]
    public AudioClip[] stoneRunClips;
    public AudioClip[] mudRunClips;
    public AudioClip[] grassRunClips;
    public AudioClip[] woodRunClips;

    [Header("Jump Start Clips")]
    public AudioClip[] stoneJumpStartClips;
    public AudioClip[] mudJumpStartClips;
    public AudioClip[] grassJumpStartClips;
    public AudioClip[] woodJumpStartClips;

    [Header("Jump Land Clips")]
    public AudioClip[] stoneJumpLandClips;
    public AudioClip[] mudJumpLandClips;
    public AudioClip[] grassJumpLandClips;
    public AudioClip[] woodJumpLandClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "Esotyre")
            terrainDetector = new TerrainDetector();

    }

    /// <summary>
    /// Plays Audio Based on given terrain type
    /// </summary>
    /// <param name="tag"> Tag of material to play audio for </param>
    /// <param name="type"> Movement type to play </param>
    public void Play(TerrainType terrainType, MovementType movementType)
    {
        if (!audioSource.isPlaying || movementType.Equals(MovementType.JUMP_START) || movementType.Equals(MovementType.JUMP_LAND))
            audioSource.PlayOneShot(GetAudioClip(terrainType, movementType));
    }

    /// <summary>
    /// Plays audio based on player location on terrain
    /// </summary>
    /// <param name="type"></param>
    public void Play(MovementAudio.MovementType type)
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 4:
                this.Play(TerrainType.MUD, type);
                return; 
            default:
                this.Play(TerrainType.GRASS, type);
                return;
        }
    }

    private AudioClip GetAudioClip(TerrainType terrainType, MovementType movementType)
    {

        switch (terrainType)
        {
            case TerrainType.WOOD:
                return GetClipFromMovementType(movementType, woodWalkClips, woodRunClips, woodJumpStartClips, woodJumpLandClips);
            case TerrainType.STONE:
                return GetClipFromMovementType(movementType, stoneWalkClips, stoneRunClips, stoneJumpStartClips, stoneJumpLandClips);
            case TerrainType.GRASS:
                return GetClipFromMovementType(movementType, grassWalkClips, grassRunClips, grassJumpStartClips, grassJumpLandClips);
            case TerrainType.MUD:
                return GetClipFromMovementType(movementType, mudWalkClips, mudRunClips, mudJumpStartClips, mudJumpLandClips);
            default:
                return null;
        }
    }

    private AudioClip GetClipFromMovementType(MovementType moveType, AudioClip[] walkClips, AudioClip[] runClips, AudioClip[] jumpStartClips, AudioClip[] jumpLandClips)
    {
        switch (moveType)
        {
            case MovementType.WALKING:
                return walkClips[UnityEngine.Random.Range(0, walkClips.Length)];
            case MovementType.RUNNING:
                return runClips[UnityEngine.Random.Range(0, runClips.Length)];
            case MovementType.JUMP_START:
                return jumpStartClips[UnityEngine.Random.Range(0, jumpStartClips.Length)];
            case MovementType.JUMP_LAND:
                return jumpLandClips[UnityEngine.Random.Range(0, jumpLandClips.Length)];
        }
        return null;
    }
}