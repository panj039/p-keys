# P-Keys

[English Document](./README_EN.md)

## 概述

按键宏功能

## 功能

- [x] 按键按下后触发宏, 按下的按键会被替换
- [x] 替换逻辑为从左到右依次按下, 等待指定按键按下时间, 倒叙松开所有按键
- [x] 按下等待时间默认50ms, 可通过配置文件配置(所有按键按下后开始等待, 不是每按下一个按键都会等待)
- [x] 按键宏分组
- [x] 手动开启禁用功能
- [x] 热键开启禁用功能
- [x] 展示当前按下按键
- [x] 按键宏嵌套, 如: `a=b, b=c`, 则`a=c`, 可通过设置`Nest`开启或关闭
- [x] 鼠标点击触发, 通过键盘按键可以触发鼠标按键点击操作
- [x] 可在所有输入框中点击右键, 进行对应项目的`编辑/删除/重命名/复制`等操作
- [x] 托盘图标, 菜单, 通知

## 界面说明

### 菜单

- `Add`, 新增
  - `Group`, 新增分组
  - `Key`, 新增按键宏
- `Settings`, 配置文件
  - `Open`, 使用本地应用打开配置文件
  - `Reload`, 手动读取本地配置文件
  - `Notification`, 托盘通知
- `Help`, 帮助说明
  - `All Support Keys`, 当前应用所有支持按键
  - `Help`, 使用帮助和当前已知的一些问题
  - `Abort`, 应用版本信息

## 配置文件

**一般情况下无需手动编辑配置文件, 直接使用界面功能编辑即可**
在文件`assets/config.yml`中
无需手动创建, 首次打开应用会自动生成模板
可在应用内部直接修改

### 举例

```yaml
hotkey: "`" # keep empty to disable hotkey
# pressdowntime: 50 # key delay in ms(default 50)
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