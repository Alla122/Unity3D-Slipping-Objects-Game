# Level Design Guide

## Level Design Principles

### Progressive Difficulty

**Level 1: Introduction**
- 3 slippery objects
- 2-3 simple obstacles
- Wide open space
- 300 second time limit
- Goal: Learn controls

**Level 2: Intermediate**
- 3-4 slippery objects
- 5-6 obstacles with varied shapes
- Narrower pathways
- 180 second time limit
- Goal: Refine technique

**Level 3: Advanced**
- 4-5 slippery objects
- 8+ obstacles and moving platforms
- Complex maze-like layout
- 120 second time limit
- Goal: Master mechanics

## Creating a Level Layout

### Step 1: Plan on Paper

Draw a top-down view:
```
[Start] → [Obstacle] → [Goal]
```

### Step 2: Create Board

```csharp
GameObject board = CreateCube(
    "Board",
    new Vector3(0, -0.5f, 20),      // Center position
    new Vector3(40, 1, 50)          // Size
);
```

### Step 3: Add Obstacles

**Straight Wall**
```csharp
CreateCube("Wall", new Vector3(0, 0.5f, 15), new Vector3(15, 1, 1));
```

**Curved Path**
```csharp
CreateCube("Curve1", new Vector3(-5, 0.5f, 20), new Vector3(1, 1, 5));
CreateCube("Curve2", new Vector3(0, 0.5f, 25), new Vector3(1, 1, 5));
CreateCube("Curve3", new Vector3(5, 0.5f, 30), new Vector3(1, 1, 5));
```

**Narrow Passage**
```csharp
CreateCube("WallLeft", new Vector3(-3, 0.5f, 20), new Vector3(1, 1, 10));
CreateCube("WallRight", new Vector3(3, 0.5f, 20), new Vector3(1, 1, 10));
```

**Scattered Obstacles**
```csharp
for (int i = 0; i < 5; i++)
{
    float randomX = Random.Range(-10f, 10f);
    float randomZ = Random.Range(10f, 40f);
    CreateCube($"Obstacle{i}", new Vector3(randomX, 0.5f, randomZ), new Vector3(2, 1, 2));
}
```

### Step 4: Place Goal

```csharp
CreateCube("Goal", new Vector3(0, 0.5f, 45), new Vector3(8, 1, 8));
```

### Step 5: Position Objects

```csharp
for (int i = 0; i < 3; i++)
{
    CreateSlipperObject(
        $"SlipperObject{i}",
        new Vector3(-8 + (i * 4), 1, 5),    // Starting positions
        new Vector3(1, 1, 1)
    );
}
```

## Layout Templates

### Linear Path
```
[Start] → [Obstacles] → [Goal]
```
Simplest design. Good for tutorials.

### Branching Path
```
     [Obstacle1]
        ↙   ↘
  [Start]   [Goal]
        ↘   ↙
     [Obstacle2]
```
Multiple routes. Encourages exploration.

### Spiral
```
        [Goal]
         ╱ ╲
    [Turn] [Obstacle]
      ╱ ╲
 [Obstacle] [Turn]
   ╱ ╲
[Start] [Obstacle]
```
Progressive difficulty. Engaging gameplay.

### Maze
```
┌─────────────┐
│ [Start] Obstacle │
│   ╱  ╲  ╱  ╲   │
│  Obs Obs Obs  │
│   ╲  ╱  ╲  ╱   │
│    [Goal]    │
└─────────────┘
```
Complex navigation. Maximum challenge.

## Advanced Layouts

### Moving Platforms
```csharp
// In ObstacleManager
Obstacle platform = new Obstacle
{
    obstacleObject = CreateCube(...),
    isMoving = true,
    speed = 2f,
    moveDistance = 5f,
    moveDirection = Vector3.right
};
```

### Ramps
```csharp
GameObject ramp = new GameObject("Ramp");
ramp.transform.position = new Vector3(0, 0, 20);
ramp.transform.rotation = Quaternion.Euler(30, 0, 0);  // 30-degree angle
```

### Tunnels
```csharp
// Narrow passage with ceiling
CreateCube("TunnelWall1", new Vector3(-2, 0.5f, 20), new Vector3(1, 1, 10));
CreateCube("TunnelWall2", new Vector3(2, 0.5f, 20), new Vector3(1, 1, 10));
CreateCube("TunnelTop", new Vector3(0, 2.5f, 20), new Vector3(5, 1, 10));
```

## Design Best Practices

1. **Start Simple**
   - Keep first level easy
   - Teach mechanics first

2. **Gradual Difficulty**
   - Each level slightly harder
   - Add one new challenge per level

3. **Clear Goal Path**
   - Player should see goal
   - Path should be obvious but challenging

4. **Feedback Loop**
   - Visual feedback for progress
   - Sound effects for actions
   - Particle effects for impact

5. **Fair but Challenging**
   - Obstacles should be avoidable
   - Physics should be predictable
   - Time limits should be generous

## Testing Your Level

1. **Run first test**
   - Can you reach the goal?
   - Is it physically possible?

2. **Measure time**
   - Complete level 3-4 times
   - Take average time
   - Set limit 1.5x average

3. **Check difficulty**
   - Is it fun?
   - Is it fair?
   - Are obstacles clear?

4. **Gather feedback**
   - Let others play
   - Note frustration points
   - Adjust accordingly

## Level Progression Example

### Level 1
- Time: 300s
- Objects: 3
- Obstacles: 2
- Complexity: Simple straight path
- Challenge: Learning controls

### Level 2
- Time: 180s
- Objects: 3
- Obstacles: 5
- Complexity: Curved path with obstacles
- Challenge: Precision control

### Level 3
- Time: 120s
- Objects: 4
- Obstacles: 8 + 2 moving platforms
- Complexity: Maze-like with moving elements
- Challenge: Speed + precision

## Common Design Mistakes

❌ **Too many obstacles**
- Player can't find path
- Frustration increases
- Fix: Leave clear pathways

❌ **Time limit too tight**
- Impossible to complete
- Player gives up
- Fix: Test and adjust timing

❌ **Unclear goal**
- Player doesn't know objective
- No sense of progress
- Fix: Make goal obvious and visible

❌ **Physics too unpredictable**
- Player can't control objects
- Feels unfair
- Fix: Tune physics carefully

✅ **Do this instead**
- Clear, achievable goals
- Fair physics
- Progressive difficulty
- Satisfying feedback
