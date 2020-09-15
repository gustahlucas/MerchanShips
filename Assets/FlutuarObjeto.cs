using UnityEngine;
using System.Collections;
public class FlutuarObjeto : MonoBehaviour
{
    private float Seno = 0.0f;
    private int vez = 0;
    private float cronometro = 0.0f;
    private float MovimentoEmX;
    private float TorqueEmX;
    private float TorqueEmY;
    private float TorqueEmZ;
    public float VelocidadeVertical = 0;
    public float DistanciaVertical = 0;
    public float VelocidadeHorizontal = 0;
    public float VelocidadeDeRotacao = 0;
    void Start()
    {
        MovimentoEmX = VelocidadeHorizontal;
        TorqueEmX =VelocidadeDeRotacao;
        TorqueEmY =  VelocidadeDeRotacao;
        TorqueEmZ = VelocidadeDeRotacao;
        GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(TorqueEmX, TorqueEmY, TorqueEmZ));
    }
    void FixedUpdate()
    {
        if (Seno < Mathf.PI && vez == 0)
        {
            Seno += Time.deltaTime;
        }
        if (Seno >= Mathf.PI)
        {
            vez = 1;
        }
        if (Seno <= 0)
        {
            vez = 0;
        }
        if (Seno >= 0 && vez == 1)
        {
            Seno = 0;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(MovimentoEmX, Mathf.Sin(2 * Seno * VelocidadeVertical) * DistanciaVertical, 0);
        if (cronometro < 10)
        {
            cronometro += Time.deltaTime;
        }
        if (cronometro >= 10)
        {
            cronometro = 0;
            GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(TorqueEmX, TorqueEmY, TorqueEmZ));
        }
    }
}