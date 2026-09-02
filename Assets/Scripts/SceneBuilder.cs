using UnityEngine;

/// <summary>
/// Scene builder that creates game objects at runtime
/// Run this once to setup the level, then save the scene
/// </summary>
public class SceneBuilder : MonoBehaviour
{
    [SerializeField] private bool buildOnStart = false;

    private void Start()
    {
        if (buildOnStart)
        {
            BuildLevel();
        }
    }

    public void BuildLevel()
    {
        Debug.Log("Building Level 1...");

        // Create board/floor
        GameObject board = CreateCube("Board", new Vector3(0, -0.5f, 20), new Vector3(40, 1, 50));
        board.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.4f);
        board.GetComponent<Collider>().material = CreatePhysicMaterial("BoardMaterial", 0.3f, 0.3f);

        // Create walls/boundaries
        CreateCube("WallLeft", new Vector3(-21, 2, 20), new Vector3(2, 4, 50));
        CreateCube("WallRight", new Vector3(21, 2, 20), new Vector3(2, 4, 50));
        CreateCube("WallFront", new Vector3(0, 2, -5), new Vector3(40, 4, 2));
        CreateCube("WallBack", new Vector3(0, 2, 45), new Vector3(40, 4, 2));

        // Create obstacles
        CreateCube("Obstacle1", new Vector3(-10, 0.5f, 15), new Vector3(3, 1, 3));
        CreateCube("Obstacle2", new Vector3(0, 0.5f, 25), new Vector3(3, 1, 3));
        CreateCube("Obstacle3", new Vector3(10, 0.5f, 30), new Vector3(3, 1, 3));

        // Create slippery objects (3 objects to move)
        for (int i = 0; i < 3; i++)
        {
            GameObject slipperObj = CreateSlipperObject(
                $"SlipperObject{i + 1}",
                new Vector3(-8 + (i * 4), 1, 5),
                new Vector3(1, 1, 1)
            );
        }

        // Create goal area
        GameObject goal = CreateCube("Goal", new Vector3(0, 0.5f, 40), new Vector3(8, 1, 8));
        goal.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.5f);
        goal.GetComponent<BoxCollider>().isTrigger = true;
        goal.tag = "Goal";

        // Create player/camera
        GameObject player = new GameObject("Player");
        player.transform.position = new Vector3(0, 1, -5);
        Camera camera = player.AddComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0.2f, 0.2f, 0.3f);
        player.AddComponent<AudioListener>();
        player.AddComponent<PlayerController>();

        Debug.Log("Level 1 built successfully!");
    }

    private GameObject CreateCube(string name, Vector3 position, Vector3 scale)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        cube.transform.localScale = scale;
        
        // Remove collider if primitive already has one
        Collider col = cube.GetComponent<Collider>();
        if (col != null && !(col is BoxCollider))
            DestroyImmediate(col);

        return cube;
    }

    private GameObject CreateSlipperObject(string name, Vector3 position, Vector3 scale)
    {
        GameObject obj = CreateCube(name, position, scale);
        
        // Add Rigidbody
        Rigidbody rb = obj.AddComponent<Rigidbody>();
        rb.mass = 1f;
        rb.drag = 0.3f;
        rb.angularDrag = 0.3f;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = true;

        // Add SlipperObject script
        SlipperObject slipperScript = obj.AddComponent<SlipperObject>();
        
        // Color
        obj.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f);

        return obj;
    }

    private PhysicMaterial CreatePhysicMaterial(string name, float staticFriction, float dynamicFriction)
    {
        PhysicMaterial material = new PhysicMaterial
        {
            name = name,
            staticFriction = staticFriction,
            dynamicFriction = dynamicFriction,
            frictionCombine = PhysicMaterialCombine.Minimum,
            bounciness = 0.1f
        };
        return material;
    }
}
