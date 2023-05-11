using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    public int velocidade; //defina a velocidade do movimenta��o
    private Rigidbody2D rbPlayer; // criar variavel para receber os componentes de fisica
    public float forcaPulo; //define a for�a do pulo


    public bool sensor; //sensor para verificar se est� colidindo com o ch�o
    public Transform posicaoSensor; // Posi��o onde o ser� posicionado
    public LayerMask layerChao; // camada de intera��o
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");


        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }
    }


    private void FixedUpdate()
    {
        //Cria um sensor em posi��o definida com raio e layer tb definidas
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);
    }
}
