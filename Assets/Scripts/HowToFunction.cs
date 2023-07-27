using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int MyAnswer = AddTwoNumbers(4, 5); //parsing the number 4 into our func

        Debug.Log(MyAnswer);
    }
    // this func returns an int as an answer rather than void which sends to null
    int AddTwoNumbers(int x, int y) //this function acxcepts an integer with the value x and y
    {
        int answer = x + y; //create a new func named answer
        return answer;
    }
}
