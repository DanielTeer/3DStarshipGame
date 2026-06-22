using System.Collections;//Needed for IEnumerator and coroutines
using System.Collections.Generic;//Needed for List
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveLevelLoader : MonoBehaviour
{
    public Transform player;//Player ship

    public string[] chunkSceneNames;//Chunk scene names to loop through in inspector 123123123 forever

    public float chunkLength = 100f;//Length of each chunk

    public int chunksAhead = 2;//How many chunks to keep loaded ahead of player

    public int chunksBehind = 1;//How many chunks to keep loaded behind player

    private int highestChunkLoaded = -1;//Highest chunk number loaded so far

    private bool isLoading = false;//Stops multiple chunks loading at the same time

    private List<Scene> loadedScenes = new List<Scene>();//Scenes currently loaded by this script,

    private List<int> loadedChunkNumbers = new List<int>();//Chunk numbers matching loaded scenes

    private void Start()
    {
        StartCoroutine(LoadStartingChunks());//Load first chunks
    }

    private void Update()
    {
        if (player == null)//No player assigned
        {
            return;
        }

        int playerChunkNumber = Mathf.FloorToInt(player.position.z / chunkLength);//What chunk the player is in

        if (!isLoading && highestChunkLoaded < playerChunkNumber + chunksAhead)//Need more chunks ahead
        {
            StartCoroutine(LoadNextChunk());//Load another chunk
        }

        UnloadOldChunks(playerChunkNumber);//Unload chunks too far behind
    }

    private IEnumerator LoadStartingChunks()
    {
        int chunksToLoadAtStart = chunksAhead + 1;//Current chunk plus chunks ahead

        for (int i = 0; i < chunksToLoadAtStart; i++)//Load starting chunks
        {
            yield return StartCoroutine(LoadNextChunk());//Wait for each chunk to finish loading
        }
    }

    private IEnumerator LoadNextChunk()
    {
        if (chunkSceneNames.Length <= 0)//No chunk scenes assigned
        {
            yield break;
        }

        isLoading = true;//Mark that loading is happening

        highestChunkLoaded++;//Move to the next chunk number

        int sceneIndex = highestChunkLoaded % chunkSceneNames.Length;//Loops forever by using the % to give us the remainder of last load to the list of scenes

        string sceneName = chunkSceneNames[sceneIndex];//Get scene name

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);//Load scene additively

        while (!loadOperation.isDone)//Keep waiting until the scene is done loading.
        {
            yield return null;//Wait one frame
        }

        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);//Get newest loaded scene

        MoveLoadedChunk(loadedScene, highestChunkLoaded);//Move chunk to correct Z position

        loadedScenes.Add(loadedScene);//Remember loaded scene

        loadedChunkNumbers.Add(highestChunkLoaded);//Remember chunk number

        isLoading = false;//Loading is finished
    }

    private void MoveLoadedChunk(Scene loadedScene, int chunkNumber)
    {
        GameObject[] rootObjects = loadedScene.GetRootGameObjects();//Get root objects in loaded scene

        foreach (GameObject rootObject in rootObjects)//Loop through root objects
        {
            if (rootObject.name == "LevelChunkRoot")//Find the chunk root
            {
                rootObject.transform.position = new Vector3(0f, 0f, chunkNumber * chunkLength);//Move chunk into place
                return;//Stop after moving root
            }
        }

        foreach (GameObject rootObject in rootObjects)//Fallback if root was not named correctly
        {
            rootObject.transform.position += new Vector3(0f, 0f, chunkNumber * chunkLength);//Move all roots
        }
    }

    private void UnloadOldChunks(int playerChunkNumber)
    {
        for (int i = loadedScenes.Count - 1; i >= 0; i--)//Loop backwards so removing is safe
        {
            if (loadedChunkNumbers[i] < playerChunkNumber - chunksBehind)//Chunk is too far behind
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i]);//Unload old chunk scene

                loadedScenes.RemoveAt(i);//Remove scene from list

                loadedChunkNumbers.RemoveAt(i);//Remove chunk number from list
            }
        }
    }
    public void ResetChunks()
    {
        StopAllCoroutines();//Stop any chunk loading currently happening

        isLoading = false;//Allow loading again

        for (int i = loadedScenes.Count - 1; i >= 0; i--)//Loop through loaded chunks
        {
            if (loadedScenes[i].isLoaded)//If scene is loaded
            {
                SceneManager.UnloadSceneAsync(loadedScenes[i]);//Unload chunk scene
            }
        }

        loadedScenes.Clear();//Clear loaded scene list

        loadedChunkNumbers.Clear();//Clear chunk number list

        highestChunkLoaded = -1;//Reset chunk count

        StartCoroutine(LoadStartingChunks());//Load starting chunks again
    }
}
