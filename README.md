# P-Keys

## 功能

按键宏功能

## 配置文件

在文件`assets/config.yml`中
无需手动创建, 首次打开应用会自动生成模板
可在应用内部直接修改

### 举例

```yaml
hotkey: "`" # keep empty to disable hotkey
# keydelay: 50 # key delay in ms(default 50)
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