# Android常用代码

## 解决启动时白屏

style

```
<style name="AppTheme.Start" parent="AppTheme">
        <item name="android:windowBackground">@drawable/welcom_bg</item>
        <item name="android:windowNoTitle">true</item>
</style>
```

welcom_bg 为欢迎页图片。

如果要设置成透明，则 

`<item name="android:windowBackground">@drawable/welcom_bg</item>`

改为

```
<item name="android:windowIsTranslucent">true</item>
```

同时

Mainfest.xml 将启动的界面主题改位上面的AppTheme.Start 同时，删掉欢迎页的`setContentView(R.layout.activity_welcom);`

## 防止重复打开Toast

```
/**
 * 防止Toast队列 不断显示 影响体验
 * 
 * @author Leon Liang
 * @created 2016/9/2 1:38
 */
private static Toast mToast = null;
public static void showToast(Context context, String text, int duration) {
    if (mToast == null) {
        mToast = Toast.makeText(context.getApplicationContext(), text, duration);
    } else {
        mToast.setText(text);
        mToast.setDuration(duration);
    }
    mToast.show();
}
```

## 使用默认浏览器打开

推荐使用,第一次可选浏览器

```
Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(newsItem.getLink()));
startActivity(intent);
```



## 选择一款浏览器 打开

```
Intent intent= new Intent();
intent.setAction(Intent.ACTION_VIEW);
Uri content_url = Uri.parse(newsItem.getLink());
intent.setData(content_url);
startActivity(Intent.createChooser(intent, "请选择一款浏览器"));
```



## 系统自带分享

```
private void share() {  
    Intent share_intent = new Intent();  
    share_intent.setAction(Intent.ACTION_SEND);  
    share_intent.setType("text/plain");  
    share_intent.putExtra(Intent.EXTRA_SUBJECT, "分享呀");  
    share_intent.putExtra(Intent.EXTRA_TEXT, "推荐你使用一款软件:blablabla");  
    share_intent = Intent.createChooser(share_intent, "分享");  
    startActivity(share_intent);  
}  
```

## 调用相机/带路径

```
fileUri = getOutputMediaFileUri(MEDIA_TYPE_IMAGE); //得到存储地址的Uri
Intent i = new Intent(MediaStore.ACTION_IMAGE_CAPTURE); //此action表示进行拍照
i.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);  //指定图片的输出地址
//Intent openCameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
startActivityForResult(i, REQUEST_IMAGE_CAPTURE);
```

## 从SD卡得到一个路径

```
/**
 * 获取文件路径
 *
 * @author Leon Liang
 * @created 2016/8/25 20:15
 */
private static Uri getOutputMediaFileUri(int type) {
    return Uri.fromFile(getOutputMediaFile(type));
}

/**
 * 获取文件路径
 *
 * @author Leon Liang
 * @created 2016/8/25 20:16
 */
private static File getOutputMediaFile(int type) {
    // To be safe, you should check that the SDCard is mounted
    // using Environment.getExternalStorageState() before doing this.
    // 首先检测外部SDCard是否存在并且可读可写
    if (!Environment.getExternalStorageState().equals("mounted")) {
        return null;
    }

    File mediaStorageDir = new File(Environment.getExternalStoragePublicDirectory(
            Environment.DIRECTORY_PICTURES), "Caffe-Android-Demo");
    // This location works best if you want the created images to be shared
    // between applications and persist after your app has been uninstalled.

    // 如果存储路径不存在，则创建
    // Create the storage directory if it does not exist
    if (!mediaStorageDir.exists()) {
        if (!mediaStorageDir.mkdirs()) {
            Log.d("MyCameraApp", "failed to create directory");
            return null;
        }
    }

    // Create a media file name
    String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
    File mediaFile;
    if (type == MEDIA_TYPE_IMAGE) {
        mediaFile = new File(mediaStorageDir.getPath() + File.separator +
                "IMG_" + timeStamp + ".jpg");
    } else {
        return null;
    }
    return mediaFile;
}
```

## 连续按两次退出程序

```
private long mPressedTime = 0;
/**
* 复写返回按钮 连续两次返回退出程序
*
* @author Leon Liang
* @created 2016/8/27 14:14
*/
@Override
public void onBackPressed() {
    long mNowTime = System.currentTimeMillis();//获取第一次按键时间
	if ((mNowTime - mPressedTime) > 2000) {//比较两次按键时间差
    	Toast.makeText(this, "再按一次退出程序", Toast.LENGTH_SHORT).show();
    	mPressedTime = mNowTime;
	} else {//退出程序
    	this.finish();
    	System.exit(0);
	}
}
```

## 返回键不退出程序 Home键效果

```
//返回键 实现Home键效果
//super.onBackPressed();这句话一定要注掉,不然又去调用默认的back处理方式了
Intent i = new Intent(Intent.ACTION_MAIN);
i.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
i.addCategory(Intent.CATEGORY_HOME);
startActivity(i);
```

## 跳转应用市场评分

```
//跳转应用市场评分
try {
    Uri uri = Uri.parse("market://details?id=" + getPackageName());
    intent = new Intent(Intent.ACTION_VIEW, uri);
    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
    startActivity(intent);
} catch (ActivityNotFoundException e) {
    Toast.makeText(MainActivity.this, "你手机上没有应用市场哈 !", Toast.LENGTH_SHORT).show();
}
```

