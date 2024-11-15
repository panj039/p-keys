# P-Keys

## 配置文件举例

`assets/config.json`

```json
{
	"HotKey": "`",
	"groups": [
		{
			"group": "group_a",
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
			"group": "group_b",
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