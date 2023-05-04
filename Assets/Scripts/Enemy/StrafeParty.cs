using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeParty : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float StrafingRange;
    [SerializeField] private List<GameObject> agents;
    [SerializeField] private List<GameObject> strafingAgents;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    [SerializeField] List<GameObject> selectedAgentsList = new List<GameObject>(3);

    private void Awake()
    {
        agents = new List<GameObject>(GameObject.FindGameObjectsWithTag("Agent"));
      
    }

    private void FixedUpdate()
    {
        strafe();

        StartCoroutine(ChargedEnemy());

        DeselectAgents();
    }


    private IEnumerator ChargedEnemy()
    {


        while (true)
        {
            if (strafingAgents != null && selectedAgentsList.Count < 3)
            {
                SelectAgents();
            }
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }





    //get agents in strafe range
    private void strafe()
    {
        strafingAgents.Clear(); // clear the list before adding new agents



        for (int i = 0; i < agents.Count; i++)
        {
            float dist = Vector2.Distance(target.position, agents[i].transform.position);

            if (dist <= StrafingRange)
            {
                strafingAgents.Add(agents[i]);
            }
            else // use else instead of else if(strafingAgents!=null)
            {
                strafingAgents.Remove(agents[i]); // use strafingAgents.Remove(agents[i]) instead of strafingAgents.Remove(strafingAgents[i])
            }
        }


    }

    private void SelectAgents()
    {
        int sampleSize = Random.Range(1, 4);

        foreach (GameObject gameObject in strafingAgents)
        {
            gameObject.GetComponent<BehaviorsManager>().isCharged = false;

        }



        // Select random agents
        for (int i = 0; i < sampleSize && i < strafingAgents.Count; i++)
        {
            int index = Random.Range(0, strafingAgents.Count);
            GameObject agent = strafingAgents[index];

            //bool isAttacking = agent.GetComponent<BehaviorsManager>().isAttacking;
            //bool isRecovering = agent.GetComponent<BehaviorsManager>().isRecovering;
            //if(!isAttacking ||!isRecovering)
            //    agent.GetComponent<SpriteRenderer>().color = Color.cyan;

            selectedAgentsList.Add(agent);
        }

        // Remove duplicates
        for (int i = 0; i < selectedAgentsList.Count - 1; i++)
        {
            for (int j = i + 1; j < selectedAgentsList.Count; j++)
            {
                if (selectedAgentsList[i] == selectedAgentsList[j])
                {
                    selectedAgentsList.RemoveAt(j);
                    j--;
                }
            }
        }

        // Remove selected agents from strafingAgents list
        foreach (GameObject agent in selectedAgentsList)
        {
            strafingAgents.Remove(agent);
        }

        // Remove agents if selectedAgentsList count is greater than 4
        if (selectedAgentsList.Count > 4)
        {
            while (selectedAgentsList.Count > 4)
            {
                GameObject lastAgent = selectedAgentsList[selectedAgentsList.Count - 1];
                selectedAgentsList.Remove(lastAgent);
                strafingAgents.Add(lastAgent);

            }
        }


        foreach (GameObject agent in selectedAgentsList)
        {
            agent.GetComponent<BehaviorsManager>().isCharged = true;
        }
        //Debug.Log("Selected Agents: " + string.Join(", ", selectedAgentsList));
    }

    // Remove previously selected agents from selectedAgentsList
    private void DeselectAgents()
    {
        List<GameObject> agentsToRemove = new List<GameObject>();

        foreach (GameObject agent in selectedAgentsList)
        {
            if (!agent.GetComponent<BehaviorsManager>().isCharged)
                agentsToRemove.Add(agent);
        }

        foreach (GameObject agent in agentsToRemove)
        {
            selectedAgentsList.Remove(agent);
            strafingAgents.Add(agent);
        }
    }

}
