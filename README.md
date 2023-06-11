# ISLAND
## IMPORTANT

Since the project file was too large to upload to GitHub, please visit the Google drive link:https://drive.google.com/drive/folders/1jOGc4t22C0EEfBVvQTgmi63AQ2Ziq-kU


## introduction
Island is a game developed on Unity. In the game, the player will start having an empty island which will be shown on the screen. By collecting **physical cards** of different plants and scanning them by camera, the player can generate an augmented **reality (AR) model**. Then, the player can select the corresponding area to grow plants and click on the plants to unlock five different animals.Through the interaction with plants, players will gradually unlock and discover various animals, increasing the fun and exploration of the game.

After different plants are planted, different animals will be created with them. We hope that this game can make people pay attention to environmental protection and the protection of ecological diversity.

Island combines elements of placement games, biodiversity and augmented reality to provide players with a unique experience. Players will collect and **exchange cards with other players** in real world to eventually unlock all animals.

## The technologies we use
Unity

Blender

Adobe Illustrator

Ar SDK: Vuforia

## Game Flow
```mermaid
flowchart  TD;
    A[Start] --> B(Scanning other cards)
    A -->S(Exchange cards in real world)
    S -->B 
    S -->E 
    B --> D(Press the View button)
    A -->E(Scanning Cedrus cards)
    B -->G(Press the plant button)
    G --click-->C(Planting in the corresponding area)
    C -->H(Different animals appear)
    E -->J(Press the View button)
    J -->Q[Show animation]
    D -->R[Show animation]
    E -->K(Press the plant button)
    K --click-->N(Planting on Snowland)
    N -->L{Is Mushrrom planted}
    L --Yes-->M(Monkey appear)
    L --No-->O[Pop-up tips]
    M -->P[Complete achievement]
    H -->P
```

## What I did in this Project
### 1.Scene and Material in Unity
### 2.Code
I have written all the code for the game's functions.And I've uploaded the code to github:https://github.com/Yyyoung6699/Island/tree/main/Complete%20code
And here is the code for some of the main functions that I have selected (in case there are too many files):https://github.com/Yyyoung6699/Island/tree/main/Main%20code

1.TreeSpwan/GrassSpwan
From the main camera ray to the mouse position, the material of the intersection is detected
```ruby
void RayCast()
{
    RaycastHit hit;
    if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
    {
        // Check if the raycast hit an object with the "Ground" tag
        if (hit.collider.CompareTag("Ground"))
        {
            Vector3 hitPos = hit.point;
            MeshCollider meshCollider = hit.collider as MeshCollider;

            // Check if the collider has a mesh and retrieve it
            if (meshCollider != null || meshCollider.sharedMesh != null)
            {
                mesh = meshCollider.sharedMesh;
                Renderer renderer = hit.collider.GetComponent<MeshRenderer>();

                // Get the indices of the triangle that was hit
                int[] hitTriangle = new int[]
                {
                    mesh.triangles[hit.triangleIndex * 3],
                    mesh.triangles[hit.triangleIndex * 3 + 1],
                    mesh.triangles[hit.triangleIndex * 3 + 2]
                };

                // Iterate over all submeshes in the mesh
                for (int i = 0; i < mesh.subMeshCount; i++)
                {
                    int[] subMeshTris = mesh.GetTriangles(i);

                    // Iterate over each triangle in the submesh
                    for (int j = 0; j < subMeshTris.Length; j += 3)
                    {
                        // Check if the current triangle matches the hit triangle
                        if (subMeshTris[j] == hitTriangle[0] &&
                            subMeshTris[j + 1] == hitTriangle[1] &&
                            subMeshTris[j + 2] == hitTriangle[2])
                        {
                            mat = renderer.materials[i];

                            // Log the index of the submesh
                            Debug.Log(i);

                            // Call a function with the submesh index and hit position
                            LandCondition(i, hitPos);
                        }
                    }
                }
            }
        }
    }
}
```
Depending on the material, different plants are generated
```ruby
void SpawnPlants(GameObject spawnPla, Vector3 hitPos)
    {
        audioSource.PlayOneShot(Sound);
        //int PlantsIndex = Random.Range(0, spawnPla.Length);
        hitPos = hitPos + Vector3.up * spawnPla.transform.localScale.y / 2;
        Instantiate(spawnPla, hitPos, Quaternion.identity);
    }
```
2.Interaction
By ray detection whether the GreenTree object hit, if hit, play animation, and based on the number of plants, generate animals
```ruby
 if (hit.collider.CompareTag("GreenTree"))
            {
                Score = Score + 1;
                currentObject = hit.transform;
                Debug.Log(currentObject.name);
                Debug.Log(currentObject.position);
                growleave = currentObject.GetComponent<Grow>();
                growleave.PlayParticleEffect();
                // 检查全局是否存在标记为"Animal"的对象
                GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
                if (animals.Length > 0)
                {
                    Debug.Log("存在标记为'Animal'的对象");
                }
                else
                {
                    InsBird();
                }
            }
```
### 3.Animation in Unity

