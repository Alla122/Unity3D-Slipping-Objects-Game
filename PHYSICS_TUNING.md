# Physics Tuning Guide

## Understanding Game Physics

The slipping effect comes from low friction values on the SlipperObject and moderate drag on the Rigidbody.

## Key Physics Parameters

### Rigidbody Settings

```csharp
// SlipperObject.cs
private float drag = 0.3f;              // Linear deceleration
private float angularDrag = 0.3f;       // Rotational deceleration
private float maxSpeed = 30f;           // Terminal velocity
private float mass = 1f;                // Object weight
```

### Physics Material

```csharp
PhysicMaterial slipperMaterial = new PhysicMaterial
{
    staticFriction = 0.1f,              // Friction when stationary
    dynamicFriction = 0.1f,             // Friction when moving
    bounciness = 0.2f,                  // Bounce on collision
    frictionCombine = PhysicMaterialCombine.Minimum  // Use lower friction
};
```

## Tuning for Different Effects

### For More Slippery (Harder)

Decrease these values:
- Static Friction: 0.05
- Dynamic Friction: 0.05
- Drag: 0.2

### For Less Slippery (Easier)

Increase these values:
- Static Friction: 0.2
- Dynamic Friction: 0.2
- Drag: 0.5

### For More Speed Control

Increase drag:
- Drag: 0.7
- Angular Drag: 0.7
- Max Speed: 15

### For More Momentum

Decrease drag:
- Drag: 0.1
- Angular Drag: 0.1
- Max Speed: 50

## Player Force Tuning

```csharp
// PlayerController.cs
private float pushForce = 15f;  // Push strength
private float pullForce = 10f;  // Pull strength
```

### Increase Difficulty

```csharp
private float pushForce = 10f;  // Less push power
private float pullForce = 5f;   // Less pull power
```

### Decrease Difficulty

```csharp
private float pushForce = 20f;  // More push power
private float pullForce = 15f;  // More pull power
```

## Time Limit Tuning

```csharp
// GameManager.cs
[SerializeField] private float levelTimeLimit = 300f;  // Seconds
```

- Easy: 300s (5 minutes)
- Medium: 180s (3 minutes)
- Hard: 120s (2 minutes)
- Extreme: 60s (1 minute)

## Obstacle Friction

Walls and obstacles should have higher friction to provide stable barriers:

```csharp
PhysicMaterial wallMaterial = new PhysicMaterial
{
    staticFriction = 1.0f,
    dynamicFriction = 1.0f,
    bounciness = 0.1f
};
```

## Testing Changes

1. **Make one change at a time**
2. **Play test for 2-3 minutes**
3. **Adjust based on feel**
4. **Document what worked**

## Common Issues and Fixes

| Problem | Cause | Fix |
|---------|-------|-----|
| Objects slide too much | Low friction | Increase friction values |
| Objects stop too quickly | High drag | Decrease drag |
| Difficult to control | High push force | Decrease push force |
| Objects fall through | Physics glitch | Increase collision detection |
| Shaking objects | Conflicting forces | Increase solver iterations |

## Advanced Physics Settings

Edit → Project Settings → Physics

```
Gravity: (0, -9.81, 0)
Default Material: (1.0, 1.0, 0.0)
Bounce Threshold: 2
Sleep Threshold: 0.005
Default Solver Iterations: 6
Default Solver Velocity Iterations: 2
QueriesHitBackfaces: false
Queries Hit Triggers: false
Enable Adaptive Force: true
Cloth Inter Collision Distance: 0
Cloth Inter Collision Stiffness: 0.2
```

## Performance Considerations

- More objects = more computation
- Higher solver iterations = more accurate but slower
- Limit velocity calculations per frame
- Use continuous collision detection sparingly

## Quick Tuning Checklist

- [ ] Test push/pull forces
- [ ] Verify friction settings
- [ ] Check max speed limits
- [ ] Test time pressure
- [ ] Verify obstacle collision
- [ ] Test goal detection
- [ ] Check performance on target hardware
