using UnityEngine;

public class SliderAnimation : MonoBehaviour
{
    private Animator anim;
    bool isOut = true;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Trigger(string name)
    {
        if ((name.Equals("Out") && isOut != true) || (name.Equals("In") && isOut != false))
        {
            anim.SetTrigger(name);
            isOut = !isOut;
        }
    }

    public bool GetOut()
    {
        return isOut;
    }
}
