# Android——持久化技术

## 文件存储

### 保存到文件

Context提供了两种模式：MODE_PRIVATE、MODE_APPEND

MODE_PRIVATE：如果有同名文件，覆盖内容

MODE_APPEND：如果有同名文件，追加内容

示例：(保存inputText)

```
FileOutputStream out = null;
        BufferedWriter writer = null;
        try {
            out = openFileOutput("data", Context.MODE_PRIVATE);
            writer = new BufferedWriter(new OutputStreamWriter(out));
            writer.write(inputText);
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                if (writer != null) {
                    writer.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
```

