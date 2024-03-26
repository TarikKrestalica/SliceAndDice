using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinDisplay : MonoBehaviour
{
    [SerializeField] private List<Texture> textures;
    [SerializeField] private List<Texture> sadTextures;
    [SerializeField] private List<Texture> mediumTextures;
    [SerializeField] private List<Texture> happyTextures;
    [SerializeField] private List<Texture> decisionTimeTextures;

    private RawImage m_rawImage;

    [Range(0, 4f)]
    [SerializeField] float timeLapse;

    // Start is called before the first frame update
    void Awake()
    {
        m_rawImage = GetComponent<RawImage>();
        if (!m_rawImage)
        {
            Debug.LogError("Nothing!");
            return;
        }
    }

    IEnumerator Play()
    {
        WaitForSeconds wait = new WaitForSeconds(timeLapse);
        while (true)
        {
            for(int i = 0; i < textures.Count; i++)
            {
                m_rawImage.texture = textures[i];
                yield return wait;
            }
        }
    }

    public void SetTextures()
    {
        if (BehaviorManager.IsCompliment())
        {
            textures = happyTextures;
        }
        else if (BehaviorManager.IsComplaint())
        {
            textures = sadTextures;
        }
        else
        {
            textures = mediumTextures;
        }

        StartCoroutine(Play());
    }

    public void PlayDecisionTimeTextures()
    {
        StopAllCoroutines();
        textures = decisionTimeTextures;
        StartCoroutine(Play());
    }
}
