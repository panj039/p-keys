# P-Keys

## 功能

按键宏功能

## 配置文件

在文件`assets/config.json`中
无需手动创建, 首次打开应用会自动生成模板
可在应用内部直接修改

### 举例

```json
{
	"hotkey": "`",
	"groups": [
		{
			"name": "group_a",
			"keys": [
				{
					"key": "Z",
					"links": [
						{
							"key": "X"
						},
						{
							"key": "C"
						}
					]
				},
				{
					"key": "A",
					"links": [
						{
							"key": "S"
						},
						{
							"key": "D"
						}
					]
				}
			]
		},
		{
			"name": "group_b",
			"keys": [
				{
					"key": "Z",
					"links": [
						{
							"key": "S"
						},
						{
							"key": "D"
						}
					]
				}
			]
		}
	]
}
```