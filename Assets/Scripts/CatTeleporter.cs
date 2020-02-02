using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatTeleporter : MonoBehaviour
{
    [SerializeField] private float startingTime;
    public CatController cat;
    private List<BrekeableInstantiatorPlaceholder> catTeleportPositions=new List<BrekeableInstantiatorPlaceholder>();
    private int currentTeleport = 0;

    public Transform smokeIntro;
    public Transform smokeOutro;

    private List<ParticleSystem> particlesIntro;
    private List<ParticleSystem> particlesOutro;

    private void Awake()
    {
        particlesIntro = smokeIntro.GetComponentsInChildren<ParticleSystem>().ToList();
        particlesOutro = smokeOutro.GetComponentsInChildren<ParticleSystem>().ToList();

    }

    private void Start() {

        cat.OnActionFinished += NextTeleport;
    }

    public void StartTeleportation()
    {
        StartCoroutine(StartTeleporting());
    }

    private IEnumerator StartTeleporting()
    {
        yield return new WaitForSeconds(startingTime);
        NextTeleport();
    }

    public void AddPoint(BrekeableInstantiatorPlaceholder instance)
    {
        catTeleportPositions.Add(instance);
    }

    void NextTeleport()
    {
        if (currentTeleport > catTeleportPositions.Count() - 1)
        {
            ActivateSmokeIntro(catTeleportPositions[currentTeleport - 1].transform.position);
            cat.gameObject.SetActive(false);
            return;
        }

        if(currentTeleport - 1 >= 0)
            ActivateSmokeIntro(catTeleportPositions[currentTeleport - 1].transform.position);
        ActivateSmokeOutro(catTeleportPositions[currentTeleport].transform.position);

        cat.TeleportTo(
            catTeleportPositions[currentTeleport].transform.position,
            catTeleportPositions[currentTeleport].transform.forward);
        currentTeleport++;
    }

    private void ActivateSmokeIntro(Vector3 position)
    {
        position += Vector3.up * 0.3f;
        smokeIntro.transform.position = position;
        smokeIntro.gameObject.SetActive(true);
        particlesIntro.ForEach(particle => {
            RestartParticle(particle);
        });
    }

    private void ActivateSmokeOutro(Vector3 position)
    {
        position += Vector3.up * 0.3f;
        smokeOutro.transform.position = position;
        smokeOutro.gameObject.SetActive(true);
        particlesOutro.ForEach(particle => {
            RestartParticle(particle);
        });
    }

    private void RestartParticle(ParticleSystem particle)
    {
        particle.Play();
    }
}
