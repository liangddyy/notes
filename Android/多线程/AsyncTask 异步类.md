# Android AsyncTask 异步类

AsyncTask直接继承Object类，位于android.os.AsyncTask。

一个AsyncTask实现类接收三个泛型参数：Params，Progress和Result，需要四步完成：`onPreExecute()`，`doInBackground()`，`onProgressUpdate()`，`onPostExecute()`。

##　基本用法

通过继承AsyncTask类实现自己的异步任务。

### 泛型参数

AsyncTask接收三个泛型参数分别为：

1. Params 

   可用于在后台任务中使用。

2. Progress  

   后台任务执行的进度。

3. Result 

   任务执行的结果。

如：`class DownLoadTask extends AsyncTask<Integer, Void, String> {`

### 四个方法

`onPreExecute()`

该方法会在后台任务开始之前被调用，通常在这里可以完成一些界面初始化工作。

`doInBackground()`（不允许UI操作）

在`onPreExecute()`执行完之后就会调用该方法，此时进入到后台任务（子线程中，因此不能更新UI操作）。若AsyncTask类中的第三个参数不是Void类的话，则该方法需要返回第三个泛型参数类型值。若想显示任务进度的话可以在该方法中调用`publishProgress()`方法将进度传递给`onProgressUpdate()`。

`onProgressUpdate()`

当在`doInBackground()`中调用`publishProgress()`方法后，该方法就会在UI线程中被调用，可以用于更新UI。该方法可以在后台任务执行的同时更新UI。

`onPostExecute()`

当`doInBackground()`执行完成后，且第三个泛型参数不是Void时，就会在UI线程中调用该方法。后台任务执行结果将以参数的形式传递进来，因此可以在这里执行任务完成后的操作。

### 终止任务

在后台任务执行时可以通过调用`cancel()`方法来终止该任务。调用该方法之后，在`doInBackground()`执行后将调用`onCancelled()`，而不再会调用`onPostExecute()`。

## 线程规则

为了让该类能合理的执行，以下规则需要注意一下：

1. AsyncTask 类必须在UI线程中加载，这个该步骤作为`JELLY_BEAN`自动完成。
2. 实例必须在UI线程中创建。
3. 必须在UI线程中调用`execute()`。
4. 不要手动调用`onPreExecute()`，`doInBackground()`，`onProgressUpdate()`，`onPostExecute()`。
5. 任务只能被执行一次，若执行第二次的话将会抛出异常。





