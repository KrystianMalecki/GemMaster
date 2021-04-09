using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLogicBlock : MonoBehaviour
{
    public List<GemBox> gemBoxes = new List<GemBox>();
    public List<LogicObject> objectsConnected = new List<LogicObject>();


    public void Execute()
    {
        StartCoroutine(ExecutionLoop());
    }

    int bufferstater;
    IEnumerator ExecutionLoop()
    {
        for (int i = 0; i < gemBoxes.Count; i++)
        {
            bufferstater = 0;
            foreach (LogicObject lo in objectsConnected)
            {
                switch (gemBoxes[i].functionGem.executionType)
                {
                    case GemExecutionType.Activate:
                        {
                            lo.Activate(this);
                            break;
                        }
                    case GemExecutionType.Move:
                        {
                            lo.Move(this, gemBoxes[i].numberGem.GetValue() * CodeHelper.CodeHelper.GetDir(gemBoxes[i].data));
                            break;
                        }
                    case GemExecutionType.Rotate:
                        {
                            lo.Rotate(this, gemBoxes[i].numberGem.GetValue() * CodeHelper.CodeHelper.GetDir(gemBoxes[i].data));

                            break;
                        }
                    case GemExecutionType.Toggle:
                        {
                            lo.Toggle(this, gemBoxes[i].data == 1);
                            break;
                        }
                        //TODO: add function gem
                }
            }

            yield return new WaitUntil(() => bufferstater == objectsConnected.Count);

        }

    }
    //Half move to the next step
    public void HalfMTTNS()
    {
        bufferstater++;
    }
    public void Edit()
    {
        UIManager.instance.OpenProgrammingUI(this);
    }
   
}
