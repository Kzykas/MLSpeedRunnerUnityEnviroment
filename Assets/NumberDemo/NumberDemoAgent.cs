using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberDemoAgent : Agent {
    [SerializeField]
    private float targetNumber;
    [SerializeField]
    private float currentNumber;
    [SerializeField]
    private Text text;

    int solved;

    public override List<float> CollectState()
    {
        List<float> state = new List<float>();
        state.Add(currentNumber);
        state.Add(targetNumber);
        return state;
    }

    public override void AgentStep(float[] action)
    {
        if (text != null)
        {
            text.text = string.Format("c: {0} t:{1}  [{2}]", currentNumber, targetNumber, solved);
        }


        switch((int)action[0])
        {
            case 0:
                currentNumber -= 0.01f;
                break;
            case 1:
                currentNumber += 0.01f;
                break;
            default:
                return;
        }

        if(currentNumber < -1.2f || currentNumber > 1.2f)
        {
            reward = -1f;
            done = true;
            return;
        }

        float differemce = Mathf.Abs(targetNumber - currentNumber);

        if(differemce < 0.01f)
        {
            solved++;
            reward = 1f;
            done = true;
            return;
        }
    }

    public override void AgentReset()
    {
        targetNumber = Random.RandomRange(-1f,1f);
        currentNumber = 0f;
    }
}
