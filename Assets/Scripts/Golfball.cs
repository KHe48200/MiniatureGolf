using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golfball : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 startPosition;
    Vector3 mousePosition;
    Vector3 endPosition;
    int framesStopped;
    bool hasStopped;
    bool startNewTurn;
    public int score;

    public Collider RaycastPlane;
    public float forceMultiplier;
    private AudioSource puttSound;

    // Start is called before the first frame update
    void Start()
    {
        score = 7;
        startNewTurn = false;
        Time.timeScale = 1f;
        puttSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        rigidbody = gameObject.GetComponent<Rigidbody>();
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        MeshCollider raycastPlaneMeshCollider = RaycastPlane.GetComponent<MeshCollider>();

        //Asetetaan pallo pysähtyneeksi kun ollut 10 framea "pysähtyneenä".
        //Jos asetettaisiin heti pysähtyneeksi kun "rigidbody.velocity.magnitude < 1" niin voisi pallo pysähtyä esim. jostakin kimmokkeesta mitä ei haluta
        if (rigidbody.velocity.magnitude < 1 && framesStopped < 30)
        {
            framesStopped++;
            if (framesStopped >= 10)
                hasStopped = true;
        }

        //if (rigidbody.velocity.magnitude < 1)
        if (hasStopped)
        {
            //Pysäytetään pallo
            rigidbody.velocity = new Vector3(0, 0, 0);
            rigidbody.angularVelocity = new Vector3(0, 0, 0);

            if (startNewTurn)
            {
                score--;
                //Uusi kierros aloitettu eli startNewTurn false jotta sitä ei kutsuta uudestaan
                startNewTurn = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                lineRenderer.enabled = true;
                lineRenderer.positionCount = 2;
                startPosition = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
                lineRenderer.material.color = Color.white;
                lineRenderer.SetPosition(0, startPosition);
                lineRenderer.useWorldSpace = true;
            }
            if (Input.GetMouseButton(0))
            {
                RaycastHit hitInfo;
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit && hitInfo.collider == RaycastPlane)
                {
                    endPosition = new Vector3(startPosition.x + ((mousePosition.x - startPosition.x) * 1000), transform.position.y + 0.01f, startPosition.z + ((mousePosition.z - startPosition.z) * 1000));
                    mousePosition = new Vector3(hitInfo.point.x, transform.position.y + 0.01f, hitInfo.point.z);
                }
                lineRenderer.SetPosition(1, endPosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                lineRenderer.enabled = false;
                Vector3 forceHorizontal = new Vector3(mousePosition.x - startPosition.x, 0, mousePosition.z - startPosition.z);
                rigidbody.AddForce(forceHorizontal * forceMultiplier);
                puttSound.Play();
                //odottaa että "rigidbody.velocity.magnitude < 1" ehto täytyy ja aloittaa sitten uuden kierroksen
                startNewTurn = true;
                //Asetetaan pallo "ei pysähtynyt" tilaan ja nollataanmonta framea ollut pyähtyneenä laskuri 
                hasStopped = false;
                framesStopped = 0;
            }
        }

        //Koska pallo pystyy hyppäämään RaycastPlanen "päälle" otetaan se pois käytöstä kun pallo onnistuu pääsemään RaycastPlanen yläpuolelle.
        //Näin pallo putoaa takaisin kentän päälle RaycastPlanen sijaan.
        if (gameObject.transform.position.y >= RaycastPlane.transform.position.y)
            raycastPlaneMeshCollider.enabled = false;
        else
            raycastPlaneMeshCollider.enabled = true;

        //Jos pallo putoaa radalta -> 0 pistettä -> endLevel()
        if (gameObject.transform.position.y < -10)
            score = 0;     
    }
}

