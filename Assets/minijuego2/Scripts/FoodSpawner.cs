
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array de prefabs de comida que se pueden generar
    public float spawnInterval = 1.5f; // Tiempo entre cada aparición de comida
    public float xRange = 5f; // Rango horizontal en el que puede aparecer la comida
    public float offsetY = 3f; // Altura adicional para que la comida aparezca más arriba y caiga

    private float timer; // Temporizador interno para controlar el intervalo
    private float gameTime;

    void Update()
    {
        timer += Time.deltaTime;
        gameTime += Time.deltaTime;

        // Disminuye el intervalo al pasar ciertos tiempos
        if (gameTime >= 20f && gameTime < 40f)
        {
            spawnInterval = 1.0f; // Aumenta la velocidad después de 20s
        }
        else if (gameTime >= 40f)
        {
            spawnInterval = 0.7f; // Aumenta más la velocidad después de 40s
        }

        // Si pasó suficiente tiempo, generamos una nueva comida
        if (timer >= spawnInterval)
        {
            SpawnFood();
            timer = 0f;
        }
    }

    void SpawnFood()
    {
        // Elige un prefab aleatorio del array
        int index = Random.Range(0, foodPrefabs.Length);
        GameObject food = Instantiate(foodPrefabs[index]);

        // Calcula una posición X aleatoria dentro del rango permitido
        float randomX = Random.Range(-xRange, xRange);

        // Genera la posición de aparición, con una Y más alta para simular la caída
        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y + offsetY, transform.position.z);

        // Coloca el objeto instanciado en la posición calculada
        food.transform.position = spawnPosition;
    }
}