# java

## 字符串

### Md5

```
public class Md5Util {
    /**
     * 对字符串md5加密
     *
     * @param str
     * @return
     */
    public static String getMD5(String str) {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.update(str.getBytes());
            return new BigInteger(1, md.digest()).toString(16);
        } catch (Exception e) {
            Log.d("BaseInfoActivity", "MD5加密出现错误 ");
            return null;
        }
    }
}
```

