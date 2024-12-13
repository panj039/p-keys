# P-Keys

[中文说明](./README.md)

## Overview

Key macro functionality.

## Features

- [x] Trigger macros when keys are pressed, with the pressed keys being replaced.
- [x] The replacement logic simulates sequential key presses from left to right, waits for a specified key press delay, and then releases all keys in reverse order.
- [x] Default key press delay is 50ms, configurable through the configuration file (the delay starts after all keys are pressed, not after each individual key press).
- [x] Key macros can be grouped.
- [x] Enable or disable functionality manually.
- [x] Enable or disable functionality using a hotkey.
- [x] Display currently pressed keys.
- [x] Support nested key macros, e.g., `a=b, b=c` results in `a=c`. Can be turned on or off by setting 'Nest'.
- [x] Mouse clicks can be triggered by keyboard keys, enabling the simulation of mouse click actions.
- [x] Right-clicking in any input field opens a context menu for `Edit/Delete/Rename/Copy` operations.
- [x] Tray-Icon, Menu, Notification

## UI Description

### Menu

- `Add`, Add new items
  - `Group`, Add a new group
  - `Key`, Add a new key macro
- `Settings`, Configuration file
  - `Open`, Open the configuration file with a local application
  - `Reload`, Manually reload the local configuration file
  - `Notification`, Tray-Icon notification
- `Help`, Help menu
  - `All Support Keys`, List all supported keys in the current application
  - `Help`, Usage guide and known issues
  - `About`, Application version information

## Configuration File

**In most cases, there is no need to manually edit the configuration file; use the interface features instead.**  
Located at `assets/config.yml`.  
The file is generated automatically when the application is first launched, no manual creation is required.  
You can edit it directly within the application.

### Example

```yaml
hotkey: "`" # keep empty to disable hotkey
# pressdowntime: 50 # key delay in ms (default 50)
# nest: false # enable key macro calls another key macro
# nest_max: 10 # max call depth
# notification: true # enable tray notification(default true)
groups:
  example_group: # group name
    q: # copy
      - key: "CTrL"
      - key: "C"
    W: # paste
      - key: "ctrl"
      - key: "v"
    e: # mouse right click
      - key: "rbutton"
    r: # mouse double click
      - key: "lbutton"
      - key: "lbutton"
  example_group_b:
    q:
      - key: "a"
      - key: "s"
      - key: "d"
      - key: "f"
```
