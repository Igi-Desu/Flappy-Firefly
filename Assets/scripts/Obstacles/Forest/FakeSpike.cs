using UnityEngine;

public class FakeSpike : WoodSpike
{
    void Update()
    {
        base.Update();
        if (transform.position.x < 3)
        {
            //pull apart two blocks after we get to certain position
            transform.GetChild(0).transform.localPosition = Vector3.MoveTowards(transform.GetChild(0).transform.localPosition,
                new Vector3(0, -2, 0), speed * Time.deltaTime);
            
            transform.GetChild(1).transform.localPosition = Vector3.MoveTowards(transform.GetChild(1).transform.localPosition,
               new Vector3(0, 2, 0), speed * Time.deltaTime);
        }
    }
}
