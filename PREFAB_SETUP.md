# Prefab Setup Guide

## Creating Prefabs

Prefabs allow you to reuse game objects and maintain consistency across levels.

### SlipperObject Prefab

1. **Create the Prefab Object**
   - Right-click in Hierarchy → 3D Object → Cube
   - Name it "SlipperObject"
   - Position: (0, 0, 0)
   - Scale: (1, 1, 1)

2. **Configure Components**
   - Add Rigidbody:
     - Mass: 1
     - Drag: 0.3
     - Angular Drag: 0.3
     - Gravity: ON
     - Constraints: Freeze Rotation
   - Add Script: SlipperObject.cs
   - Material: Orange color

3. **Create Prefab**
   - Drag from Hierarchy to Assets/Prefabs
   - Name it "SlipperObject.prefab"
   - Delete from scene

### Obstacle Prefab

1. **Create the Prefab Object**
   - Right-click in Hierarchy → 3D Object → Cube
   - Name it "Obstacle"
   - Position: (0, 0, 0)
   - Scale: (3, 1, 3)

2. **Configure Components**
   - Add Rigidbody:
     - Body Type: Static
   - Material: Red/Dark color
   - Tag: "Obstacle"

3. **Create Prefab**
   - Drag from Hierarchy to Assets/Prefabs
   - Name it "Obstacle.prefab"
   - Delete from scene

### Goal Prefab

1. **Create the Prefab Object**
   - Right-click in Hierarchy → 3D Object → Cube
   - Name it "Goal"
   - Position: (0, 0, 0)
   - Scale: (8, 1, 8)

2. **Configure Components**
   - Add BoxCollider:
     - Is Trigger: ON
   - Material: Green (semi-transparent)
   - Tag: "Goal"

3. **Create Prefab**
   - Drag from Hierarchy to Assets/Prefabs
   - Name it "Goal.prefab"
   - Delete from scene

## Using Prefabs in Levels

### Instantiate at Runtime
```csharp
// In your scene builder or level setup
GameObject slipperObj = Instantiate(slipperObjectPrefab, position, Quaternion.identity);
```

### Drag into Scene
1. Open Level scene
2. Drag prefab from Assets/Prefabs into Hierarchy
3. Adjust position as needed
4. Repeat for each instance

## Material Assignments

### Create Materials

1. **SlipperMaterial** (Orange)
   - Color: RGB(255, 128, 0)
   - Shader: Standard

2. **ObstacleMaterial** (Dark Red)
   - Color: RGB(139, 0, 0)
   - Shader: Standard

3. **GoalMaterial** (Green)
   - Color: RGB(0, 255, 0, 0.5)
   - Shader: Standard (with transparency)

4. **BoardMaterial** (Gray)
   - Color: RGB(128, 128, 128)
   - Shader: Standard

## Physics Materials

### SlipperMaterial.physicMaterial
- Static Friction: 0.1
- Dynamic Friction: 0.1
- Bounciness: 0.2
- Friction Combine: Minimum

### BoardMaterial.physicMaterial
- Static Friction: 0.3
- Dynamic Friction: 0.3
- Bounciness: 0.1
- Friction Combine: Average

## Best Practices

1. **Use Prefabs for Consistency**
   - All slippery objects should be identical
   - Obstacles should be consistent
   - Makes tuning easier

2. **Organize by Type**
   - Separate folders for different object types
   - Use clear naming conventions
   - Add prefab variants for different sizes

3. **Maintain Prefabs**
   - Edit prefab in isolation
   - Apply changes to all instances
   - Create variants for special cases

4. **Document Properties**
   - Add comments to prefab scripts
   - Note friction values
   - Document intended use
