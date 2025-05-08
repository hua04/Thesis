using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TypingAppManager : MonoBehaviour
{
    public List<GameObject> typingApps;
    public List<float> xPositions;
    public List<float> yPositions;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject app in typingApps)
        {
            app.SetActive(false);
        }

    }

    [YarnCommand("addwork")]
    public void AddWork(int amount)
    {

        foreach (GameObject work in typingApps)
        {

            if (work.activeInHierarchy == false)
            {
                work.SetActive(true);
                amount--;
            }

            if (amount == 0)
            {
                break;

            }

        }
    }

    public void RemoveFile(GameObject file)
    {
        typingApps.Remove(file);
        var temp = 0;
        foreach (GameObject app in typingApps)
        {
            app.transform.localPosition = new Vector3(xPositions[temp], yPositions[temp], 0);
            temp++;
        }

    }
}
