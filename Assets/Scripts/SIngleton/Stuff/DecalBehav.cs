using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DecalBehav : MonoBehaviour
{
    public DecalProjector projector;

    public float maxSize;
    public float speed;
    public float FadeSpeed;

    private bool startFade = false;
    public float fadeDelay;

    public float killTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        projector.size = Vector3.Lerp(projector.size, new Vector3(maxSize, maxSize, maxSize * 2), speed * Time.deltaTime);
        //projector.pivot = new Vector3(0,0,projector.size.z / 2);
        if (startFade == true)
        {
            projector.fadeFactor = Mathf.Lerp(projector.fadeFactor, 0, FadeSpeed * Time.deltaTime);
            killTimer -= Time.deltaTime;
            if (killTimer < 0)
            {
                Destroy(gameObject);
            }
        }

        fadeDelay -= 1 * Time.deltaTime;
        if (fadeDelay <= 0 && startFade == false)
        {
            startFade = true;

        }
    }
}
