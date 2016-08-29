# Android常用代码

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

