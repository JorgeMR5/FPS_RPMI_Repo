using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    #region General Variables
    [Header("General References")]
    [SerializeField] Camera fpsCam; //Ref si disparamos desde el centro de la cam
    [SerializeField] Transform shootPoint; //Ref si queremos disparar desde la punta del cañón
    [SerializeField] LayerMask impactLayer; //Layer con la que el Raycast interactúa
    RaycastHit hit; //Almacén de la información de los objetos a los que el Raycast puede impactar

    [Header("Weapon Parameters")]
    [SerializeField] int damage = 10; //Daño del arma por bala
    [SerializeField] float range = 100f; //Distancia de disparo
    [SerializeField] float spread = 0; //Radio de dispersión del arma
    [SerializeField] float shootingCooldown = 0.2f; //Tiempo entre disparos
    [SerializeField] float reloadTime = 1.5f; //Tiempo de recarga en segundos
    [SerializeField] bool allowButtonHold = false; //Si el disparo se ejecuta por click (false) o por mantener (true)

    [Header("Bullet Management")]
    [SerializeField] int ammoSize = 30; //Cantidad max de balas/cargador
    [SerializeField] int bulletsPerTap = 1; //Cantidad de balas disparadas por cada ejecución de disparo
    int bulletsLeft; //Cantidad de balas dentro del cargador actual

    [Header("Feedback References")]
    [SerializeField] GameObject impactEffect; //Ref al VFX de impacto de bala

    [Header("Dev - Gun State Bools")]
    [SerializeField] bool shooting; //Indica si estamos disparando
    [SerializeField] bool canShoot; //Indica si podemos disparar en X momento del juego
    [SerializeField] bool reloading; //Indica si estamos en proceso de recarga
    #endregion

    private void Awake()
    {
        bulletsLeft = ammoSize; //Al iniciar la partida, tenemos el cargador lleno
        canShoot = true; //Al iniciar la partida, tenemos la posibilidad de disparar
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        //ESTE ES EL MÉTODO MÁS IMPORTANTE
        //AQUÍ SE DEFINE EL DISPARO POR RAYCAST = UTILIZABLE CON CUALQUIER MECÁNICA

        //Almacenar la dirección de disparo y modificarla en caso de haber spread
        Vector3 direction = fpsCam.transform.forward; //Se lanza rayo hacia delante de la cámara
        //Añadir dispersión aleatoria según el valor de spread
        direction.x += Random.Range(-spread, spread);
        direction.y += Random.Range(-spread, spread);

        //DECLARACIÓN DEL RAYCAST
        //Physics.Raycast(Origen del rayo, dirección, almacén de la info del impacto, longitud del rayo, layer con la que impacta el rayo)
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range, impactLayer))
        {
            //AQUÍ PUEDO CODEAR TODOS LOS EFECTOS QUE QUIERO PARA MI INTERACCIÓN
            Debug.Log(hit.collider.name);

        }
    }

    #region Input Methods
    public void OnShoot(InputAction.CallbackContext context)
    {

    }

    public void OnReload(InputAction.CallbackContext context)
    {

    }
    #endregion

}
