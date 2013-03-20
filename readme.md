# MardownTableFormatter

A quick and dirty formatter for markdown tables.

## Example

When I copy this into the upper textbox

    | Weapon                   | Cost to Fire | Cost to Move and Fire ||
    | ------------------------ | ------------ | --------- | ---------- |
    | | | Forward | Backward |
    | Storm Bolter | 1 | 1 | 2 |
    | Heavy Flamer | 2 | - | - |
    | Assault Cannon Burst | 1 | 1 | 2 |
    | Assault Cannon Full Auto | 2 | - | - |
    | Grenade Launcher | 1 | 1 | 2 |

Then the lower textbox and the clipboard will contain

    | Weapon                   | Cost to Fire | Cost to Move and Fire |            |
    | ------------------------ | ------------ | --------------------- | ---------- |
    |                          |              | Forward               | Backward   |
    | Storm Bolter             | 1            | 1                     | 2          |
    | Heavy Flamer             | 2            | -                     | -          |
    | Assault Cannon Burst     | 1            | 1                     | 2          |
    | Assault Cannon Full Auto | 2            | -                     | -          |
    | Grenade Launcher         | 1            | 1                     | 2          |
