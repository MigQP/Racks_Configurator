using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviarMail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendMail()
    {
        Application.OpenURL("mailto:julio@tecartdesign.com.mx?subject=Necesito más información...&body=Hola, he revisado el mueble y me interesa obtener más información%0D%0AContacto: XX-XXXX-XXXX");
    }
}
