using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameSelect : MonoBehaviour
{
    // Start is called before the first frame update

    //numeber values corralating to the value of the ascii of the name
    public int N1=65, N2=65, N3=65;

    public TextMeshProUGUI Letter1;
    public TextMeshProUGUI Letter2;
    public TextMeshProUGUI Letter3;


    //initalize the letters to A
    void Start()
    {
        
        Letter1.text = ((char)65).ToString();
        Letter2.text = ((char)65).ToString();  
        Letter3.text = ((char)65).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Letter1.text = ((char)N1).ToString();
        Letter2.text = ((char)N2).ToString();  
        Letter3.text = ((char)N3).ToString();

        //update button 2

        //update button 3
    }


    public void increaseN1()
    {
        N1++;
        if (N1 > 90)
        {
            N1 = 65;
        }
    }

    public void decreaseN1()
    {
        N1--;
        if (N1 < 65)
        {
            N1 = 90;
        }
    }
    
    public void increaseN2()
    {
        N2++;
        if (N2 > 90)
        {
            N2 = 65;
        }
    }

    public void decreaseN2()
    {
        N2--;
        if (N2 < 65)
        {
            N2 = 90;
        }
    }

    public void increaseN3()
    {
        N3++;
        if (N3 > 90)
        {
            N3 = 65;
        }
    }

    public void decreaseN3()
    {
        N3--;
        if (N3 < 65)
        {
            N3 = 90;
        }
    }



}
