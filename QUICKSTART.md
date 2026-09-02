# Quick Start Guide

## Installation (5 minutes)

1. Clone repository
   ```bash
   git clone https://github.com/Alla122/Unity3D-Slipping-Objects-Game.git
   ```

2. Open in Unity Hub (2021 LTS or newer)

3. Wait for import to complete

## Build Your First Level (10 minutes)

### Option A: Automatic Build
1. Create new Scene → Save as "Level1" in Assets/Scenes
2. Create empty GameObject
3. Add "SceneBuilder" script
4. Set "buildOnStart" = true
5. Click Play
6. Save scene
7. Delete SceneBuilder, save again

### Option B: Manual Build
Follow instructions in DEVELOPMENT_GUIDE.md

## Play the Game

1. Add to Build Settings (File → Build Settings)
2. Press Play in Editor
3. Use mouse to push/pull objects
4. Move all 3 orange cubes to the green goal area

## Game Mechanics

- **Left Click** = Push objects forward
- **Right Click** = Pull objects backward  
- **R** = Reset object position
- **ESC** = Pause game

## Create More Levels

1. Duplicate Level1 as Level2
2. Add more obstacles
3. Add to Build Settings
4. LevelManager automatically handles progression

## Next Steps

- Customize obstacle layouts
- Adjust physics parameters
- Add sound effects
- Add particle effects
- Create difficulty tiers

For detailed info, see DEVELOPMENT_GUIDE.md
