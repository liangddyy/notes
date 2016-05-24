# Android——持久化技术

## 1. 文件存储

不可以指定路径。默认路径：`/data/data/<package name>/files/` 

### 保存到文件

Context提供了两种模式：MODE_PRIVATE、MODE_APPEND

MODE_PRIVATE：如果有同名文件，覆盖内容

MODE_APPEND：如果有同名文件，追加内容

示例：(保存inputText)

```java
public void save(String inputText) {
    FileOutputStream out = null;
    BufferedWriter writer = null;
    try {
        out = openFileOutput("data", Context.MODE_APPEND);
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
}
```

### 从文件读取

```java
public String load() {
    FileInputStream in = null;
    BufferedReader reader = null;
    StringBuilder content = new StringBuilder();
    try {
        in = openFileInput("data");
        reader = new BufferedReader(new InputStreamReader(in));
        String line = "";
        while ((line = reader.readLine()) != null) {
            content.append(line);
        }
    } catch (IOException e) {
        e.printStackTrace();
    } finally {
        if (reader != null) {
            try {
                reader.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
    return content.toString();
}
```

## 2. SharedPreferences存储

SharedPreferences键值对的方式存储。支持多种不同**数据类型**。

默认路径：`/data/data/<package name>/shared_prefs/`

### 保存到SharedPreferences

getPreferences()有两个参数，第一个参数为文件名，第二个参数为**操作模式**：

MODE_PRIVATE	默认

MODE_MULTI_PROCESS	用于多个进程对同一个SharedPreferences文件读写。

示例：

```
SharedPreferences.Editor editor = getPreferences(MODE_PRIVATE).edit();
				editor.putString("name", "Tom");
				editor.putInt("age", 28);
				editor.putBoolean("married", false);
				editor.commit();
```

### 从SharedPreferences读取

```
SharedPreferences pref = getSharedPreferences("data", MODE_PRIVATE);
				String name = pref.getString("name", "");
				int age = pref.getInt("age", 0);
				boolean married = pref.getBoolean("married", false);
				Log.d("MainActivity", "name is " + name);
				Log.d("MainActivity", "age is " + age);
				Log.d("MainActivity", "married is " + married);
```

## 3. SQLite数据库存储*

SQLiteOpenHelper.java

`SQLiteOpenHelper(this, "BookStore.db", null, 2);`构造函数的四个参数分别是 content、数据库名、Cursor(null)、**版本号**。

备注：

```
db.execSQL(cmd);
getWritableDatabase();
getReadableDatabase();
```
```
insert("dbName",未指定数据赋值(null),ContentValues);
update("dbName",ContentValues,"条件","条件值");
delete("dbName","条件","条件值)
query();
```

### 使用事务

```
db.beginTransaction();//开始事务
db.setTransactionSuccessful();//事务执行成功
db.endTransaction();//结束
```

