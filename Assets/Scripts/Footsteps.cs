using UnityEngine;
using UnityEngine.SceneManagement;

// Taken from
public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] grassClips;
    [SerializeField]
    private AudioClip[] woodClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "Esotyre")
            terrainDetector = new TerrainDetector();
    }

    public void StepTerrain()
    {
        AudioClip clip = GetRandomClip();
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(clip);
    }

    public void StepObject(string tag)
    {
        AudioClip clip = GetObjClip(tag);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            
            case 4:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            default:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
        }

    }

    private AudioClip GetObjClip(string tag)
    {
        switch (tag)
        {
            case "Wood":
                return woodClips[UnityEngine.Random.Range(0, woodClips.Length)];
            case "Stone":
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            default:
                return null;
        }
    }
}