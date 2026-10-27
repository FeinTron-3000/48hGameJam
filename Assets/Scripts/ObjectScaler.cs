using System.Collections;

using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private Animator knifeAnim;
    [SerializeField] private Animator meatAnim;
    // Scaling setting
    public float shrinkSpeed;
    public float growSpeed;
    public float minScale;
    public float maxScale;
    public float waitTime;

    public GameObject triggerObject;

    public bool isGrowing = false;
    private Vector3 initialScale;

    public Rigidbody2D rb;
    public GameObject knife;
    public Vector3 startPos;
    public Vector3 endPos;
    public float chopSpeed;

    private Vector3 targetPos;

    public bool knifeanimation = false;
    private bool playonce;

    private void Awake()
    {
        targetPos = startPos;
    }

    private void KnifeDown()
    {
        if (playonce)
        {
            knife.transform.position = startPos;
            playonce = false;
        }
        
        if (knife.transform.position.y > endPos.y)
        {
            knife.transform.position += new Vector3(0, chopSpeed * Time.deltaTime, 0);
        }
        else
        {
            knifeanimation = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrowing)
        {
            if (transform.localScale.x > minScale)
            {
                transform.localScale -= Vector3.one * shrinkSpeed *Time.deltaTime;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == triggerObject)
            {
                knifeAnim.SetBool("isChopping", true);
                meatAnim.SetBool("meatChopped", true);

                knifeanimation = true;
                playonce = true;
                StartCoroutine(Grow());
            }
        }
        else
        {
            knifeAnim.SetBool("isChopping", false);
            meatAnim.SetBool("meatChopped", false);
        }

        if (knifeanimation)
        {
            KnifeDown();
        }
    } 

    IEnumerator Grow()
    {
        if (transform.localScale.x < maxScale)
        {
            isGrowing = true;
            transform.localScale += Vector3.one * growSpeed;
            yield return new WaitForSeconds(waitTime);
            isGrowing = false;
        }
    }
}
