using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLogicBlock : MonoBehaviour
{
    //  [HideInInspector]
    public List<GemBox> gemBoxes = new List<GemBox>();
    public List<LogicObject> objectsConnected = new List<LogicObject>();
    public int slots;

    public void Start()
    {
        for (int i = 0; i < slots; i++)
        {
            gemBoxes.Add(new GemBox(null, null, 0));
        }
    }
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
                int num = 0;
                if (gemBoxes[i].numberGem != null)
                {
                    num = gemBoxes[i].numberGem.GetValue();
                }
                if (gemBoxes[i].functionGem == null)
                {
                    continue;
                }
                switch (gemBoxes[i].functionGem.executionType)
                {
                    case GemExecutionType.Activate:
                        {
                            lo.Activate(this);
                            break;
                        }
                    case GemExecutionType.Move:
                        {
                            lo.Move(this, num * CodeHelper.CodeHelper.GetDir(gemBoxes[i].data));
                            break;
                        }
                    case GemExecutionType.Rotate:
                        {
                            lo.Rotate(this, num * CodeHelper.CodeHelper.GetDir(gemBoxes[i].data));

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
        if (!UIManager.instance.gpuiManager.open)
        {
            UIManager.instance.OpenProgrammingUI(this);
        }

    }

}
